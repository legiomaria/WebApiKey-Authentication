using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Demo.Dtos.Product;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductApiController> _logger;
        public ProductApiController(
            IProductService productService,
            ILogger<ProductApiController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Product>> GetProducts()
        {
            _logger.LogInformation("Executing GetProducts");
            return _productService.GetProducts();
        }

        [HttpGet]
        [Route("getbyid/{productId}")]
        public ActionResult<Product> GetProduct(string productId)
        {
            _logger.LogInformation("Executing GetProduct");
            if(_productService.IsExist(productId))
            {
                return NotFound($"Product Id { productId } not found");
            }
            else
            {
                return Ok(_productService.GetProduct(productId));
            }
            
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Product> AddProduct(
            [FromBody]CreateProductRequest productReq)
        {
            _logger.LogInformation("Executing AddProduct");

            if(!ModelState.IsValid)
            {
                BadRequest();
            }

            var newProduct = new Product()
            {
                Name = productReq.Name,
                Price = productReq.Price,
                Description = productReq.Description,
                Id = productReq.Id

            };
            
            var created = _productService.Add(newProduct);
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Product> UpdateProduct([FromBody]Product product)
        {
            _logger.LogInformation("Executing UpdateProduct");
            return _productService.Update(product);
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public ActionResult<bool> DeleteProduct(string productId)
        {
            _logger.LogInformation("Executing DeleteProduct");

            if(_productService.IsExist(productId))
            {
               return NotFound($"Product Id { productId } not found");
            }
            else
            {
               return Ok(_productService.Delete(productId));
            }
            
            
        }
    }
}