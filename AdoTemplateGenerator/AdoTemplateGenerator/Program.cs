using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AdoTemplateGenerator.Helpers;
using AdoTemplateGenerator.Templates;

namespace AdoTemplateGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Generating SLQ Mapping";
            if (args.Length == 0)
            {
                Console.WriteLine("Without Args");
                return;
            }
            string connectionStringName = "ConnectionString";
            string storedProcedureName = args.GetValue(0).ToString();
            string typeTemplate = args.GetValue(1).ToString();

            string nonQueryResult = String.Empty;
            string readerResult = String.Empty;

            if (typeTemplate == "nq")
                nonQueryResult = GetNonQueryResult(connectionStringName, storedProcedureName);
            else if(typeTemplate == "re")
                readerResult = GetReaderResult(connectionStringName, storedProcedureName);

            var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", "Generated", $"{storedProcedureName}.sql"));

            using (var writter = new StreamWriter(filePath, false))
            {
                writter.Write(nonQueryResult);
            }

            Console.ReadKey();
        }

        private static string GetNonQueryResult(string connectionStringName, string storedProcedureName)
        {
            var parametersDictionary = GetparametersDictionary(connectionStringName, storedProcedureName);

            Dictionary<string, Tuple<string, bool>> parametersToMap = parametersDictionary.Select(prmKVP => new KeyValuePair<string, Tuple<string, bool>>(prmKVP.Key, new Tuple<string, bool>(prmKVP.Value.Item1.GetFullName(), prmKVP.Value.Item2))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            NonQueryVBADOTemplate textTemplate = new NonQueryVBADOTemplate();
            textTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
            textTemplate.Session["procedureName"] = storedProcedureName;
            textTemplate.Session["connectionStringName"] = connectionStringName;
            textTemplate.Session["dictionaryParameters"] = parametersToMap;
            textTemplate.Initialize();
            var resultTemplate = textTemplate.TransformText();
            return resultTemplate;
        }

        private static string GetReaderResult(string connecionStringName, string storedProcedureName)
        {
            StringBuilder resultBuilder = new StringBuilder();
            SqlConnection readerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connecionStringName].ConnectionString);
            var storedProcedureParameters = GetparametersDictionary(connecionStringName, storedProcedureName);

            using (var readerCommand = new SqlCommand(storedProcedureName, readerConnection))
            {
                foreach (var iParameter in storedProcedureParameters)
                {
                    if (!iParameter.Value.Item2)
                    {
                        readerCommand.Parameters.Add(new SqlParameter(iParameter.Key, DBNull.Value));
                    }
                    else
                    {
                        //output
                    }
                }

                readerCommand.CommandType = CommandType.StoredProcedure;
                readerConnection.Open();
                using (var sqlReader = readerCommand.ExecuteReader(CommandBehavior.KeyInfo))
                //using (var sqlReader = readerCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    var schemaTable = sqlReader.GetSchemaTable();
                    foreach (DataRow iRow in schemaTable.Rows)
                    {
                        Console.WriteLine("***Nuevo Row***");
                        foreach (DataColumn iColumn in schemaTable.Columns)
                        {
                            resultBuilder.AppendLine(String.Format("Nombre de Valor: {0}, Valor: {1}, Columna: {2}", iColumn.ColumnName, iRow[iColumn].ToString(), iRow["columnName"].ToString()));
                            Console.WriteLine("Nombre de Columna: {0}, Valor: {1}, Columna: {2}", iColumn.ColumnName, iRow[iColumn].ToString(), iRow["columnName"].ToString());
                        }
                        Console.WriteLine("");
                    }
                }
                return resultBuilder.ToString();
            }
        }

        private static Dictionary<string, Tuple<SqlDbType, bool>> GetparametersDictionary(string connectionStringName, string storedProcedureName)
        {
            Dictionary<string, Tuple<SqlDbType, bool>> dictionaryResult = new Dictionary<string, Tuple<SqlDbType, bool>>();

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);

            Server srv = new Server(connectionBuilder.DataSource);
            srv.ConnectionContext.AutoDisconnectMode = AutoDisconnectMode.NoAutoDisconnect;
            srv.ConnectionContext.LoginSecure = false;
            srv.ConnectionContext.Login = connectionBuilder.UserID;
            srv.ConnectionContext.Password = connectionBuilder.Password;
            srv.ConnectionContext.Connect();
            Database db = srv.Databases[connectionBuilder.InitialCatalog];
            var dsfs = db.StoredProcedures;
            var storedProcedure = db.StoredProcedures[storedProcedureName];
            var storedProcedureParameters = storedProcedure.Parameters;

            foreach (var iParam in storedProcedureParameters)
            {
                var prmAnalized = iParam as StoredProcedureParameter;

                string parameterName = prmAnalized.Name;
                var internalSqlDataType = prmAnalized.DataType;
                object defaultValue = prmAnalized.DefaultValue;
                string clrRealType = prmAnalized.Properties[0].Type.FullName;
                bool isOutPut = prmAnalized.IsOutputParameter;

                System.Data.SqlDbType sqlDbType;

                if (internalSqlDataType.SqlDataType != SqlDataType.UserDefinedDataType)
                    sqlDbType = ConvertSqlTypeEnum(internalSqlDataType.SqlDataType);
                else
                    sqlDbType = GetSqlType(clrRealType);

                dictionaryResult.Add(parameterName, new Tuple<SqlDbType, bool>(sqlDbType, isOutPut));
                Console.WriteLine("Parametros: \t{0} {1} {2} {3} {4} {5}", parameterName, internalSqlDataType, defaultValue, clrRealType, sqlDbType.GetFullName(), isOutPut);
            }

            return dictionaryResult;
        }


        private static SqlDbType GetSqlType(string realType)
        {
            System.Type theType = Type.GetType(realType);

            SqlParameter param;
            System.ComponentModel.TypeConverter tc;
            param = new SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(param.DbType);
            if (tc.CanConvertFrom(theType))
            {
                param.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            else
            {
                try
                {
                    param.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception e)
                {
                }
            }
            return param.SqlDbType;
        }

        private static SqlDbType ConvertSqlTypeEnum(SqlDataType sqlDataType)
        {
            SqlDbType sqlDbType;
            switch (sqlDataType)
            {
                case SqlDataType.UserDefinedType:
                    sqlDbType = System.Data.SqlDbType.Udt;
                    break;
                case SqlDataType.None:
                case SqlDataType.NVarCharMax:
                case SqlDataType.UserDefinedDataType:
                case SqlDataType.VarBinaryMax:
                case SqlDataType.VarCharMax:
                case SqlDataType.SysName:
                //case SqlDataType.Numeric:
                case SqlDataType.UserDefinedTableType:
                case SqlDataType.HierarchyId:
                case SqlDataType.Geometry:
                case SqlDataType.Geography:
                    throw new NotSupportedException("Unable to convert to SqlDbType:" + sqlDataType);
                case SqlDataType.Numeric:
                    sqlDbType = SqlDbType.Decimal;
                    break;
                default:
                    sqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlDataType.ToString());
                    break;
            }
            return sqlDbType;
        }
    }
}
