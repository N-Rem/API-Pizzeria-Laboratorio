using App.Models;
using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _services;
        public ProductController (ProductServices services)
        {
            _services = services;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }
        [HttpGet("getById{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_services.GetById(id));
        }

        [HttpPost("CreateProduct")]
        public IActionResult Create(ProductDto productDto)
        {
            _services.CreateProduct(productDto);
            return Ok();
        }

        [HttpPut("UpdateProduct{idProduct}")]
        public IActionResult Update([FromRoute] int idProduct, [FromBody] ProductDto productDto)
        {
            _services.UpdateProduct(idProduct, productDto);
            return Ok();
        }

        [HttpDelete("DeleteProdcut{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            _services.DeleteProduct(id);
            return Ok();
        }

    }
}
