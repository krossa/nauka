using System.Linq;
using patterns.cor.models;

namespace patterns.cor.validation
{
    public class BoatValidator : IVehicleValidator
    {
        private readonly IVehicleValidator next;

        public BoatValidator(IVehicleValidator next)
        {
            this.next = next;
        }

        public VehicleValidationResult Validate(IVehicleModel model)
        {
            if(!(model is BoatModel))
                return next.Validate(model);

            var result = new VehicleValidationResult();
            if(model.Wheels > 0)
                result.Messages.Add("A boat cannot have wheels");
            if(!model.CanFloat)
                result.Messages.Add("A boat must float");
            result.IsValid = !result.Messages.Any();
            return result;
        }
    }
}