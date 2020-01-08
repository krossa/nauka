using System;

namespace interface_test.virtualTest
{
    public class VirtualBase
    {
        public virtual void Bar()
        {
            Console.WriteLine("BAR virtual imp");
        }

        public virtual void Foo()
        {
            Console.WriteLine("FOO virtual imp");
        }
    }
}