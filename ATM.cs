using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMСonsole
{
    public class ATM
    {

        public  Money money = new Money();

        public List<Cassete> list = new List<Cassete>();
        public List<Cassete> buferlist = new List<Cassete>();  
        
        public Money toSplitSum(int sum, int bufer)
        {
            buferlist.Sort();
            money.Banknotes.Clear();

            int[] F = new int[sum + 1];
            F[0] = 0;

            int m, i;
            for (m = 1; m <= sum; ++m)
            {
                F[m] = bufer + 1;
                for (i = 0; i < buferlist.Count; ++i)
                {
                    if (m >= buferlist[i].banknote.Nominal && F[m - buferlist[i].banknote.Nominal] + 1 < F[m] && buferlist[i].Count > 0)
                        F[m] = F[m - buferlist[i].banknote.Nominal] + 1;
                }
            }

            int[] num = new int[buferlist.Count];
            for (int l = 0; l < buferlist.Count; l++)
            {
                num[l] = 1;
            }

            if (F[sum] == bufer)
                Console.WriteLine("Требуемую сумму выдать невозможно");
            else if (F[sum] == bufer + 1)
            {
                Console.WriteLine("Недостаточно купюр в банкомате");
            }
            else
            {
                while (sum > 0)
                {
                    for (i = 0; i < buferlist.Count; ++i)
                    {
                        if (F[sum - buferlist[i].banknote.Nominal] == F[sum] - 1)
                        {

                            if (!money.Banknotes.ContainsKey(buferlist[i].banknote))
                            { money.Banknotes.Add(buferlist[i].banknote, num[i]); }
                            else { money.Banknotes[buferlist[i].banknote] = num[i]; }

                            sum -= buferlist[i].banknote.Nominal; buferlist[i].Count--; num[i]++;

                            break;
                        }
                    }
                }
            }
            return money;
        } 

        public bool Check(int sum, int bufer)
        {
            bool flag = true;

            for (int i = 0; i < buferlist.Count; ++i)
            {
                if (buferlist[i].Count < 0) { buferlist.Remove(buferlist[i]); flag = false;  } 
            }        
            return flag;
        }

        public void toGiveMoney()
        {
            if (buferlist.Count != 0)
            {
                for (int j = 0; j < buferlist.Count; j++)
                {
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[k].banknote.Nominal == buferlist[j].banknote.Nominal) { string s = buferlist[j].banknote.Nominal.ToString(); int cl = buferlist[j].Count; Cassete c = new Cassete(s, cl); list.Remove(list[k]); list.Add(c); } 
                    }

                }

            }
            
            foreach (KeyValuePair<Banknote, int> i in money.Banknotes)
            {
                Console.WriteLine(i.Key.Nominal + "\t" + i.Value);
            }

            list.Sort();

            buferlist.Clear();
            for (int g = 0; g < list.Count; g++)
            {
                Cassete cassete = new Cassete(list[g].banknote.Nominal.ToString(), list[g].Count); buferlist.Add(cassete);
            }
            
        }
    }
}
