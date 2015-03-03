using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class ATM
    {
       
        public List<Cassete> list = new List<Cassete>();

        public void Create(List<string> slist)
        {
            Banknote banknote = new Banknote();
            banknote.Name = " ";
            int count = 0;
           
            foreach (string cs in slist)
            {
                string[] split = cs.Split(' ');

                banknote.Name = split[0];
                count = Convert.ToInt32(split[1]);

                Cassete cassete = new Cassete(banknote.Name, count);

                list.Add(cassete);
            }
        }

        private int numOfb1 = 0;
        private int numOfb2 = 0;
        private int numOfb3 = 0;

        public int[] distributionOfBanknotes(int sum)
        {
            int s1 = sum;
            int[] num = new int [0];
            while (s1 != 0)
            {
                if (s1 % 50000 == 0)
                {
                    numOfb1++; s1 -= 50000; 
                }
            }
            while (sum >= 200000)
            { if (numOfb1 > 4 && list[2].Count != 0) { numOfb3++; numOfb1 -= 4; sum -= 200000; } else if (list[2].Count == 0 && list[1].Count != 0) { numOfb2++; numOfb1 -= 2; sum -= 100000; } else if (list[0].Count != 0) { sum = 0; } else { sum = 0; numOfb1 = 0; Console.WriteLine("Error!"); } }

            while (sum >= 100000)
            { if (numOfb1 >= 2 && list[1].Count != 0) { numOfb2++; numOfb1 -= 2; sum -= 100000; } else if (list[1].Count == 0 && list[0].Count != 0) { sum = 0; } else { sum = 0; Console.WriteLine("Error!"); } }
             list[2].Count -= numOfb3; list[1].Count -= numOfb2; list[0].Count -= numOfb1;

            Console.WriteLine(list[0].banknote.Name + " " + numOfb1.ToString() +  '\n' +list[1].banknote.Name + " " + numOfb2.ToString() + '\n' + list[1].banknote.Name +" " + numOfb3.ToString());
           
            return num;
        }
    }
}
