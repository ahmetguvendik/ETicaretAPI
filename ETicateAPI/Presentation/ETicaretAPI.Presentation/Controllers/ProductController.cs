using ETicaretAPI.Application.Features.Commands.CreateProduct;
using ETicaretAPI.Application.Features.Commands.DeleteProduct;
using ETicaretAPI.Application.Features.Commands.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
        
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var response =  await _mediator.Send(new GetAllProductQueryRequest());
           return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]DeleteProductCommandRequest model)
        {
            DeleteProductCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdProductQueryRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
      
        
    }
}

