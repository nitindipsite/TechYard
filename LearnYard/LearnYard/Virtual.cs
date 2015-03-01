using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class SomeBaseClass
    {
        protected int a;
        protected int b;

        public virtual void IncrementAVirtual()
        {
            a = a + 1;
        }

        public void IncrementB()
        {
            b = b + 1;
        }
    }

    public class SomeDerivedClass : SomeBaseClass
    {

        public override void IncrementAVirtual()
        {
            a = a + 2;
        }

        public new void IncrementB()
        {
            b = b + 2;
        }


    }
}
