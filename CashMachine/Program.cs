using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.AutomateTeller();
            Console.ReadLine();
        }
    }
}
