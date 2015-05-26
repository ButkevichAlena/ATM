using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.MoneyEmulator
{
    public class Money
    {
        public Dictionary<Banknote, int> Banknotes = new Dictionary<Banknote, int>();

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (KeyValuePair<Banknote, int> i in Banknotes)
            {
                s.Append(i.Key.Nominal.ToString() + " - " + i.Value.ToString() + '\t');
            }

            return s.ToString();
        }
    }
}
