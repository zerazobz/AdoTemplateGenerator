using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoTemplateGenerator.Helpers
{
    public static class SqlDbTypeHelper
    {
        public static string GetFullName(this Enum myEnum)
        {
            return string.Format("{0}.{1}", myEnum.GetType().Name, myEnum.ToString());
        }
    }
}
