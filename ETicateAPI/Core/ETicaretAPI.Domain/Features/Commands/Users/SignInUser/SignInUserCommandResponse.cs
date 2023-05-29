using System;
using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Features.Commands.Users.SignInUser
{
	public class SignInUserCommandResponse
    {

        public bool isSucceced { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}

