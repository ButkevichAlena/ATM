using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMСonsole
{
    class Reader
    {
        List<string> lt = new List<string>();

        public List<string> Read()
        {
            StreamReader file = new StreamReader(@"C:\Users\NotePad.by\Desktop\Money.txt");

            string line;
            List<string> lt = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                lt.Add(line);
            }

            file.Close();
            return lt;
        }

    }
}
