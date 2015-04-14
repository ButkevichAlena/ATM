using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATMСonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = @"C:\Users\NotePad.by\Desktop\Money.txt";
            CasseteLoader casseteLoader = new CasseteLoader();

            ATM atm = new ATM();
            Money money = new Money();

            atm.InsertCassete(casseteLoader.Read(FileName));
            bool flag = false;
            ErrorType state;

            while (flag != true)
            {
                Console.WriteLine("Input sum");

                string s = Console.ReadLine();

                try
                {
                    int sum = Convert.ToInt32(s);

                    CheckInput(sum);

                    atm.WithdrawMoney(sum);
                    
                    state = atm.error;

                    if (state == ErrorType.IsNotValid) Console.WriteLine("Invalid sum! Look through possible banknotes!");
                    else if (state == ErrorType.MoreThanMax) Console.WriteLine("More than max count of banknotes!");
                    else if (state == ErrorType.NotEnoughMoney) Console.WriteLine("Not enough money!");
                    else if (state == ErrorType.Ok)
                    {
                        money = atm.money;
                        Console.WriteLine(money.ToString());
                    }
                }

                catch (System.FormatException ex)
                {
                    Console.WriteLine("Error! Invalid format! Enter integer!");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error!" + e.Message);
                }
                Console.WriteLine("Repeat??");

                s = Console.ReadLine();

                if (s == "yes" || s == "Yes" || s == "YES") { flag = false; }

                else { flag = true; break; }
            }
        }

          /*  if (CheckMax(sum, max))
            {
                if (atm.IsValid(sum, max))
                {
                    atm.WithdrawMoney(sum, max);

                    if (atm.error == ErrorType.NotEnoughMoney)
                    {
                        state = ErrorType.NotEnoughMoney;
                    }
                    else
                    {
                        atm.ChangeCassetes();
                        money = atm.money;
                    }
                }
                else
                {
                    state = ErrorType.IsNotValid;
                }
            }
            else
            {
                state = ErrorType.NotEnoughMoney;
            }

            money = atm.WithdrawMoney1(sum);
            if (atm.State == ErrorType.Ok)
            {

            }
            else
            {
                // print error message
            }

        }*/

        static void CheckInput(int sum)
        {
            if (sum <= 0) throw new System.Exception("Incorrect input!");
        }
    }         
}
