using System;
using System.IO;
using System.IO.Compression;

namespace zip
{
    class Program
    {
        private static string _path;
        private static string _input_path;
        private static string _input_file;
        // private static string _input_folders;
        private static string _output_path;
        private static string _output_file;
        static void Main(string[] args)
        {
            Init();
            UsingZipFile();
            // UsingZipArchive();
        }

        private static void Init()
        {
            var directorySeparator = Path.DirectorySeparatorChar;
            // var pathSeparator = Path.PathSeparator;
            _path = Directory.GetCurrentDirectory();
            _input_path = $"{_path}{directorySeparator}input";
            _input_file = $"{_input_path}{directorySeparator}file.zip";
            // _input_folders = $"{_input_path}{directorySeparator}folder1{pathSeparator}{_input_path}{directorySeparator}folder2";
            _output_path = $"{_path}{directorySeparator}output";
            _output_file = $"{_output_path}{directorySeparator}output.zip";
            if (Directory.Exists(_output_path))
                Directory.Delete(_output_path, true);
            Directory.CreateDirectory(_output_path);
        }

        private static void UsingZipFile()
        {
            Console.WriteLine("ZipFile - Working with files");
            ZipFile.ExtractToDirectory(_input_file, _output_path);
            ZipFile.CreateFromDirectory(_input_path, _output_file);
        }

        private static void UsingZipArchive()
        {
            Console.WriteLine("ZipArchive - Working with stream");
            using (var fs = new FileStream(_input_file, FileMode.Open))
            {
                using (var za = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    za.ExtractToDirectory(_output_path);
                }
            }
        }
    }
}