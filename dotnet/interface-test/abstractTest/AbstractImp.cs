using System;

namespace interface_test.abstractTest
{
    public class AbstractImp : AbstractBase
    {
        public override int MyAbstractInt { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void Foo()
        {
            Console.WriteLine("from abstract IMP");
        }
    }
}