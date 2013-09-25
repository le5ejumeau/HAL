using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.DAL.Utils
{
    public static class SqlConvertion
    {
        public static String GetString(Object content)
        {
            if (content == DBNull.Value)
                return String.Empty;
            return Convert.ToString(content);
        }

        public static Int32 GetInt32(Object content)
        {
            if (content == DBNull.Value)
                return 0;
            return Convert.ToInt32(content);
        }

    }
}
