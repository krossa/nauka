using System;

namespace interface_test
{
    class Consume
    {
        private IBar bar;
        private IFoo foo;
        public Consume(IBar bar, IFoo foo)
        {
            this.bar = bar;
            this.foo = foo;
        }

        public void Bar()
        {
            bar.Execute();
            bar.LowCommon();
            bar.MakeBar();
        }

        public void Foo()
        {
            foo.Execute();
            foo.LowCommon();
            foo.MakeFoo();
        }

    }
}