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
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("Welcome to Rick's Soda Machine!");
            Console.WriteLine("We have {0} Grape Sodas for {1:C2} each!", inventory.grapeSodas.Count, inventory.grapeSodas[0].price);
            Console.WriteLine("We have {0} Orange Sodas for {1:C2} each!", inventory.orangeSodas.Count, inventory.orangeSodas[0].price);
            Console.WriteLine("We have {0} Lemon Sodas for {1:C2} each!", inventory.lemonSodas.Count, inventory.lemonSodas[0].price);
            Console.WriteLine("The Cash Register has {0} Pennies!", cashRegister.pennies.Count);
            Console.WriteLine("The Cash Register has {0} Nickels!", cashRegister.nickels.Count);
            Console.WriteLine("The Cash Register has {0} Dimes!", cashRegister.dimes.Count);
            Console.WriteLine("The Cash Register has {0} Quarters!", cashRegister.quarters.Count);
            Console.WriteLine("-------------------------------\n");
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
            Console.WriteLine("You inserted {0:C2} into the Soda Machine!", coinValue);
            Console.WriteLine("You are attempting to purchase a {0} Soda!", soda.flavor);
            if ( coinValue < soda.price )
            {
                Console.WriteLine("Sorry, {0:C2} is not enough money to buy a {1} Soda!", coinValue, soda.flavor);
                Run();
            }
            else if ( coinValue > soda.price )
            {
                bool sodaInStock = inventory.CheckStock(soda);
                if ( sodaInStock )
                {
                    decimal changeValue = coinValue - soda.price;
                    if (cashRegister.Remove(changeValue))
                    {
                        inventory.Remove(soda);
                        cashRegister.Add(coins);
                        Console.WriteLine("Here is your {0} Soda!", soda.flavor);
                        Console.WriteLine("Your change is {0:C2}", changeValue);
                        Run();
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, we are all out of {0} Soda!", soda.flavor);
                    Run();
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
                    Console.WriteLine("Thank you for providing exact change!");
                    Run();
                }
                else
                {
                    Console.WriteLine("Sorry, we are all out of {0} Soda!", soda.flavor);
                    Run();
                }
            }
        }

    }
}
