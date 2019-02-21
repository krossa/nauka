using System;
using System.IO;
using System.Linq;
using ServiceStack;
using web.ServiceModel;

namespace web.ServiceInterface
{
    public class ConverterService : Service
    {
        // [AddHeader(ContentType=MimeTypes.Json)]
        public Stream Post(ConverterRequest request)
        {
            var tt = new MemoryStream();

            var swt = new StreamWriter(tt);
            var srt = new StreamReader(tt);

            swt.WriteLine("data");
            swt.WriteLine("data 2");
            tt.Position = 0;

            var dd = srt.ReadToEnd();




            //Get the file stream from request
            var stream = Request.InputStream;
            var msg = stream.ReadToEnd();
            // var file = Request.Files.First();
            // return new ConverterResponse() { Result = msg };

            var ms = new MemoryStream();

            var sw = new StreamWriter(ms);
            sw.WriteLine(msg);
            sw.WriteLine("service stack");

            ms.Position = 0;
            var sr = new StreamReader(ms);
            var f = sr.ReadToEnd();

            var a = ms.ReadToEnd();
            ms.Position = 0;
            var b = ms.ReadToEnd();
            ms.Position = 0;

            // return new FileStreamResult(return_stream, "file-name.txt");
            return ms;
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