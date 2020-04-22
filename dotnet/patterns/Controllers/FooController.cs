using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patterns.Services;

namespace patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;
        private readonly IConsoleLogger consoleLogger;

        public FooController(ILogger<FooController> logger, IConsoleLogger consoleLogger)
        {
            _logger = logger;
            this.consoleLogger = consoleLogger;
        }

        [HttpGet]
        public string Get()
        {
            var carOld = new Car.Builder(1234, "audi", "q7")
                .WithColor("red")
                .WithMileage(666)
                .WithVin("REWF426232626JK")
                .Build();
            _logger.LogInformation(carOld.Mileage.ToString());
            _logger.LogInformation(carOld.Vin);

            var car = CarBuilder.Start(1234, "audi", "q7")
                .WithColor("red")
                .WithMileage(666)
                .WithConsoleLogger(consoleLogger,1)
                .WithCarSumaryDecorator()
                .WithConsoleLogger(consoleLogger,2)
                .WithVin("REWF426232626JK")
                .Build();
            _logger.LogInformation(car.Mileage.ToString());
            _logger.LogInformation(car.Vin);
            return car.Summary();
        }
    }
}
