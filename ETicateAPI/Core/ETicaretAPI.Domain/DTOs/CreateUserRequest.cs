using System;
namespace ETicaretAPI.Application.DTOs
{
	public class CreateUserRequest
	{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PhoneNumber { get; set; }

    }
}

