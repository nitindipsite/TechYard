using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class ConstructorChaining
    {
        public ConstructorChaining(int id, string description)
        {
            
        }

        public ConstructorChaining(): this(0, "")
        {
        }

        public ConstructorChaining(int id) : this(id, "")
        {
            
        }
    }

    public class DerivedConstructorChaining : ConstructorChaining
    {
        public DerivedConstructorChaining()
        {
            
        }
    }
}
