using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using SampleForUseNeoBus.ApplicationService.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.QueryHandlers
{
    public class GetProductQueryHandler : ICanHandleQuery<GetProductQuery>
    {
        public async Task<CommandResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = "returned from query";
            var response = new CommandResult
            {
                Data = result
            };

            return response;
        }
    }
}
