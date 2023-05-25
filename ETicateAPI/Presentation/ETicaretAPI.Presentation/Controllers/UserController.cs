using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Features.Commands.Users.CreateUser;
using ETicaretAPI.Application.Features.Commands.Users.SignInUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

