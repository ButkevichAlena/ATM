using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMСonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = @"C:\Users\NotePad.by\Desktop\Money.txt";
            Reader reader = new Reader();
;
            ATM atm = new ATM();
            atm.toFill(reader.Read(FileName));

            using (StreamWriter writer = new StreamWriter(FileName, false))
            {
                foreach (Cassete cs in atm.list)
                { writer.Write(cs.ToString()); }      
            }

            int sum = 120; int max = 1000000000;

            atm.toSplitSum(sum, max);
 
        }
 
    }
}
