using patterns.FluentBuilder;

namespace patterns.FluentDecorator
{
    public interface ICarBuilder
    {
        ICarBuilder WithTrim(string trim);

        ICarBuilder WithColor(string color);

        ICarBuilder WithMileage(int mileage);

        ICarBuilder WithVin(string vin);

        ICarBuilder WithCarSumaryDecorator();

        ICarBuilder WithConsoleLogger(IConsoleLogger logger, int number);

        ICar Build();
    }
}