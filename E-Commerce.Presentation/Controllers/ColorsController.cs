using E_Commerce.Business.Interfaces;
using E_Commerce.RabbitMQProducer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;
        private readonly IMailProducer _mailProducer;
        public ColorsController(IColorService colorService, IMailProducer mailProducer)
        {
            _colorService = colorService;
            _mailProducer = mailProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColors()
        {
            var response = await _colorService.GetAllColor();
            //_mailProducer.SendToMailQueue(new()
            //{
            //    To = new List<string>() { "sfatektas55@gmail.com", "sfatektas@gmail.com" },
            //    Message = "Ekip bu bir deneme mailidir korkmayınız"
            //});
            return Ok(response.Data);
        }

        [HttpGet("{defination}")]
        public async Task<IActionResult> GetOneProduct(string defination)
        {
            var data = await _colorService.GetOneColor(defination);
            return Ok(data);
        }

    }
}
