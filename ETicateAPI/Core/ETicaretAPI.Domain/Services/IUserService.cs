using System;
using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Services
{
	public interface IUserService
	{
		Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
	}
}

