using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class Register
    {
        public static string[] register = new string[32];

        public static string data1, data2;

        public static void FillRegesters() //Fill Registers with Trash Data
        {
            Random r = new Random();
            for (int i = 0; i < register.Length; i++)
            {
                if (register[i] == null)
                {
                    /*string rand = "";
                    
                    while (rand.Length < 32)
                    {
                        rand += r.Next(2);
                    }*/
                    register[i] = "0".PadLeft(32, '0');//; rand;
                }
            }
        }
        public static void WriteRegister(String iNum, string iEnabled,string data)
        {
            int num = Convert.ToInt32(iNum, 2);
            bool enabled = Convert.ToBoolean(Convert.ToInt32(iEnabled, 2));
            if (enabled && num != 0 && num != 30)
            {
                register[num] = data;
            }
        }
        public static void SetData(string s1, string s2)
        {
            int i1 = Convert.ToInt32(s1, 2);
            int i2 = Convert.ToInt32(s2, 2);
            data1 = register[i1];
            data2 = register[i2];
        }
    }
}
