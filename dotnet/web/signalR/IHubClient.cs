using System.Threading.Tasks;

namespace signalR
{
    public interface IHubClient
    {
        Task InformClient(string message);
    }
}