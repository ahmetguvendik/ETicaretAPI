using System;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.UpdateProduct
{
	public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}

