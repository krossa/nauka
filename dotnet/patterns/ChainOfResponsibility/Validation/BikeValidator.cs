using System.Linq;
using patterns.cor.models;

namespace patterns.cor.validation
{
    public class BikeValidator : IVehicleValidator
    {
        private readonly IVehicleValidator next;

        public BikeValidator(IVehicleValidator next)
        {
            this.next = next;
        }

        public VehicleValidationResult Validate(IVehicleModel model)
        {
            if(!(model is BikeModel))
                return next.Validate(model);

            var result = new VehicleValidationResult();
            if(model.Wheels != 4)
                result.Messages.Add("A bike must have 2 wheels");
            if(model.HasEngine)
                result.Messages.Add("A bike cannot have an engine");
            result.IsValid = !result.Messages.Any();
            return result;
        }
    }
}