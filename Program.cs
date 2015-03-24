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
            FileProceess fileProcess = new FileProceess();
                       
            ATM atm = new ATM();
                      
            atm.list = fileProcess.Read(FileName);

            for (int i = 0; i < atm.list.Count; i++)
            {
                Cassete cassete = new Cassete(atm.list[i].banknote.Nominal.ToString(), atm.list[i].Count); atm.buferList.Add(cassete);
            }

            bool flag = false; int max = 1000000;

            while (flag != true)
             {
                 Console.WriteLine("Input sum");

                 string s = Console.ReadLine();

                 int sum = Convert.ToInt32(s);

                 if (atm.IsValid(sum, max))
                 {
                     atm.WithdrawMoney(sum, max);

                     while (!atm.Check(sum, max)) { atm.WithdrawMoney(sum, max); }

                     if (atm.error == ErrorType.NotEnoughMoney) Console.WriteLine("Недостаточно купюр");

                     atm.ChangeCassetes(); Console.WriteLine(atm.money.ToString());

                 }

                 else if (atm.error == ErrorType.IsNotValid )Console.WriteLine("Невозможно выдать деньги");             

                 Console.WriteLine("Repeat??");

                 s = Console.ReadLine();

                 if (s == "yes") { flag = false; }

                 else flag = true;
             }

            fileProcess.writeToFile(FileName, atm.list);
         
        }
    }

         
}
