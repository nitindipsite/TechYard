using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Beverage
    {
        public abstract String GetDescription();
        public abstract double GetCost();
    }

    public class LongBlack : Beverage
    {
        public override string GetDescription()
        {
            return "Long Black";
        }

        public override double GetCost()
        {
            return 3.8;
        }
    }


    public class Cappuccino : Beverage
    {
        public override string GetDescription()
        {
            return "Cappuccino";
        }

        public override double GetCost()
        {
            return 4.5;
        }
    }


    public abstract class Condiment : Beverage
    {
    }

    public class Soy : Condiment
    {
        private Beverage _beverage;

        public Soy(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string GetDescription()
        {
            return this._beverage.GetDescription() +  ", Soy";
        }

        public override double GetCost()
        {
            return this._beverage.GetCost() + 1.0;
        }
    }

    public class Mocha : Condiment
    {
        private Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string GetDescription()
        {
            return this._beverage.GetDescription() + ", Mocha";
        }

        public override double GetCost()
        {
            return this._beverage.GetCost() + 2.0;
        }
    }



}
