using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class Mux
    {
        string[] mux;
        public string select;
        public Mux(string[] val)
        {
            mux = new string[val.Length];
            for (int i = 0; i < val.Length; i++)
            {
                mux[i] = val[i];
            }
        }

        public string Selected()
        {
            int iSelect = Convert.ToInt32(select, 2);
            return mux[iSelect];
        }
    }
}
