using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class SodaMachine
    {
        //member variables
        CashRegister cashRegister;
        Inventory inventory;

        //constructor
        public SodaMachine()
        {
            cashRegister = new CashRegister();
            inventory = new Inventory();
        }

        //member methods
        public void Run()
        {

        }

        decimal GetCoinValue(List<Coin> coins)
        {
            decimal coinValue = 0;
            foreach (Coin coin in coins)
            {
                coinValue += coin.value;
            }
            return coinValue;
        }

        public void MakeTransaction(List<Coin> coins, Soda soda)
        {
            decimal coinValue = GetCoinValue(coins);
            if ( coinValue < soda.price )
            {
                Console.WriteLine("Sorry, {0:C2} is not enough money to buy a {1} Soda!", coinValue, soda.flavor);
            }
            else if ( coinValue > soda.price )
            {
                bool sodaInStock = inventory.CheckStock(soda);
                if ( sodaInStock )
                {
                    inventory.Remove(soda);
                    cashRegister.Add(coins);
                    decimal changeValue = coinValue - soda.price;
                    cashRegister.Remove(changeValue);
                    Console.WriteLine("Here is your {0} Soda!", soda.flavor);
                    Console.WriteLine("Your change is {0:C2}", changeValue);
                }
                else
                {
                    Console.WriteLine("Sorry, we are all out of {0} Soda!", soda.flavor);
                }
            }
            else
            {
                bool sodaInStock = inventory.CheckStock(soda);
                if (sodaInStock)
                {
                    inventory.Remove(soda);
                    cashRegister.Add(coins);
                    Console.WriteLine("Here is your {0} Soda!", soda.flavor);
                }
                else
                {
                    Console.WriteLine("Sorry, we are all out of {0} Soda!", soda.flavor);
                }
            }
        }

    }
}
