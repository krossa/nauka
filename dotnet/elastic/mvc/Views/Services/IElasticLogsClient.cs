using System.Collections.Generic;

public interface IElasticLogsClient
{
    IEnumerable<Log> GetLogs(string type, string reference);
}