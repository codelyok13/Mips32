using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class ALU
    {
        static int a, b; //change back to log if it breaks slt and sltu
        static string sA, sB;
        static bool wZero = false;
        //Add in wZero by using another result method

        public static string Result(string inA, string inB, string Ops)
        {
            string result = Result1(inA,inB,Ops);
            if (0 == Convert.ToInt32(result, 2))
            {
                wZero = true;
            }

            return result.PadLeft(32,result[0]);
        }
        public static string Result1(string inA, string inB, string Ops) //ask doctor foster if add and sub are signed or unsigned
        {
            a = Convert.ToInt32(inA, 2);
            b = Convert.ToInt32(inB, 2);
            sA = inA.PadLeft(32, '0');
            sB = inB.PadLeft(32, '0');

            switch (Ops)
            {
                case "0000":
                    return Convert.ToString(a + b,2);
                case "0001":
                    return Convert.ToString(a - b,2);
                case "0010":
                    return Convert.ToString(a&b,2);
                case "0011":
                    return Convert.ToString(a|b,2);
                case "0100":
                    return Convert.ToString(a ^ b,2);
                case "0101":
                    return NOR();
                case "0110":
                    return SLT();
                case "0111":
                    return SLTU();
                case "1000":
                    return Convert.ToString(b << a,2);
                case "1001":
                    return Convert.ToString((uint)b >> a, 2);
                case "1010":
                    return Convert.ToString(b >> a, 2);
                case "1011":
                    return sA;
                case "1100":
                    return sB.Substring(0,16).PadRight(32,'0');
            }

            return "Got Nothing";
        }


        static string OR()
        {
            string result = "";
            for (int i = 0; i < 32; i++) //code below perfroms bitwise operation with strings__ check with a truth table
            {
                if (sA[i].Equals(sB[i]))
                {
                    result += sA[i];
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }
        static string XOR()
        {
            string result = "";
            for (int i = 0; i < 32; i++) //code below perfroms bitwise operation nor with strings__ check with a truth table
            {
                if (sA[i].Equals(sB[i]))
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }
        static string NOR()
        {
            string result = "";
            for (int i = 0; i < 32; i++) //code below perfroms bitwise operation xor with strings__ check with a truth table
            {
                if (sA[i].Equals('0') && sB[i].Equals('0'))
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }
        static string SLT()
        {
            if (sA[0].Equals('1') && sB[0].Equals('0'))
            {
                return "1";
            }
            for (int i = 1; i < 32; i++)
            {
                if (sA[i].Equals('1') && sB[i].Equals('0'))
                {
                    return "0";
                }
            }
            return "0";
        }
        static string SLTU()
        {
            for (int i = 1; i < 32; i++)
            {
                if (sA[i].Equals('0') && sB[i].Equals('1'))
                {
                    return "1";
                }
            }
            return "0";
        }
    }
}
