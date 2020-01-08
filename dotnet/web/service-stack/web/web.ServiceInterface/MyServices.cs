using System;
using ServiceStack;
using web.ServiceModel;

namespace web.ServiceInterface
{
    public class MyServices : Service
    {
        // [AddHeader(ContentType=MimeTypes.Json)]
        public object Get(Hello request) =>
            new HelloResponse { CurrentDate = DateTime.Today, Result = $"XXXXX, {request.Name}!" };


        public object Get(World request) =>
            new WorldResponse { Result = $"New World is: {request.NewWorld}" };
    }
}
