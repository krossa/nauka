//Builder pattern
using System.Text;

namespace patterns.FluentBuilder
{
    public class Car : ICar
    {
        public Car(int year, string make, string model)
        {
            Year = year;
            Make = make;
            Model = model;
        }

        //required
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        //optional
        public string Trim { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }

        public string Summary()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"year: {Year}");
            sb.AppendLine($"make: {Make}");
            sb.AppendLine($"model: {Model}");
            return sb.ToString();
        }

        public class Builder
        {
            private ICar car;

            public Builder(int year, string make, string model)
            {
                car = new Car(year, make, model);
            }

            public Builder WithTrim(string trim)
            {
                car.Trim = trim;
                return this;
            }

            public Builder WithColor(string color)
            {
                car.Color = color;
                return this;
            }

            public Builder WithMileage(int mileage)
            {
                car.Mileage = mileage;
                return this;
            }

            public Builder WithVin(string vin)
            {
                car.Vin = vin;
                return this;
            }

            public ICar Build()
            {
                return car;
            }
        }
    }
}