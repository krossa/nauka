using patterns.cor.models;

namespace patterns.cor.validation
{
    public class NoResultValidator : IVehicleValidator
    {
        public VehicleValidationResult Validate(IVehicleModel model)
            => new NoResultVehicleValidationResult();
    }
}