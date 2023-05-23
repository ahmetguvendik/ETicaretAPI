using System;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.GetByIdProduct
{
	public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
	{
		public int Id { get; set; }
	}	
}

