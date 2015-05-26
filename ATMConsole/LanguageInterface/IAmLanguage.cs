using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary;

namespace LanguageInterface
{
    public interface IAmLanguage
    {
        string AskForSum { get; }

        string AnswerOfATM(ATMState state);

        string AskForContinueOrExit { get; }
    }
}
