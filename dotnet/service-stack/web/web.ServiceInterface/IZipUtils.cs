using System.IO;
interface IZipUtils
{
    void CleanUpFolders();
    void SetUpFolders();
    void UnzipInput(Stream stream);
    void ZipOutput();

    Stream GetResult();
}