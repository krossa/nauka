namespace patterns.cor.models
{
    public class BikeModel : IVehicleModel
    {
        public bool HasEngine { get; set; }
        public int Wheels { get; set; }
        public bool CanFloat { get; set; }
    }
}