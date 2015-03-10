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
            string FileName = @"C:\Users\NotePad.by\Desktop\Money.txt";
            Reader reader = new Reader();
;
            ATM atm = new ATM();
            atm.toFill(reader.Read(FileName));

            int sum = 540; int max = 1000000000;

            atm.toSplitSum(sum, max);

            atm.toGiveMoney();

            atm.writeToFile(FileName);
 
        }
 
    }
}
