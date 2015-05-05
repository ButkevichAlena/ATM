using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;

namespace ATMСonsole
{
    public class ATM
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ATM)); 

        public Money money = new Money();

        public List<Cassete> listOfCassete = new List<Cassete>();
        public List<Cassete> buferList = new List<Cassete>();
        public MoneyConverterToString converter;

        Algorithm algorithm = new Algorithm();

        int bufer = 10000000;
        int max = 100;

        public ATMState state { get; set; }
       
        public Money WithdrawnMoney(int sum)
        {
            if (sum <= 0) state = ATMState.IsNotValid;
            else if (IsValid(sum))
            {
                money = algorithm.GetMoney(sum, bufer, buferList, algorithm.SplitSum(sum, bufer, buferList, money), money);

                if (algorithm.summaryCount <= max)
                {
                    state = algorithm.state;
                }
                else state = ATMState.MoreThanMax;
                ChangeCassetes();
            }
            else state = ATMState.ImpossibleToCollectSum;

            log.Debug("Operation state is " + state.ToString());
            if (state == ATMState.Ok)
            {
                log.Debug("Withdrawn money: " + money.ToString());
            }
            log.Debug("Current state of cassettes: " + converter.ConvertMoneyInCassetes(listOfCassete));

            return money;
        }

        public bool IsValid(int sum)
        {
            
            bool isValid;

            isValid = algorithm.IsAlgorithmValid(sum, bufer, buferList);
            state = algorithm.state;

            return isValid;
        }

        public void ChangeCassetes()
        {
            if (buferList.Count != 0)
            {
                for (int j = 0; j < buferList.Count; j++)
                {
                    for (int k = 0; k < listOfCassete.Count; k++)
                    {
                        if (listOfCassete[k].banknote.Nominal == buferList[j].banknote.Nominal) { listOfCassete[k].Count = buferList[j].Count; } 
                    }

              }
            }

            listOfCassete.Sort();

            buferList.Clear();
            for (int g = 0; g < listOfCassete.Count; g++)
            {
                Cassete cassete = new Cassete(listOfCassete[g].banknote.Nominal.ToString(), listOfCassete[g].Count); buferList.Add(cassete);
            }
        }

        public void InsertCassete(List<Cassete> list)
        {
            this.listOfCassete = list;
            for (int i = 0; i < list.Count; i++)
            {
                Cassete cassete = new Cassete(list[i].banknote.Nominal.ToString(), list[i].Count); buferList.Add(cassete);
            }

            converter = new MoneyConverterToString();
            log.Debug("Insert cassettes: " + converter.ConvertMoneyInCassetes(list));
        }

        public bool CheckMax(int summaryCount)
        {
            bool flag = false;

            if (summaryCount > max) flag = true;
            return flag;
        }
    }
}
