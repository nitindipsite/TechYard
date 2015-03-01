using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class CloseOverMe
    {
        public Func<int, int> GetFuncIncrementer()
        {
            int x = 1;
            return delegate (int y)
            {
                x = x + 1;
                y = y + x;
                return y;
            };
        }
    }
}
