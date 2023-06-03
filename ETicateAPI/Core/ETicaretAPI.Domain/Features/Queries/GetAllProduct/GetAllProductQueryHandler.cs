using System;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ETicaretAPI.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {     
        private readonly IProductReadRepository _readRepository;
        private readonly ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler( IProductReadRepository readRepository, ILogger<GetAllProductQueryHandler> logger)
        {
            
            _readRepository = readRepository;
            _logger = logger;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _readRepository.GetAll();
            _logger.LogInformation("List Product");
           
           
            return new GetAllProductQueryResponse()
            {
                Products = products
            };
           


        }
    }
}

