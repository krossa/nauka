namespace patterns.cor.models
{
    public class CarModel : IVehicleModel
    {
        public bool HasEngine { get; set; }
        public int Wheels { get; set; }
        public bool CanFloat { get; set; }
    }
}