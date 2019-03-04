using System;
using System.IO;
using ServiceStack;
using web.ServiceModel;
using Microsoft.AspNetCore;

namespace web.ServiceInterface
{
    public class ConverterService : Service
    {
        private readonly ITestService _testService;
        private readonly IZipUtils _zipUtils;

        public ConverterService(ITestService testService)
        {
            _testService = testService;
            // _zipUtils = zipUtils;
        }

        // [AddHeader(ContentType=MimeTypes.Json)]
        public Stream Post(ConverterRequest request)
        {
            base.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{request.File}\";");
            using (var zipUtils = new ZipUtils())
            {
                zipUtils.UnzipInput(_testService.GetStream(Request));
                zipUtils.ZipOutput();
                var w = _testService.Add(2, 3);
                return zipUtils.GetResult();
            }
        }

        //[AddHeader(ContentType = MimeTypes.Binary)]
        public object Get(ConverterRequest request)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.WriteLine("service stack");
            sw.Flush();
            ms.Position = 0;

            // base.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{request.Name}\";");

            return new FileStreamResult(ms, request.File);
            // return ms;
        }
    }
}

// public object Get(DownloadRequest request)
//         {
//             //Get reference to blob that contains the requested object
//             var blob = azureBlobContainer.GetBlockBlobReference(request.FileName);
//             MemoryStream return_stream = new MemoryStream();
//             blob.DownloadToStream(return_stream);
//             return_stream.Position = 0L;
//             return new FileStreamResult(return_stream, request.FileName);
//         }