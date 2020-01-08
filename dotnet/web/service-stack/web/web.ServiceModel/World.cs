using ServiceStack;
using System;

namespace web.ServiceModel
{
    [Route("/world/{NewWorld}")]
    public class World : IReturn<WorldResponse>
    {
        public string NewWorld { get; set; }
    }

    public class WorldResponse
    {
        public string Result { get; set; }
    }
}
