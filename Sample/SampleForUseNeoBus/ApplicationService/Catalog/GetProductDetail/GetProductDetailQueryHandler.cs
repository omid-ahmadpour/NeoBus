using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SampleForUseNeoBus.ApplicationService.Catalog.GetProductDetail
{
    public class GetProductDetailQueryHandler : ICanHandleQuery<GetProductDetailQuery>
    {
        public async Task<CommandResult> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
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
