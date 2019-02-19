using System;
using System.Collections.Generic;
using interface_test.abstractTest;
using interface_test.set_test;
using interface_test.virtualTest;

namespace interface_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Space("INTERFACE");
            var all = new All();
            var consume = new Consume(all, all);
            consume.Bar();
            consume.Foo();

            Space("ABSTRACT");
            var abst = new AbstractImp();
            abst.Bar();
            abst.Foo();

            Space("VIRTUAL");
            var virBase = new VirtualBase();
            var virImp = new VirtualImp();
            virBase.Bar();
            virBase.Foo();
            virImp.Bar();
            virImp.Foo();

            Space("SET");
            var setTest = new SetTest(3, 1, 2, 2);
            setTest.Print();

            Space("FIBIONACCI 1");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(FibonacciSeries(i));
            }

            Space("FIBIONACCI 2");
            FibonacciRecursive();
            Console.WriteLine("");
            FibonacciRecursive(3,5,7,10);
            Console.WriteLine("");
        }

        private static void Space(string text)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(text);
        }

        #region fibionacci
        public static int FibonacciSeries(int n)
        {
            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   
            return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }

        public static void FibonacciRecursive(int firstnumber = 0, int secondnumber = 1, int counter = 1, int length = 10)
        {
            if (counter <= length)
            {
                Console.Write("{0} ", firstnumber);
                FibonacciRecursive(secondnumber, firstnumber + secondnumber, counter + 1, length);
            }
        }
        #endregion
    }
}
