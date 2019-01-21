using System;

namespace interface_test.abstractTest
{
    public abstract class AbstractBase
    {
        public int MyInt { get; set; }
        public abstract int MyAbstractInt { get; set; }

        public void Bar()
        {
            Console.WriteLine("from abstract BASE");
        }
        public abstract void Foo();
    }
}