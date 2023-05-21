using E_Commerce.Business.Interfaces;
using E_Commerce.Dtos.ProductCommentDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/productınstocks/{productInStockId:int}/[controller]")]
    public class CommentsController : ControllerBase
    {
        readonly IProductCommentService _productCommentService;

        public CommentsController(IProductCommentService productCommentService)
        {
            _productCommentService = productCommentService;
        }

        //[HttpGet("{productInStockId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetComments([FromRoute] int productInStockId)
        {
            var comments =await _productCommentService.GetCommnets(productInStockId);
            return Ok(comments);
        }

        //[HttpPost("{productInStockId:int}")]
        [HttpPost]

        // Todo : validator yazılacak.
        public async Task<IActionResult> AddCommnet([FromBody] ProductCommentCreateDto dto)
        {
            await _productCommentService.AddComment(dto);
            return NoContent();
        }


        //TODO Müşteri yorum yaptığında satıcının puanının hesaplanması için ayrı bir servis üzerinden RabbitMQ veya redis kullanarak yorum hesaplanması yapılabilir ve müşteri yorumunun eklenmesini bir süre beklemez.
    }
}
