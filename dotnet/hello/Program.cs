using System;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo() { Name = "name" };
            Console.WriteLine(foo?.Name);
            foo = null;
            Console.WriteLine(foo?.Name);
            Console.WriteLine("Hello World!");
        }
    }

    class Foo
    {
        public string Name { get; set; }
    }
}
