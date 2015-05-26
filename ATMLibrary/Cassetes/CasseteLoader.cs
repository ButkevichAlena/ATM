using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ATMLibrary.MoneyEmulator;

namespace ATMLibrary.Cassetes
{
    public class CasseteLoader
    {
        public List<Cassete> Read(string FileName)
        {
            List<Cassete> newlist = new List<Cassete>();

            StreamReader file = new StreamReader(FileName);

            string line;
            List<string> list = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                list.Add(line);
            }

            Banknote banknote = new Banknote();
            banknote.Nominal = 0;
            int count = 0;

            foreach (string cs in list)
            {
                string[] split = cs.Split(' ');

                banknote.Nominal = Convert.ToInt32(split[0]);
                count = Convert.ToInt32(split[1]);

                Cassete cassete = new Cassete(banknote.Nominal.ToString(), count);
                Cassete newcassete = new Cassete(banknote.Nominal.ToString(), count);

                newlist.Add(cassete);
            }

            file.Close();

            return newlist;
        }
    }
}
