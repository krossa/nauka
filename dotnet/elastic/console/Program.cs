using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(){1,2,3,4};
            list.ForEach(i=> Console.WriteLine(i));
            
            


            // var c = new HttpClient();
            // c.BaseAddress = new Uri("https://ed59998547604d1aab118a756c773308.eu-central-1.aws.cloud.es.io:9243");
            // var byteArray = Encoding.ASCII.GetBytes("elastic:cOtZHUDWmA55SF1BrvNoLDCT");
            // c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            // var r = c.GetAsync("/common_message_event/log/V0hb42kBVuzcJU4v73Jm").Result;

            var settings = new ConnectionSettings(new Uri("https://ed59998547604d1aab118a756c773308.eu-central-1.aws.cloud.es.io:9243"))
                       .DefaultIndex("common_message_event")
                       .BasicAuthentication("elastic", "cOtZHUDWmA55SF1BrvNoLDCT");

            var client = new ElasticClient(settings);
            var searchResponse = client.Search<Log>();
            // var searchResponse = client.LowLevel.Get<StringResponse>("common_message_event", "log", "V0hb42kBVuzcJU4v73Jm");

            var d = searchResponse.Documents.First();

            Console.WriteLine("asd");
            Console.WriteLine("Hello World!");
        }
    }

    internal class Log
    {
        public string Author { get; set; }
        [Text(Name = "logged_date")]
        public DateTime LoggedDate { get; set; }
        [Text(Name = "log_level")]
        public int LogLevel { get; set; }
        public string Message { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
    }
}
