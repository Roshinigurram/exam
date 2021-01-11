using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcforassessment.dependencyInjection
{
    public class Example : IExample
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
    }
}
