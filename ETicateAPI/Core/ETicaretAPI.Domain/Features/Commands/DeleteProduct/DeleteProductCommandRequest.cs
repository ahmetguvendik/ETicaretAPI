using System;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.DeleteProduct
{
	public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
	{
		public int Id { get; set; }	
	}
}

