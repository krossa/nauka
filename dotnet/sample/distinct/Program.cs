using System;
using System.Collections.Generic;
using System.Linq;

namespace distinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Test>();
            list.Add(new Test{ValI = 1, ValS= "s"});
            list.Add(new Test{ValI = 1, ValS= "s"});
            list.Add(new Test{ValI = 2, ValS= "s"});
            list.Add(new Test{ValI = 1, ValS= "t"});
            var result = list.Distinct();
        }
    }
}
