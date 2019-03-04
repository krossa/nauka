using System.IO;
using ServiceStack.Web;

namespace web.ServiceInterface
{
    public class TestService : ITestService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public Stream GetStream(IRequest request)
        {
            return request.InputStream;
        }
    }
}