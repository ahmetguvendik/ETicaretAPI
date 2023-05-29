using System;
using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Services
{
	public interface ITokenHandler
	{
		public Token CreateAccesToken();
	}
}

