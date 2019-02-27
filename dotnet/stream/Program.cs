using System;
using System.IO;

namespace stream
{
    class Program
    {
        static void Main(string[] args)
        {
            // var ms = new MemoryStream();
            // var sw = new StreamWriter(ms);
            // var sr = new StreamReader(ms);

            // sw.WriteLine("line one");
            // sw.WriteLine("line two");

            // ms.Position = 0;

            // Console.WriteLine(sr.ReadToEnd());


            using (var ms = new MemoryStream())
            {
                var sw = new StreamWriter(ms);
                var sr = new StreamReader(ms);

                try
                {
                    sw.WriteLine("data");
                    sw.WriteLine("data 2");
                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    Console.WriteLine(sr.ReadToEnd());
                }
                finally
                {
                    sw.Dispose();
                    sr.Dispose();

                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
