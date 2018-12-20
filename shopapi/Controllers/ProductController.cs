using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopapi.Models;

namespace shopapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var p = new Product[]
            {
                new Product{ Id = "p01", Name = "iPhone 6", Price = 100 },
                new Product{ Id = "p02", Name = "Samsung Galaxy", Price = 90 },
                new Product{ Id = "p03", Name = "Xiaomi Note 6 Pro", Price = 200 },
            };

            return p;
        }
    }
}
