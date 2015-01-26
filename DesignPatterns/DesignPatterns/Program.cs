using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage cappuccino = new Cappuccino();
            Beverage soyMochaCappuccino = new Soy(new Mocha(cappuccino));
            
            Console.WriteLine(soyMochaCappuccino.GetDescription());
            Console.WriteLine("Cost of the Soy Mocha Cappuccino is " + soyMochaCappuccino.GetCost());
            Console.ReadLine();
        }
    }
}
