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
        public Money money = new Money();

        public List<Cassete> list = new List<Cassete>();
        public List<Cassete> buferList = new List<Cassete>();

        Algorithm algorithm = new Algorithm();

        public ErrorType error { get; set; }
       
        public bool Check(int sum, int bufer)
        {
            bool flag = true;

            for (int i = 0; i < buferList.Count; ++i)
            {
                if (buferList[i].Count < 0) { buferList.Remove(buferList[i]); flag = false; }
            }
            return flag;
        }

        public Money WithdrawMoney(int sum, int bufer)
        {
            
            money = algorithm.GetMoney(sum, bufer, buferList, algorithm.SplitSum(sum, bufer, buferList, money), money);
            error = algorithm.error;
            return money;
        }

        public bool IsValid(int sum, int bufer)
        {
            
            bool f;

            f = algorithm.IsAlgorithmValid(sum, bufer, buferList);
            error = algorithm.error;

            return f;
        }

        public void ChangeCassetes()
        {
            if (buferList.Count != 0)
            {
                for (int j = 0; j < buferList.Count; j++)
                {
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[k].banknote.Nominal == buferList[j].banknote.Nominal) { string s = buferList[j].banknote.Nominal.ToString(); int cl = buferList[j].Count; Cassete c = new Cassete(s, cl); list.Remove(list[k]); list.Add(c); }
                    }

              }
            }

            list.Sort();

            buferList.Clear();
            for (int g = 0; g < list.Count; g++)
            {
                Cassete cassete = new Cassete(list[g].banknote.Nominal.ToString(), list[g].Count); buferList.Add(cassete);
            }
        }
    }
}
