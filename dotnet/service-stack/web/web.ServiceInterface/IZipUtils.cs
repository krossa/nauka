using System.IO;

namespace web.ServiceInterface
{
    public interface IZipUtils
    {
        void CleanUpFolders();
        void SetUpFolders();
        void UnzipInput(Stream stream);
        void ZipOutput();

        Stream GetResult();
    }
}