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
            { if(numOfb1 > 4){ numOfb3++; numOfb1 -= 4; sum -= 200000; } }
            Console.WriteLine(numOfb1);
            while (sum >= 100000)
            {if (numOfb1 >= 2) { numOfb2++; numOfb1 -= 2; sum -= 100000; } }
             list[2].Count -= numOfb3; list[1].Count -= numOfb2; list[0].Count -= numOfb1;

            Console.WriteLine(numOfb1.ToString() +  " " + numOfb2.ToString() + " " + numOfb3.ToString() );
            foreach (Cassete c in list)
            {
                Console.WriteLine(c.Count.ToString());
            }
           
            return num;
        }
    }
}
