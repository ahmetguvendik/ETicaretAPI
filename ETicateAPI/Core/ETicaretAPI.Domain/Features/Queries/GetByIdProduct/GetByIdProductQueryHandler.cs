using System;
using ETicaretAPI.Application.Repositories;
using ETicateAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _readRepository;

        public GetByIdProductQueryHandler(IProductReadRepository readRepository)
        {

            _readRepository = readRepository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _readRepository.GetById(request.Id);
            return new GetByIdProductQueryResponse()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}

