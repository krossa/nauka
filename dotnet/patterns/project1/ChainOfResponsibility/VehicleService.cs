using Microsoft.Extensions.Logging;
using patterns.cor.models;
using patterns.cor.validation;

namespace patterns.cor
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleValidator validator;
        private readonly ILogger logger;

        public VehicleService(IVehicleValidator validator, ILogger<VehicleService> logger)
        {
            this.validator = validator;
            this.logger = logger;
        }

        public void InsertVehicleModel(IVehicleModel model)
        {
            var validationResult = validator.Validate(model);
            if(!validationResult.IsValid)
            {
                logger.LogInformation(validationResult.ToString());
                return;
            }
            logger.LogInformation("vehicle inserted");
        }
    }
}