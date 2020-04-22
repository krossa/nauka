namespace patterns.Services
{
    public class CarBuilder : ICarBuilder
    {
        private ICar car;

        private CarBuilder(int year, string make, string model)
        {
            car = new Car(year, make, model);
        }

        public static ICarBuilder Start(int year, string make, string model)
        {
            return new CarBuilder(year, make, model);
        }

        public ICar Build()
        {
            return car;
        }

        ICarBuilder ICarBuilder.WithColor(string color)
        {
            car.Color = color;
            return this;
        }

        ICarBuilder ICarBuilder.WithMileage(int mileage)
        {
            car.Mileage = mileage;
            return this;
        }

        ICarBuilder ICarBuilder.WithTrim(string trim)
        {
            car.Trim = trim;
            return this;
        }

        ICarBuilder ICarBuilder.WithVin(string vin)
        {
            car.Vin = vin;
            return this;
        }

        ICarBuilder ICarBuilder.WithCarSumaryDecorator()
        {
            car = new CarSumaryDecorator(car);
            return this;
        }

        public ICarBuilder WithConsoleLogger(IConsoleLogger logger, int number)
        {
            car = new ConsoleLoggerDecorator(car, logger, number);
            return this;
        }
    }
}