﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Kalem", Price = 20 });
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            return Ok(name);
        }

        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new { Status="Success"});
        }

        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
    }
}
