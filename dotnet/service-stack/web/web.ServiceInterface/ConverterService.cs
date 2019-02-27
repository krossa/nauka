using System;
using System.IO;
using System.Linq;
using ServiceStack;
using web.ServiceModel;

namespace web.ServiceInterface
{
    public class ConverterService : Service
    {
        private string _dir_path;
        private string _file_path;

        public ConverterService()
        {
            _dir_path = $"{Directory.GetCurrentDirectory()}/tmp";
            _file_path = $"{_dir_path}/tmp.txt";
        }

        // [AddHeader(ContentType=MimeTypes.Json)]
        public Stream Post(ConverterRequest request)
        {
            var ms = CreateStream(request);
            SetUpFolders();
            SaveFile(ms);
            var result = ReadFile();
            CleanUpFolders();

            base.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{request.File}\";");
            // return new FileStreamResult(return_stream, "file-name.txt");
            return result;
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

        private Stream CreateStream(ConverterRequest request)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);

            var stream = Request.InputStream;
            var msg = stream.ReadToEnd();

            sw.WriteLine(msg);
            sw.WriteLine(_dir_path);
            sw.WriteLine(request.Name);
            sw.WriteLine(request.File);
            sw.WriteLine(request.IsGood);
            sw.WriteLine("service stack");
            sw.Flush();
            ms.Position = 0;
            return ms;
        }

        private void SetUpFolders()
        {
            Directory.CreateDirectory(_dir_path);
        }

        private void CleanUpFolders()
        {
            Directory.Delete(_dir_path, true);
        }

        private void SaveFile(Stream stream)
        {
            var fs = new FileStream(_file_path, FileMode.Create);
            stream.CopyTo(fs);
            fs.Flush();
        }

        private Stream ReadFile()
        {
            var fs = new FileStream(_file_path, FileMode.Open);
            return fs;
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