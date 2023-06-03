using System;
using ETicaretAPI.Application.DTOs;
using ETicateAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Services
{
	public interface ITokenHandler
	{
		public Token CreateAccesToken(AppUser user);
	}
}

