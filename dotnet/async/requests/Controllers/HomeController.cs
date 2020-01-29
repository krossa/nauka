using System.Runtime.CompilerServices;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace requests.Controllers
{
public class HomeController : ControllerBase
    {
        const int Delay = 2000;

        //ab -n 100 -c 100 -k "http://localhost:5000/hello"
        [HttpGet("/hello")]
        public string Hello()
        {
            Thread.Sleep(Delay);
            return "Hello";
        }

        //ab -n 100 -c 100 -k "http://localhost:5000/hello-sync-over-async"
        [HttpGet("/hello-sync-over-async")]
        public string HelloSyncOverAsync()
        {
            Task.Delay(Delay).Wait();
            return "Hello";
        }

        //ab -n 100 -c 100 -k "http://localhost:5000/hello-async-over-sync"
        [HttpGet("/hello-async-over-sync")]
        public async Task<string> HelloAsyncOverSync()
        {
            await Task.Run(() => Thread.Sleep(Delay));
            return "Hello";
        }

        //ab -n 100 -c 100 -k "http://localhost:5000/hello-async"
        [HttpGet("/hello-async")]
        public async Task<string> HelloAsync()
        {
            await Task.Delay(Delay);
            return "Hello";
        }
    }
}
