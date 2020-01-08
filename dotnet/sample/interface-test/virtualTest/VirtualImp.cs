using System;

namespace interface_test.virtualTest
{
    public class VirtualImp : VirtualBase
    {
        public override void Bar()
        {
            Console.WriteLine("BAR override imp");
        }
    }
}