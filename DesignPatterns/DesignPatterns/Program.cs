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
            IBeverage cappuccino = new CappuccinoBeverage();
            IBeverage soyMochaCappuccino = new SoyBeverageDecorator((new MochaBeverageDecorator(cappuccino)));
            
            Console.WriteLine(soyMochaCappuccino.GetDescription());
            Console.WriteLine("Cost of the Soy Mocha Cappuccino is " + soyMochaCappuccino.GetCost());
            
            MenuCompositeComponent.TestCompositePattern();
            Console.ReadLine();
        }
    }
}
