using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using ATMLibrary;
using LanguageInterface;

namespace ATMСonsole
{
    class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static string FileName = "D:\\money.txt";

        static void Main(string[] args)
        {

            log4net.Config.XmlConfigurator.Configure();

            CasseteLoader casseteLoader = new CasseteLoader();

            English language = new English();

            ATMLibrary.ATM atm = new ATMLibrary.ATM();

            atm.InsertCassete(casseteLoader.Read(FileName));

            ATMState state;

            while (true)
            {
                Console.WriteLine(language.AskForSum);

                string s = Console.ReadLine();

                try
                {
                    int sum = Convert.ToInt32(s);

                    log.Info("Sum requered by the user: " + sum.ToString());

                    atm.WithdrawnMoney(sum);

                    state = atm.state;

                    Console.WriteLine(language.AnswerOfATM(state));

                    if (state == ATMState.Ok)
                    {
                        Money money = atm.money;
                        Console.WriteLine(money.ToString());
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(language.InvalidFormat);
                }

                Console.Write(language.AskForContinueOrExit);

                while (true)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Escape)
                    {
                        Console.WriteLine();
                        return;
                    }

                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }

                s = Console.ReadLine();
            }
        }
    }
}
