using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    interface IAmLanguage
    {
        string AskForSum { get; }

        string AnswerOfATM (ATMState state);

        string AskForContinueOrExit { get; }
    }
}
