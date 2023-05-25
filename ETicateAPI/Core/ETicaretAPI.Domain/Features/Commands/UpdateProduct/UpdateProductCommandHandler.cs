using System;
using ETicaretAPI.Application.Repositories;
using ETicateAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
	{
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public UpdateProductCommandHandler(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _readRepository.GetById(request.Id);
            product.Id = request.Id;
            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            await _writeRepository.SaveAsync();
            return new UpdateProductCommandResponse();
        }
    }
}

