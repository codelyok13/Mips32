using System;

namespace Mips32
{
    /*
     * Replace All fill _some type of memory_ method with fill Memory method by making arrays public 
     */
    class Program
    {
        static Mux  a4to1, //RegDestMux 
                    c2to1, //aluSrcAMux
                    d2to1, //aluSrcBMux
                    m4to1; //memMux


        static void Main(string[] args)
        {
            MIPS();
        }
        static void MIPS()
        {
            Register.FillRegesters();   //Fill Registers with Random data
            Datamem.FillDatamem();  //Fill Data memory with Random data

            int pc = 0;
            //Instruction Decode and Register Fetch
            InstructionDecodeAndRegisterFetch(pc, out string instruction, out string control, out string selected);
            //Execute Address Calc.
            string result = AddressCalc(instruction, control);
            //Memory Access
            string data = MemoryAccess(control, result);
            //Write Back: Write to memory and Registers

            Register.WriteRegister(selected, control.Substring(3, 1), data);
        }

        private static void InstructionDecodeAndRegisterFetch(int pc, out string instruction, out string control, out string selected)
        {
            InstructionMem.Fill(new string[] { "00111101000010011111111111111111" });
            instruction = InstructionMem.GetInstruction(pc);
            control = ControlUnit.SetInput(instruction.Substring(0, 6),instruction.Substring(26,6));
            Register.SetData(instruction.Substring(6, 5), instruction.Substring(11, 5));
            a4to1 = new Mux(new string[] { instruction.Substring(11, 5), instruction.Substring(16, 5), Convert.ToString(31, 2), "" })
            { select = control.Substring(0, 2) };
            selected = a4to1.Selected();
        }

        private static string AddressCalc(string instruction, string control)
        {
            c2to1 = new Mux(new String[] { Register.data1, instruction.Substring(6, 5) });
            d2to1 = new Mux(new String[] { Register.data2, Extender.Extend(instruction.Substring(16, 16), control.Substring(20, 1) + "0") });
            string selection = control.Substring(4, 4).Replace("_", "");
            c2to1.select = selection[0].ToString();
            d2to1.select = selection[1].ToString();

            string result = ALU.Result(c2to1.Selected(), d2to1.Selected(), control.Substring(9, 4));
            return result;
        }

        private static string MemoryAccess(string control, string result) //add pc so i can jump and link
        {
            Datamem.writeEHB = control.Substring(14, 5).Replace("_", ""); //Write enable, half and byte
            Datamem.DataIn(result, Register.data2); //perform operation

            string data = Extender.Extend(Datamem.DataOut(result).Substring(16,16), control.Substring(20, 3));

            m4to1 = new Mux(new String[] { Datamem.DataOut(result), data, result })
            {
                select = control.Substring(26, 2)
            };
            return m4to1.Selected();
        }  
    }
}
