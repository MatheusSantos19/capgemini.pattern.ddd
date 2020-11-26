using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsControl.Application.App.Interfaces;
using ProductsControl.Application.DTO;

namespace ProductsControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        public ProductsController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_productApplication.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateDTO product) {
            _productApplication.Post(product);
            return Created("/api/Products","Produto criado");
        }

    }
}
