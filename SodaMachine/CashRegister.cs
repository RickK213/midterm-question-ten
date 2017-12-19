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

        public bool Remove(decimal changeValue)
        {
            //TO DO: Refactor this smelly code
            int numberOfPennies = 0;
            int numberOfNickels = 0;
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int valueInPennies = (int)(changeValue * 100);
            List<char> valueList = valueInPennies.ToString().ToList();
            int[] valueArray = new int[valueList.Count];
            for (int i = 0; i < valueList.Count; i++)
            {
                valueArray[i] = Int32.Parse(valueList[i].ToString());
            }
            numberOfPennies = valueArray[valueArray.Length - 1] % 5;
            numberOfNickels = valueArray[valueArray.Length - 1] / 5;
            if (valueArray.Length > 1)
            {
                numberOfQuarters = valueArray[valueArray.Length - 2] * 10 / 25;
                if (valueInPennies > 100)
                {
                    numberOfQuarters += (valueInPennies / 100) * 4;
                }
                numberOfDimes = (valueInPennies - (numberOfQuarters * 25)) / 10;
            }
            if (pennies.Count < numberOfPennies)
            {
                Console.WriteLine("Sorry, not enough pennies to make change!");
                return false;
            }
            else
            {
                pennies.RemoveRange(0, numberOfPennies-1);
            }
            if (nickels.Count < numberOfNickels)
            {
                Console.WriteLine("Sorry, not enough nickels to make change!");
                return false;
            }
            else
            {
                nickels.RemoveRange(0, numberOfNickels-1);
            }
            if (dimes.Count < numberOfDimes)
            {
                Console.WriteLine("Sorry, not enough dimes to make change!");
                return false;
            }
            else
            {
                dimes.RemoveRange(0, numberOfDimes - 1);
            }
            if (quarters.Count < numberOfQuarters)
            {
                Console.WriteLine("Sorry, not enough quarters to make change!");
                return false;
            }
            else
            {
                quarters.RemoveRange(0, numberOfQuarters - 1);
            }
            return true;
        }

    }
}
