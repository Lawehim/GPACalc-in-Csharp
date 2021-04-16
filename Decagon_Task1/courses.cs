using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class MyClass
    {
            public static int ShiftedDiff(string first, string second)
            {
                if (first.Equals(second))
                 { 
                    return 0;
                } 
                for (int i = 0; i < first.Length; i++)
                {
                    string New =  first.Remove(first.Length-1) + first.Remove(0, first.Length-2);
                    if (New.Equals(second)) 
                        {
                            return i;  
                        }
                }
                return - 1;
            }  
  }
}

            

        public static void Main(string[] args)
        {
              //ShiftedDiff("coffee", "eecoff");
        }
    }
}