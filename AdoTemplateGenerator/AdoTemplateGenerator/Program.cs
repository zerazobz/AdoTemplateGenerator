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
using AdoTemplateGenerator.Models;

namespace AdoTemplateGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Generating SLQ/Model/JTable Mapping";
            if (args.Length == 0)
            {
                Console.WriteLine("Without Args");
                return;
            }
            string connectionStringName = "ConnectionString";
            string storedProcedureName = args.GetValue(0).ToString();
            string typeTemplate = args.GetValue(1).ToString();

            string textResult = String.Empty;

            if (typeTemplate == "nq")
                textResult = GetNonQueryResult(connectionStringName, storedProcedureName);
            else if (typeTemplate == "re")
                textResult = GetReaderResult(connectionStringName, storedProcedureName);

            var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", "Generated", $"{storedProcedureName}.sql"));

            using (var writter = new StreamWriter(filePath, false))
            {
                writter.Write(textResult);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("File generated successfully.");

            Console.ReadKey();
        }

        private static string GetNonQueryResult(string connectionStringName, string storedProcedureName)
        {
            var parametersDictionary = GetStoredProcedureParametersDictionary(connectionStringName, storedProcedureName);
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

        private static string GetReaderResult(string connectionStringName, string storedProcedureName)
        {
            var readerResult = GetReaderColumnsDictionary(connectionStringName, storedProcedureName);
            Dictionary<string, Tuple<string, bool>> parametersToMap = readerResult.Item1.Select(prmKVP => new KeyValuePair<string, Tuple<string, bool>>(prmKVP.Key, new Tuple<string, bool>(prmKVP.Value.Item1.GetFullName(), prmKVP.Value.Item2))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            ReaderVBADOTemplate textTemplate = new ReaderVBADOTemplate();
            textTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
            textTemplate.Session["procedureName"] = storedProcedureName;
            textTemplate.Session["connectionStringName"] = connectionStringName;
            textTemplate.Session["dictionaryParameters"] = parametersToMap;
            textTemplate.Session["dictionaryColumns"] = readerResult.Item2;
            textTemplate.Initialize();
            var resulTemplate = textTemplate.TransformText();
            return resulTemplate;
        }

        private static Tuple<Dictionary<string, Tuple<SqlDbType, bool>>, Dictionary<string, ReaderColumnModel>> GetReaderColumnsDictionary(string connectionStringName, string storedProcedureName)
        {
            Dictionary<string, ReaderColumnModel> resultColumnsForReader = new Dictionary<string, ReaderColumnModel>();

            StringBuilder resultBuilder = new StringBuilder();
            SqlConnection readerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
            var storedProcedureParameters = GetStoredProcedureParametersDictionary(connectionStringName, storedProcedureName);

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
                        var newOutputParameter = new SqlParameter(iParameter.Key, iParameter.Value.Item1)
                        {
                            Direction = ParameterDirection.Output
                        };
                        readerCommand.Parameters.Add(newOutputParameter);
                    }
                }

                readerCommand.CommandType = CommandType.StoredProcedure;
                readerConnection.Open();
                using (var sqlReader = readerCommand.ExecuteReader(CommandBehavior.KeyInfo))
                {
                    var schemaTable = sqlReader.GetSchemaTable();

                    Console.WriteLine(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Getting resulset columns of Procedure: {storedProcedureName}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t{0,-25}\t{1,-25}\t{2}", "Columna Name", "CLR Type", "AllowDbNull");
                    foreach (DataRow iRow in schemaTable.Rows)
                    {
                        string columnNameNormalized = iRow["ColumnName"].ToString().Trim().Replace(" ", String.Empty);
                        bool allowDBNull = Convert.ToBoolean(iRow["AllowDBNull"]);
                        Type dataType = allowDBNull ? GetNullableType(iRow["DataType"] as Type) : (Type)iRow["DataType"];
                        string dataTypeFullName = String.Empty;
                        string dataTypeName = String.Empty;
                        if(allowDBNull)
                        {
                            var underLyingType = Nullable.GetUnderlyingType(dataType);
                            if(underLyingType != null)
                            {
                                dataTypeFullName = $"System.Nullable<{underLyingType.FullName}>";
                                dataTypeName = $"Nullable<{underLyingType.Name}>";
                            }
                            else
                            {
                                dataTypeFullName = dataType.FullName;
                                dataTypeName = dataType.Name;
                            }
                        }
                        else
                        {
                            dataTypeFullName = dataType.FullName;
                            dataTypeName = dataType.Name;
                        }

                        var readerColumnName = new ReaderColumnModel()
                        {
                            RawColumnName = iRow["ColumnName"].ToString(),
                            ColumnName = columnNameNormalized,
                            AllowDbNUll = allowDBNull,
                            IsUnique = Convert.ToBoolean(iRow["IsUnique"]),
                            DataType = dataType,
                            DataTypeFullName = dataTypeFullName,
                            DataTypeName = dataTypeName,
                            IsAutoIncrement = Convert.ToBoolean(iRow["IsAutoIncrement"])
                        };

                        if (!resultColumnsForReader.ContainsKey(columnNameNormalized))
                        {
                            resultColumnsForReader.Add(columnNameNormalized, readerColumnName);
                            Console.WriteLine($"\t{readerColumnName.ColumnName, -25}\t{readerColumnName.DataTypeFullName, -25}\t{readerColumnName.AllowDbNUll}");
                        }
                    }
                }
            }
            return new Tuple<Dictionary<string, Tuple<SqlDbType, bool>>, Dictionary<string, ReaderColumnModel>>(storedProcedureParameters, resultColumnsForReader);
        }

        private static Dictionary<string, Tuple<SqlDbType, bool>> GetStoredProcedureParametersDictionary(string connectionStringName, string storedProcedureName)
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

            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Getting parameters for stored procedure: {storedProcedureName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t{0, -15}\t{1,-10}\t{2, -10}\t{3, -10}\t{4}", "Name", "TSQL Type", "Default Type", "SqlDbType", "Is Ouput");
            foreach (var iParam in storedProcedureParameters)
            {
                var prmAnalized = iParam as StoredProcedureParameter;

                string parameterName = prmAnalized.Name;
                var internalSqlDataType = prmAnalized.DataType;
                object defaultValue = prmAnalized.DefaultValue;
                //string clrRealType = prmAnalized.Properties[0].Type.FullName;
                bool isOutPut = prmAnalized.IsOutputParameter;

                System.Data.SqlDbType sqlDbType;

                if (internalSqlDataType.SqlDataType != SqlDataType.UserDefinedDataType)
                    sqlDbType = ConvertSqlTypeEnum(internalSqlDataType.SqlDataType);
                else
                {
                    var currentUserDefinedDataType = db.UserDefinedDataTypes[internalSqlDataType.Name];
                    sqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), currentUserDefinedDataType.SystemType, true);
                }

                dictionaryResult.Add(parameterName, new Tuple<SqlDbType, bool>(sqlDbType, isOutPut));
                Console.WriteLine($"\t{parameterName, -15}\t{internalSqlDataType, -10}\t{defaultValue, -10}\t{sqlDbType.GetFullName()}\t{isOutPut} ");
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

        private static Type GetNullableType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
                return type;
            else if (type.IsValueType)
                return typeof(Nullable<>).MakeGenericType(type);
            else
                return type;
        }
    }
}
