using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class Extender
    {

        public static string Extend(string a, string sSB)
        {
            string sSignByte = sSB.Replace("_", "");
            bool signed = Convert.ToBoolean(Convert.ToInt32(sSignByte.Substring(0,1), 2));
            bool bite = Convert.ToBoolean(Convert.ToInt32(sSignByte.Substring(1,1), 2));
            if (signed && bite)
            {
                return (a.Substring(8, 8)).PadLeft(32, a[0]);
            }
            else if (!signed && bite)
            {
                return (a.Substring(8, 8)).PadLeft(32, '0');
            }
            else if (!signed && !bite)
            {
                return a.PadLeft(32, '0');
            }
            else
                return a.PadLeft(32, a[0]);
        }
    }
}
