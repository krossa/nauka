using patterns.cor.models;

namespace patterns.cor.validation
{
    public interface IVehicleValidator
    {
        VehicleValidationResult Validate(IVehicleModel model);
    }
}