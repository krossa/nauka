namespace patterns.cor.models
{
    public interface IVehicleModel
    {
        bool HasEngine { get; set; }
        int Wheels { get; set; } 
        bool CanFloat { get; set; }
    }
}