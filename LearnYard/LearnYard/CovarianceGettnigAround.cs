using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnYard
{
    public class Animal
    {
    }

    public class Fish : Animal
    {
    }

    /*
     * C# doesn't allow this.
     * 
    abstract class Enclosure
    {
        public abstract Animal Contents();
    }
    class Aquarium : Enclosure
    {
        public override Fish Contents() { }
    }
    */

    /*
        Here is how you can get around this covariance restriction.
     *  So when you call enclosure.Contents() -> enclosure.GetContents()  -> <underlying aquarium>.GetContents() -> <underlying aquarium>.Contents().
     */

    abstract class Enclosure
    {
        protected abstract Animal GetContents();
        public Animal Contents() { return this.GetContents(); }
    }

    class Aquarium : Enclosure
    {
        protected override Animal GetContents() { return this.Contents(); }
        public new Fish Contents() { return new Fish(); }
    }
}
