using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Features.Commands.CreateProduct;
using ETicaretAPI.Application.Features.Commands.DeleteProduct;
using ETicaretAPI.Application.Features.Commands.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.GetAllProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels;
using ETicaretAPI.Persistance.Repositories;
using ETicateAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;
        private readonly IMediator _mediator;

        public ProductController(IProductWriteRepository writeRepository, IProductReadRepository readRepository,IMediator mediator)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
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

      
        
    }
}

