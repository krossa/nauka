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

        [HttpGet("/hello")]
        public string Hello()
        {
            Thread.Sleep(Delay);
            return "Hello";
        }

        [HttpGet("/hello-sync-over-async")]
        public string HelloSyncOverAsync()
        {
            Task.Delay(Delay).Wait();
            return "Hello";
        }

        [HttpGet("/hello-async-over-sync")]
        public async Task<string> HelloAsyncOverSync()
        {
            await Task.Run(() => Thread.Sleep(Delay));
            return "Hello";
        }

        [HttpGet("/hello-async")]
        public async Task<string> HelloAsync()
        {
            await Task.Delay(Delay);
            return "Hello";
        }
    }
}
