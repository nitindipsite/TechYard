using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public struct StructExample
    {
        private int _value1;
        public int Value1 
        {
            get { return _value1; }

            set { _value1 = value; }
        }

        private int _value2;
        public int Value2
        {
            get { return _value2; }

            set { _value2 = value; }
        }

        // You cannot provide a default parameterless constructor. However you can provide a construct with parameters
        // and it must initialize all the fields. This is because C# compiler would ensure that when a new() is done on a struct
        // that all the fields are initialized. However, if we decide to provide our own construct, then it should initialize
        // all the fields.
        public StructExample(int val1, int val2)
        {
            _value1 = val1;
            _value2 = val2;
        }
    }

    // You can't derive a struct, it's sealed. However you can implement interfaces.
    //public struct StructExampleDerived : StructExample
    //{

    //}
}
