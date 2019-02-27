using ServiceStack;
using System;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace web.ServiceModel
{

    [Route("/convert")]
    [Route("/convert/{Name}")]
    public class ConverterRequest : IReturn<FileStreamResult>
    {
        public string Name { get; set; }
        public string File { get; set; }
        public bool IsGood { get; set; }
    }

    public class ConverterResponse
    {
        public string Result { get; set; }
    }

    public class FileStreamResult// : IHasOptions, IStreamWriter
    {
        private readonly Stream _responseStream;
        public IDictionary<string, string> Options { get; private set; }

public Stream File { get{ return _responseStream;} }

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
