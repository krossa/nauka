using System;
using ServiceStack;
using QI.OneGate.FileAnonymizer.WebService.ServiceModel;

namespace QI.OneGate.FileAnonymizer.WebService.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
