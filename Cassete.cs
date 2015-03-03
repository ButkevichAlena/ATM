using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class Cassete
    {
        public Banknote banknote = new Banknote();
        public int Count { get; set; }

        public Cassete(string b, int count)
        {
            banknote.Name = b;
            Count = count;
        }

        public override string ToString()
        {
            return banknote.Name + " " + Count;
        }
    }
}
