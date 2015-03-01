using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    public class MyAbstract
    {
        // It wouldn't make sense to make an abstract class sealed because abstract class must be derived as it can't be instantiated
        // and a sealed class prevents derivation. Similarly it can't be marked static.
        abstract class WashingMachine
        {
            protected int a;

            public WashingMachine()
            {
                a = 1;
            }

            // Abstract methods cannot be private because they have to implemented by the dervied class.
            abstract public void Wash();
            abstract public void Rinse(int loadSize);
            abstract protected long Spin(int speed);
        }

        // If the class is implementing an abstract class, the abstract methods must be overriden because an abstract
        // method is implicitly virtual.
        class AsiaPacificWashingMachine : WashingMachine
        {
            public AsiaPacificWashingMachine()
            {
                a = 2;
            }

            public override void Wash()
            {
            }

            public override void Rinse(int loadSize)
            {
            }

            protected override long Spin(int speed)
            {
                return a;
            }
        }

        class NzWashingMachine : AsiaPacificWashingMachine
        {
            public NzWashingMachine()
            {
                a = 3;
            }

            public override void Wash()
            {
                a = 4;
                base.Wash();
            }

            // When sealed is applied to a class, you are preventing that class from being derived. 
            // When you apply to a method, you are trying to prevent derived classed from overriding this virtual method, so sealed must be used in conjection with override.
            public sealed override void Rinse(int loadSize)
            {
                a = 5;
                base.Rinse(loadSize);
            }
        }

        private class WellingtonWashingMachine : NzWashingMachine
        {
            public WellingtonWashingMachine()
            {
                a = 5;
            }

            public override void Wash()
            {
                a = 6;
                base.Wash();
            }

            // Because Rinse() was sealed in the base class, you can't override it and so we have broken virtual method invocation. You have to declare it as new and this is now a non-virtual method.
            public new  void Rinse(int loadSize)
            {
            }
        }


    }
}
