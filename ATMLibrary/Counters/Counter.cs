using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary.MoneyEmulator;

namespace ATMLibrary.Couners

{
    public class Counter
    {
        private List<Money> WithdrawnMoney;

        int ToatalSum;

        public int TransactionNumber
        {
            get
            {
                return WithdrawnMoney.Count;
            }
        }

        public void AddMoney(Money withdrawnMoney)
        {
            if (withdrawnMoney != null)
            {
                WithdrawnMoney.Add(withdrawnMoney);
            }
        }

        public void CalculateSum (Money withdrawnMoney)
        {
            foreach (KeyValuePair<Banknote, int> i in withdrawnMoney.Banknotes)
            {
            ToatalSum += i.Key.Nominal;
            }
        }
    }
}
