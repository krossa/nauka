namespace patterns.Services
{
    public class ConsoleLoggerDecorator : ICar
    {
         ICar car;
         IConsoleLogger logger;
         int number;

        public ConsoleLoggerDecorator(ICar car, IConsoleLogger logger, int number)
        {
            this.car = car;
            this.logger = logger;
            this.number = number;
        }

        //required
        public int Year { get { return car.Year; } set { car.Year = value; } }
        public string Make { get { return car.Make; } set { car.Make = value; } }
        public string Model { get { return car.Model; } set { car.Model = value; } }
        //optional
        public string Trim { get { return car.Trim; } set { car.Trim = value; }}
        public string Color { get { return car.Color; } set { car.Color = value; }}
        public int Mileage { get { return car.Mileage; } set { car.Mileage = value; }}
        public string Vin { get { return car.Vin; } set { car.Vin = value; }}

        public string Summary()
        {
            logger.LogInformation($"{number} - LOGGER {Make}");
            return car.Summary();
        }
    }
}