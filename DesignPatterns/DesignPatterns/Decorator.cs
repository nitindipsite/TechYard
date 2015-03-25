using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IBeverage
    {
         String GetDescription();
        double GetCost();
    }

    public class LongBlackBeverage : IBeverage
    {
        public string GetDescription()
        {
            return "Long Black";
        }

        public double GetCost()
        {
            return 3.8;
        }
    }


    public class CappuccinoBeverage : IBeverage
    {
        public string GetDescription()
        {
            return "Cappuccino";
        }

        public double GetCost()
        {
            return 4.5;
        }
    }


    public class SoyBeverageDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        public SoyBeverageDecorator(IBeverage beverage)
        {
            this._beverage = beverage;
        }

        public string GetDescription()
        {
            return this._beverage.GetDescription() +  ", Soy";
        }

        public double GetCost()
        {
            return this._beverage.GetCost() + 1.0;
        }
    }

    public class MochaBeverageDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        public MochaBeverageDecorator(IBeverage beverage)
        {
            this._beverage = beverage;
        }

        public string GetDescription()
        {
            return this._beverage.GetDescription() + ", Mocha";
        }

        public double GetCost()
        {
            return this._beverage.GetCost() + 2.0;
        }
    }



}
