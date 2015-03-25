using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JunkYard.E;

namespace IEnumerable
{
    class Delegated
    {
        private delegate bool ComparisonHander(int a, int b);

        public void Harness()
        {
            ComparisonHander lessComparisonHander = (int a, int b) => a < b;
            Func<int, int, bool> lessFunc = (int a, int b) => a < b;
        }

        
    }
}
