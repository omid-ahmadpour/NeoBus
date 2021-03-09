using NeoBus.MessageBus.Abstractions;
using SampleForUseNeoBus.ApplicationService.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.QueryHandlers
{
    public class GetProductQueryHandler : ICanHandleQuery<GetProductQuery>
    {
        public Task<GetProductQuery> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
