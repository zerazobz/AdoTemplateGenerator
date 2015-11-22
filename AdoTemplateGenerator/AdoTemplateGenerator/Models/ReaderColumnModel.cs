using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoTemplateGenerator.Models
{
    public class ReaderColumnModel
    {
        public string RawColumnName { get; set; }
        public string ColumnName { get; set; }
        public bool AllowDbNUll { get; set; }
        public bool IsUnique { get; set; }
        public bool IsAutoIncrement { get; set; }
        public string DataTypeName { get; set; }
        public string DataTypeFullName { get; set; }
        public Type DataType { get; set; }
    }
}
