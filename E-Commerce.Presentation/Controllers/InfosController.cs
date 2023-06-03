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
    public class InfosController : ControllerBase
    {
        
    }
}
