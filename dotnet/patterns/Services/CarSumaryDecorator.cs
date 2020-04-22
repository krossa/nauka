using System.Text;

namespace patterns.Services
{
    public class CarSumaryDecorator : ICar
    {
        ICar car;

        public CarSumaryDecorator(ICar car)
        {
            this.car = car;
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
            var sb = new StringBuilder(car.Summary());
            sb.AppendLine($"trim: {Trim}");
            sb.AppendLine($"color: {Color}");
            sb.AppendLine($"mileage: {Mileage}");
            sb.AppendLine($"VIN: {Vin}");
            return sb.ToString();
        }
    }
}