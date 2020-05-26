using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patterns.cor;
using patterns.cor.models;
using patterns.cor.validation;
using patterns.Cqs;
using patterns.Cqs.Result;
using patterns.Cqs.Services;
using patterns.FluentBuilder;
using patterns.FluentDecorator;

namespace patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;
        private readonly IConsoleLogger consoleLogger;
        private readonly IBus bus;

        public FooController(
            ILogger<FooController> logger,
             IConsoleLogger consoleLogger,
             IBus bus)
        {
            _logger = logger;
            this.consoleLogger = consoleLogger;
            this.bus = bus;
        }

        [HttpGet]
        [Route("builder")]
        public string Builder()
        {
            var car = new Car.Builder(1234, "audi", "q7")
                .WithColor("red")
                .WithMileage(666)
                .WithVin("REWF426232626JK")
                .Build();
            _logger.LogInformation(car.Mileage.ToString());
            _logger.LogInformation(car.Vin);

            return car.Summary();
        }

        [HttpGet]
        [Route("decorator")]
        public string Decorator()
        {
            var car = CarBuilder.Start(1234, "audi", "q7")
                .WithColor("red")
                .WithMileage(666)
                .WithConsoleLogger(consoleLogger, 1)
                .WithCarSumaryDecorator()
                .WithConsoleLogger(consoleLogger, 2)
                .WithVin("REWF426232626JK")
                .Build();
            _logger.LogInformation(car.Mileage.ToString());
            _logger.LogInformation(car.Vin);

            return car.Summary();
        }

        [HttpGet]
        [Route("cqs")]
        [Route("cqs/{name}")]
        public async Task<string> Cqs(string name = "RON")
        {
            var userQ = new GetUserQuery() { Name = name };

            var result = await bus.SendAsync(userQ);
            var res = result.Match(u => u, HandleError);
            return res?.Name;
        }

        [HttpGet]
        [Route("cor")]
        public void ChainOfResponsibility([FromServices] IVehicleService service)
        {
            var car = new CarModel
            {
                Wheels = 4,
                HasEngine = true
            };
            service.InsertVehicleModel(car);

            var boat = new BoatModel
            {
                Wheels = 3,
                CanFloat = false
            };
            service.InsertVehicleModel(boat);
        }

        private User HandleError(Error e)
        {
            _logger.LogInformation("ERROR HANDLER");
            _logger.LogError(e.Code.ToString());
            _logger.LogError(e.Message);
            return null;
        }
    }
}
