using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Inventory
    {
        //member variables
        public List<Soda> grapeSodas;
        public List<Soda> orangeSodas;
        public List<Soda> lemonSodas;
        int initialStockAmount = 50;

        //constructor
        public Inventory()
        {
            grapeSodas = GetInitialStockOfFlavor(new GrapeSoda());
            orangeSodas = GetInitialStockOfFlavor(new OrangeSoda());
            lemonSodas = GetInitialStockOfFlavor(new LemonSoda());
        }

        //member methods
        List<Soda> GetInitialStockOfFlavor(Soda soda)
        {
            List<Soda> sodas = new List<Soda>();
            for (int i=0; i<initialStockAmount; i++)
            {
                sodas.Add(soda);
            }
            return sodas;
        }

        public void Remove(Soda soda)
        {
            switch(soda.flavor)
            {
                case ("Grape"):
                    grapeSodas.RemoveAt(0);
                    break;
                case ("Orange"):
                    orangeSodas.RemoveAt(0);
                    break;
                case ("Lemon"):
                    lemonSodas.RemoveAt(0);
                    break;
                default:
                    break;
            }
        }

        public bool CheckStock(Soda soda)
        {
            List<Soda> stockToCheck = new List<Soda>();
            switch (soda.flavor)
            {
                case ("Grape"):
                    stockToCheck = grapeSodas;
                    break;
                case ("Orange"):
                    stockToCheck = orangeSodas;
                    break;
                case ("Lemon"):
                    stockToCheck = lemonSodas;
                    break;
                default:
                    return false;
            }
            if ( stockToCheck.Count>0 )
            {
                return true;
            }
            return false;
        }
    }
}
