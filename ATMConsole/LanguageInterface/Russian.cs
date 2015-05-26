using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary;

namespace LanguageInterface
{
    public class Russian: IAmLanguage
    {
        private string sum = "Введите сумму";

        public string AskForSum
        {
            get
            {
                return sum;
            }
        }

        private Dictionary<ATMState, string> stateMap = new Dictionary<ATMState, string>() 
        {
            {ATMState.Ok, "Заберите деньги"}, 
            {ATMState.ImpossibleToCollectSum, "Невозможно собрать запрашиваемую сумму" }, 
            {ATMState.NotEnoughMoney, "Недостаточно денег в банкомате"},
            {ATMState.IsNotValid, "Некорректно введена сумма."}
        };

        public string AnswerOfATM(ATMState state)
        {
            return stateMap[state];
        }

        public string AskForContinueOrExit
        {
            get
            {
                return "Продолжить??? (Esc - выйти, Enter - продолжить)";
            }
        }

        public string InvalidFormat
        {
            get
            {
                return "Неверный формат введенных данных.";
            }
        }
    }
}