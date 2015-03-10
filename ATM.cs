using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class ATM
    {

        Money money = new Money();

        public List<Cassete> list = new List<Cassete>();

        public void toFill(List<string> slist)
        {
            Banknote banknote = new Banknote();
            banknote.Nominal = 0;
            int count = 0;

            foreach (string cs in slist)
            {
                string[] split = cs.Split(' ');

                banknote.Nominal = Convert.ToInt32(split[0]);
                count = Convert.ToInt32(split[1]);

                Cassete cassete = new Cassete(banknote.Nominal.ToString(), count);

                list.Add(cassete);
            }
        }

        public Money toSplitSum(int sum,  int max)
        {
            
            int[] F = new int[sum + 1];
            F[0] = 0;

            int m, i;
            for (m = 1; m <= sum; ++m)
            {
                F[m] = max;
                for (i = 0; i < list.Count; ++i)
                {
                    if (m >= list[i].banknote.Nominal && F[m - list[i].banknote.Nominal] + 1 < F[m])
                        F[m] = F[m - list[i].banknote.Nominal] + 1;
                }
            }

            int[] num = new int[list.Count];
            for (int l = 0; l < list.Count; l++)
            {
                num[l] = 1;
            }

            if (F[sum] == max)
                Console.WriteLine("Требуемую сумму выдать невозможно");
            else
            {
                while (sum > 0)
                {
                    for (i = 0; i < list.Count; ++i)
                    {
                        if (F[sum - list[i].banknote.Nominal] == F[sum] - 1)
                        {
                            if (!money.Banknotes.ContainsKey(list[i].banknote))
                            { money.Banknotes.Add(list[i].banknote, num[i]); }
                            else { money.Banknotes[list[i].banknote] = num[i]; }
                            
                            sum -= list[i].banknote.Nominal; num[i]++;
                            break;
                        }
                    }
                }
            }

            return money;
        }

        public void toGiveMoney()
        {
            foreach (KeyValuePair<Banknote, int> i in money.Banknotes)
            {
                Console.WriteLine(i.Key.Nominal + "\t" + i.Value);
            }
        }
    }
}
