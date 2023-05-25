using System;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Users.SignInUser
{
	public class SignInUserCommandRequest : IRequest<SignInUserCommandResponse>
	{
		public string UserNameOrEmail { get; set; }
		public string Password { get; set; }	
	}
}

