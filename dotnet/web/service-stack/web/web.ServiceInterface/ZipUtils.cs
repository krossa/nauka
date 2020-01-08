using System;
using System.IO;
using System.IO.Compression;

namespace web.ServiceInterface
{

    public class ZipUtils : IZipUtils, IDisposable
    {
        private string _request_path;
        private string _input_path;
        private string _output_zip_file;
        public ZipUtils()
        {
            var dsc = Path.DirectorySeparatorChar;
            _request_path = $"{Directory.GetCurrentDirectory()}{dsc}temp{dsc}{Guid.NewGuid()}";
            _input_path = $"{_request_path}{dsc}input";
            _output_zip_file = $"{_request_path}/tmp.zip";
            SetUpFolders();
        }
        public void CleanUpFolders()
        {
            Directory.Delete(_request_path, true);
        }

        public void SetUpFolders()
        {
            Directory.CreateDirectory(_input_path);
        }

        public void UnzipInput(Stream stream)
        {
            using (var za = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                za.ExtractToDirectory(_input_path);
            }
        }

        public void ZipOutput()
        {
            ZipFile.CreateFromDirectory(_input_path, _output_zip_file);
        }

        public Stream GetResult() => new FileStream(_output_zip_file, FileMode.Open);

        public void Dispose()
        {
            CleanUpFolders();
        }
    }
}