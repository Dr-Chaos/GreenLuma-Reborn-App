using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLRApp
{
    public static class Extensions
    {
        public static int toInt(this object l)
        {
            return Convert.ToInt32(l);
        }
    }
}
