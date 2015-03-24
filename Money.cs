using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class Money
    {
        public Dictionary<Banknote, int> Banknotes = new Dictionary <Banknote, int>();

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (KeyValuePair<Banknote, int> i in Banknotes)
            {
               s.Append (i.Key.Nominal.ToString() + "\t" + i.Value.ToString() + '\n');
            }

            return s.ToString();
        }
    }
}
