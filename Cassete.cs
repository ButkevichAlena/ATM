using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class Cassete: IComparable
    {
        public Banknote banknote = new Banknote();
        public int Count { get; set; }

        public Cassete(string b, int count)
        {
            banknote.Nominal = Convert.ToInt32(b);
            Count = count;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
           Cassete otherCassete = obj as Cassete;
           if (otherCassete != null)
               return this.banknote.Nominal.CompareTo(otherCassete.banknote.Nominal);
           else { return -1; }
        }

        public override string ToString()
        {
            return banknote.Nominal + " - " + Count + " ";
        }
    }
}
