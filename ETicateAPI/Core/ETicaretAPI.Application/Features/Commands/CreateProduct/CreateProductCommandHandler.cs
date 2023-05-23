using System;
using ETicaretAPI.Application.Repositories;
using ETicateAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _writeRepository;

        public CreateProductCommandHandler(IProductReadRepository readRepository,IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
         
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            await _writeRepository.AddAsync(product);
            await _writeRepository.SaveAsync();
            return new CreateProductCommandResponse();

           
        }
    }
}

