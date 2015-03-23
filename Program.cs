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

            for (int g = 0; g < atm.list.Count; g++)
            {
                Cassete cassete = new Cassete(atm.list[g].banknote.Nominal.ToString(), atm.list[g].Count); atm.buferlist.Add(cassete);
            }

            bool flag = false; int max = 1000000;

            while (flag != true)
             {
                 Console.WriteLine("Input sum");

                 string s = Console.ReadLine();

                 int sum = Convert.ToInt32(s);

                 if (atm.IsValid(sum, max))
                 {
                     atm.toSplitSum(sum, max);

                     while (!atm.Check(sum, max)) { atm.toSplitSum(sum, max); }

                     atm.toGiveMoney();
                 }

                 else Console.WriteLine("Невозможно выдать деньги");

                 Console.WriteLine("Repeat??");

                 s = Console.ReadLine();

                 if (s == "yes") { flag = false; }

                 else flag = true;
             }

            fileProcess.writeToFile(FileName, atm.list);
         
        }
    }
         
        }
