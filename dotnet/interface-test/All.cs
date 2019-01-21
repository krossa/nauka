using System;

namespace interface_test
{
    class All : IAll
    {
        public void Execute()
        {
            Console.WriteLine("EXECUTE");
        }

        public void LowCommon()
        {
           Console.WriteLine("LOW COMMON");
        }

        public void MakeBar()
        {
           Console.WriteLine("BAR");
        }

        public void MakeFoo()
        {
            Console.WriteLine("FOO");
        }
    }
}