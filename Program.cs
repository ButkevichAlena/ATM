using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
 
        }
 
    }
}
