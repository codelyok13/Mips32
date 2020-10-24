using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class InstructionMem
    {
        private static String[] instmem = new String[64]; //create an array to store instruction memory

        public static void Fill(String[] a) //Fills instruction memory with data at certain addresses
        {
            bool isGoodLength = false; //will be used to check that every instruction is the right size
            foreach (string b in a)
            {
                if (b.Length == 32 || b.Length == 8) //instructions are the correct length in binary or hexadecimal
                    isGoodLength = true;
                else
                {
                    isGoodLength = false;
                    break; //force program to leave loop
                }
            }
            if (isGoodLength == false)
            {
                throw new Exception("The instruction is not 32 bits long!!!");//this eception will be caught later
            }
            instmem = a;
        }

        public static string GetInstruction(int pc) //returns the instruction at a given memory address
        {
            return instmem[pc];
        }
    }
}
