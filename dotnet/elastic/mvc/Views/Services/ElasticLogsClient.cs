using System;
using System.Collections.Generic;
using Nest;

public class ElasticLogsClient : IElasticLogsClient
{
    private ElasticClient _client;

    public ElasticLogsClient()
    {
        var settings = new ConnectionSettings(new Uri("https://ed59998547604d1aab118a756c773308.eu-central-1.aws.cloud.es.io:9243"))
                       .DefaultIndex("common_message_event")
                       .BasicAuthentication("elastic", "cOtZHUDWmA55SF1BrvNoLDCT");

        _client = new ElasticClient(settings);
    }

    public IEnumerable<Log> GetLogs(string type, string reference)
    {
        // var searchRequest = new SearchRequest<Log>
        // {
        //     Query = new Query<Log>();
        // };
        // if(!String.IsNullOrWhiteSpace(type))
        //     return _client.Search<Log>().Documents;

        var sd = new SearchDescriptor<Log>().Size(30);

        if (!String.IsNullOrWhiteSpace(type))
            sd.Query(q => q
                  .Match(m => m
                      .Field(f => f.Type)
                      .Query(type)
                  )
                );

        if (!String.IsNullOrWhiteSpace(reference))
            sd.Query(q => q
                  .Match(m => m
                      .Field(f => f.Reference)
                      .Query(reference)
                  )
                );
        return _client.Search<Log>(sd).Documents;
    }
}