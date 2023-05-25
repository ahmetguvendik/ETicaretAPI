using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Users.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{		
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordConfirm { get; set; }
		public string PhoneNumber { get; set; }	

	}
}

