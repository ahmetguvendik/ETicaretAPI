using System;
using ETicaretAPI.Application.Repositories;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest,DeleteProductCommandResponse>
	{
        private readonly IProductWriteRepository _writeRepository;


        public DeleteProductCommandHandler(IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;

        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new DeleteProductCommandResponse();
        }
    }
}

