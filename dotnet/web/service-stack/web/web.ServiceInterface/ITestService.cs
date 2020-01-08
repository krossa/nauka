using System.IO;
using ServiceStack.Web;

namespace web.ServiceInterface
{
    public interface ITestService
    {
        Stream GetStream(IRequest request);

        int Add(int a, int b);
    }
}