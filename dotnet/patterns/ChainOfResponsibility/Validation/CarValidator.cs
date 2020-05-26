using System.Linq;
using patterns.cor.models;

namespace patterns.cor.validation
{
    public class CarValidator : IVehicleValidator
    {
        private readonly IVehicleValidator next;

        public CarValidator(IVehicleValidator next)
        {
            this.next = next;
        }

        public VehicleValidationResult Validate(IVehicleModel model)
        {
            if(!(model is CarModel))
                return next.Validate(model);

            var result = new VehicleValidationResult();
            if(model.Wheels != 4)
                result.Messages.Add("A car must have 4 wheels");
            if(!model.HasEngine)
                result.Messages.Add("A car must have an engine");
            result.IsValid = !result.Messages.Any();
            return result;
        }
    }
}