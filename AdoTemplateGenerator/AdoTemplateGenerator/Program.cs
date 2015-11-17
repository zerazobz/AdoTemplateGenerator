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

            Dictionary<string, Tuple<string, bool>> parametersToMap = new Dictionary<string, Tuple<string, bool>>();

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

                parametersToMap.Add(parameterName, new Tuple<string, bool>(sqlDbType.GetFullName(), isOutPut));

                Console.WriteLine("{0} {1} {2} {3} {4} {5}", parameterName, internalSqlDataType, defaultValue, clrRealType, sqlDbType.GetFullName(), isOutPut);
            }


            NonQueryVBADOTemplate textTemplate = new NonQueryVBADOTemplate();
            textTemplate.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
            textTemplate.Session["procedureName"] = storedProcedureName;
            textTemplate.Session["connectionStringName"] = connectionStringName;
            textTemplate.Session["dictionaryParameters"] = parametersToMap;
            textTemplate.Initialize();
            var resultTemplate = textTemplate.TransformText();

            var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", "Generated", $"{storedProcedureName}.sql"));

            using (var writter = new StreamWriter(filePath, false))
            {
                writter.Write(resultTemplate);
            }

            Console.ReadKey();
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
