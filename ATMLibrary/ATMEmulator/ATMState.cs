using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Emulator
{
    public enum ATMState
    {
        Ok,
        IsNotValid,
        NotEnoughMoney,
        MoreThanMax,
        ImpossibleToCollectSum
    }
}
