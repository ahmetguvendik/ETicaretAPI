using System;
using ETicaretAPI.Application.Repositories;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {     
        private readonly IProductReadRepository _readRepository;

        public GetAllProductQueryHandler( IProductReadRepository readRepository)
        {
            
            _readRepository = readRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _readRepository.GetAll();
           
            return new GetAllProductQueryResponse()
            {
                Products = products
            };
           


        }
    }
}

