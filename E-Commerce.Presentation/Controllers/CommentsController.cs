using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        [HttpGet("{supplierid:int}/{productid:int}")]
        public async Task<IActionResult> GetCommnets([FromRoute] int supplierid, int productid)
        {
            return Ok(new { supplierid, productid });
        }
        //TODO Müşteri yorum yaptığında satıcının puanının hesaplanması için ayrı bir servis üzerinden RabbitMQ veya redis kullanarak yorum hesaplanması yapılabilir ve müşteri yorumunun eklenmesini bir süre beklemez.
    }
}
