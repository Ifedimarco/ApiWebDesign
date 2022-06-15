using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractWebApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<string> Products = new List<string> { "Laptop", "Phone", "Car", "Perfume" };
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        [HttpGet]
        [Route("get-Products/{name}")]
        public IActionResult GetProducts(string name)
        {

            if (Products.Contains(name))
            {
                return Ok(name);
            }
            return NotFound("the name does not exist");
        }

        [HttpPost]
        [Route("Create-products/{name}")]
        public IActionResult CreateProducts(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("please provide the products name");
            }
            if (Products.Contains(name))
            {
                return BadRequest("the prducts name you provided is already existing");
            }
            Products.Add(name);
            return Ok(name);
        }

        [HttpGet]
        [Route("get-products-by-index/{index:int}")]
        public IActionResult GetProductsByIndex(int index)
        {
            if (index < 0 || index >= Products.Count)
            {
                return BadRequest("Index out of range, please Provide index that is within the range");
            }
            return Ok(Products[index]);
        }
    }
}
