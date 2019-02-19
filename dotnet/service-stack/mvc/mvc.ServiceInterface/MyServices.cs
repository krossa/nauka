using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Templates;
using ServiceStack.DataAnnotations;
using mvc.ServiceModel;

namespace mvc.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
