using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ATMСonsole
{
    class Algorithm
    {
        public ATMState state = new ATMState();

        public int summaryCount;

        static readonly ILog log = LogManager.GetLogger(typeof(Algorithm)); 

        public int[] SplitSum(int sum, int bufer, List<Cassete> buferList, Money money)
        {
            log.Debug("Start to find more effective way to collect baknotes.");

            buferList.Sort();
            money.Banknotes.Clear();

            int[] F = new int[sum + 1];
            int m, i;

            for (m = 1; m <= sum; ++m)
            {
                F[m] = bufer + 1;
                for (i = 0; i < buferList.Count; ++i)
                {
                    if (m >= buferList[i].banknote.Nominal && F[m - buferList[i].banknote.Nominal] + 1 < F[m] && buferList[i].Count > 0)
                        F[m] = F[m - buferList[i].banknote.Nominal] + 1; 
                }
            }

            return F;
        }

        public Money GetMoney (int sum, int bufer, List<Cassete> buferlist, int[] F, Money money)
        {
            summaryCount = 0;
            int[] num = new int[buferlist.Count];
            for (int l = 0; l < buferlist.Count; l++)
            {
                num[l] = 1;
            }

            if (F[sum] == bufer + 1)
            {
                state = ATMState.NotEnoughMoney;
                log.Debug("Algorithm can't to collect requered sum");
            }
            else
            {
                state = ATMState.Ok;
                while (sum > 0)
                {
                    for (int i = 0; i < buferlist.Count; ++i)
                    {
                        if (F[sum - buferlist[i].banknote.Nominal] == F[sum] - 1)
                        {

                            if (!money.Banknotes.ContainsKey(buferlist[i].banknote))
                            { money.Banknotes.Add(buferlist[i].banknote, num[i]); }
                            else { money.Banknotes[buferlist[i].banknote] = num[i]; }

                            sum -= buferlist[i].banknote.Nominal; buferlist[i].Count--; num[i]++; summaryCount++;

                            break;
                        }
                    }
                }
            }
            log.Debug("Algorithm collected requered sum: " + money.ToString());
            return money;
        }

        public bool IsAlgorithmValid(int sum, int bufer, List<Cassete> buferlist)
        {
            bool flag = true;
            int[] F = new int[sum + 1];
            F[0] = 0;

            int m, i;
            for (m = 1; m <= sum; ++m)
            {
                F[m] = bufer + 1;
                for (i = 0; i < buferlist.Count; ++i)
                {
                    if (m >= buferlist[i].banknote.Nominal && F[m - buferlist[i].banknote.Nominal] + 1 < F[m] )
                        F[m] = F[m - buferlist[i].banknote.Nominal] + 1;
                }
            }

            if (F[sum] == bufer + 1) 
            {
                flag = false;
                state = ATMState.ImpossibleToCollectSum;
                log.Debug("Algorithm can't to collect requered sum");
            }
            return flag;
        }
    }
}
