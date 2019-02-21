using ServiceStack;
using System;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace web.ServiceModel
{

    [Route("/convert")]
    public class ConverterRequest : IReturn<Stream>
    {
    }

    public class ConverterResponse
    {
        public string Result { get; set; }
    }

    public class FileStreamResult //: IHasOptions, IStreamWriter
    {
        private readonly Stream _responseStream;
        public IDictionary<string, string> Options { get; private set; }

        public FileStreamResult(Stream responseStream, string fileName)
        {
            _responseStream = responseStream;
            Options = new Dictionary<string, string>
            {
                { "Content-Type", "application/octet-stream"},
                { "Content-Disposition", $"attachment; filename=\"{fileName}\";"}
            };
        }
    }
}
