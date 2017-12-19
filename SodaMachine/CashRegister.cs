using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class CashRegister
    {
        //member variables
        List<Coin> pennies;
        List<Coin> nickels;
        List<Coin> dimes;
        List<Coin> quarters;

        //constructor
        public CashRegister()
        {
            pennies = GetInitialCoins(new Penny(), 50);
            nickels = GetInitialCoins(new Nickel(), 20);
            dimes = GetInitialCoins(new Dime(), 10);
            quarters = GetInitialCoins(new Quarter(), 20);
        }

        //member methods
        List<Coin> GetInitialCoins(Coin coin, int numberOfCoins)
        {
            List<Coin> coins = new List<Coin>();
            for (int i=0; i<numberOfCoins; i++)
            {
                coins.Add(coin);
            }
            return coins;
        }

        public void Add(List<Coin> coins)
        {
            foreach (Coin coin in coins)
            {
                switch(coin.name)
                {
                    case ("Penny"):
                        pennies.Add(new Penny());
                        break;
                    case ("Nickel"):
                        pennies.Add(new Nickel());
                        break;
                    case ("Dime"):
                        pennies.Add(new Dime());
                        break;
                    case ("Quarter"):
                        pennies.Add(new Quarter());
                        break;
                    default:
                        break;
                }
            }
        }

        public void Remove(decimal changeValue)
        {

        }

    }
}
