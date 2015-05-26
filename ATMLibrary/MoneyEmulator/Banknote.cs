using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.MoneyEmulator
{
    public class Banknote
    {
        public int Nominal { get; set; }

        public override string ToString()
        {
            string s = Nominal.ToString();
            return s;
        }
    }
}
