﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMСonsole
{
    public class MoneyConverterToString
    {
       
        public string ConvertMoneyInCassetes(List<Cassete> list)
        {
            StringBuilder bufer = new StringBuilder();

            if( list.Count !=0 )
            foreach( Cassete cs in list )
            {
                bufer.Append(cs.ToString());
            }

            return bufer.ToString();
        }
    }
}
