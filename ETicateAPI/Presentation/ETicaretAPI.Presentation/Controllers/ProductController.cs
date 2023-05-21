using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels;
using ETicaretAPI.Persistance.Repositories;
using ETicateAPI.Domain.Entities;
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

        public ProductController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = _readRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Name,
                x.Price,
                x.Stock,
                x.CreatedTime
            });
            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(VM_Create_Product model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _writeRepository.AddAsync(product);
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(VM_Update_Product model)
        {
            Product product = await _readRepository.GetById(model.Id);
            product.Id = model.Id;
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            
            return Ok();
        }
        
    }
}

