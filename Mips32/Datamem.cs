using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mips32
{
    class Datamem
    {
        static string[] datamem1001 = new string[64];

        public static string writeEHB; //write Enable_Half_Byte

        public static void FillDatamem() //Fill Datamem with Trash Data
        {
            Random r = new Random();
            for (int i = 0; i < datamem1001.Length; i++)
            {
                if (datamem1001[i] == null)
                {
                    string rand = "";

                    while (rand.Length < 32)
                    {
                        rand += r.Next(2);
                    }
                    datamem1001[i] = rand;
                }
            }
        }

        public static string DataOut(string address) //FUTURE: use swith case for larger memory address or mod and division to calc offset
        {
            string dAddress = address.Substring(16, 16);
            int iAddress = Convert.ToInt32(dAddress, 2);
            int arrayLoc = iAddress / 4;

            try//if an inexistent memory address is given, an error wrill be thrown
            {
                return datamem1001[0/*arrayLoc*/];
            }
            catch (Exception e)
            {
                throw new Exception("THE ADDRESS " +iAddress+" DOESN'T EXIST");
            }
        }

        public static void DataIn(string address, string dInput)
        {
            string dAddress = address.Substring(16, 16);
            int iAddress = Convert.ToInt32(dAddress, 2);
            int arrayLoc = iAddress / 4;

            try
            {
                if (Convert.ToBoolean(Convert.ToInt32(writeEHB.Substring(0, 1))))
                {
                    if (Convert.ToBoolean(Convert.ToInt32(writeEHB.Substring(1, 1))))
                    {
                        datamem1001[arrayLoc] = datamem1001[arrayLoc].Substring(0,16) + dInput.Substring(16, 16);
                        return;
                    }
                    else
                    {
                        if (Convert.ToBoolean(Convert.ToInt32(writeEHB.Substring(2, 1))))
                        {
                            datamem1001[arrayLoc] = datamem1001[arrayLoc].Substring(0, 24) + dInput.Substring(16, 8);
                            return;
                        }
                        datamem1001[arrayLoc] = dInput;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                throw new Exception("THE ADDRESS " + Convert.ToString(iAddress,16) + "DOESN'T EXIST");
            }
        }
    }
}
