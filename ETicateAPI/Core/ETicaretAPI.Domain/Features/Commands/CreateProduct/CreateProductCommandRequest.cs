using System;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.CreateProduct
{
	public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}

