using System;
using System.Threading;
using System.Threading.Tasks;
using patterns.Cqs.Requests;
using patterns.Cqs.Result;

namespace patterns.Cqs.Services
{
    public class GetUserQuery : IRequest<User>
    {
        public string Name { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<Result<User>> HandleAsync(GetUserQuery query, CancellationToken cancellation = default)
        {
            Console.WriteLine(query.Name);
            return query.Name == "error" ?
             ResultHelper.FailAsync<User>(new Error("message")) :
             ResultHelper.OkAsync(new User { Name = query.Name });
        }
    }
}