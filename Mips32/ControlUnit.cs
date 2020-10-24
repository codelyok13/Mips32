using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    public static class ControlUnit
    {
        public static string SetInput(String opcode,string shamt)
        {
            switch (opcode)
            {
                case "000000":
                    return Shamt(shamt);
                case "100011":  //LW
                    return "00_1_0_1_0000_0_0_0_1_0_0_00_0_00";
                case "001111":  //LUI
                    return "00_1_0_1_1100_0_0_0_1_0_0_10_0_00";
            }
            return "I Don't Know";
        }

        public static string Shamt(string shamt)
        {
            switch (shamt)
            {
                case "100001":
                    return "01_1_1_1_0000_0_0_0_1_0_0_10_0_00";
            }
            return "Don't Know Shamt";
        }
    }
}
