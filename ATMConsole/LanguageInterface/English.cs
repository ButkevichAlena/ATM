using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary;

namespace LanguageInterface
{
    public class English : IAmLanguage
    {
        private string sum = "Input sum";

        public string AskForSum
        {
            get
            {
                return sum;
            }
        }

        private Dictionary<ATMState, string> stateMap = new Dictionary<ATMState, string>() 
        {
            {ATMState.Ok, "Get money"}, 
            {ATMState.ImpossibleToCollectSum, "Impossible to collect this sum" }, 
            {ATMState.NotEnoughMoney, "It is not enough money"},
            {ATMState.IsNotValid, "Incorrect input"}
        };

        public string AnswerOfATM(ATMState state)
        {
            return stateMap[state];
        }


        public string AskForContinueOrExit
        {
            get { return "Repeat??? (Esc - exit, Enter - continue)"; }
        }

        public string InvalidFormat
        {
            get
            {
                return "Invalid format of data.";
            }
        }
    }
}