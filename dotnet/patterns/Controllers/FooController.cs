using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patterns.command;
using patterns.cor;
using patterns.cor.models;
using patterns.cor.validation;
using patterns.Cqs;
using patterns.Cqs.Result;
using patterns.Cqs.Services;
using patterns.FluentBuilder;
using patterns.FluentDecorator;
using patterns.state;

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
        [Route("command")]
        public void Command()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
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
        [Route("state")]
        public void State()
        {
            Account account = new Account("Jane Doe");

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
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
