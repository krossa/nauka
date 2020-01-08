using ServiceStack;
using System;

namespace web.ServiceModel
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public DateTime CurrentDate { get; set; }
        public string Result { get; set; }
    }
}
