using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            List<Coin> myMoney = new List<Coin>();
            myMoney.Add(new Quarter());
            myMoney.Add(new Quarter());
            myMoney.Add(new Nickel());
            sodaMachine.MakeTransaction(myMoney, new LemonSoda());
            Console.ReadKey();
        }
    }
}
