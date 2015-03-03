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
            Reader reader = new Reader();
            reader.Read();
            ATM atm = new ATM();
            atm.Create(reader.Read());

            atm.distributionOfBanknotes(500000);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\NotePad.by\Desktop\Money.txt", false))
            {
                foreach (Cassete cs in atm.list)
                { writer.Write(cs.ToString()); }      
            }

 
        }
 
    }
}
