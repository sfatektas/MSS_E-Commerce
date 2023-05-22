using E_Commerce.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class UsersController : ControllerBase
    {
        readonly ISupplierService _supplierService;
        readonly ICustomerService _customerService;
        readonly IAppUserService _appUserService;
        readonly IFavoriteProductService _favoriteProductService;

        public UsersController(ISupplierService supplierService, ICustomerService customerService, IAppUserService appUserService, IFavoriteProductService favoriteProductService)
        {
            _supplierService = supplierService;
            _customerService = customerService;
            _appUserService = appUserService;
            _favoriteProductService = favoriteProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string userType)
        { 
            if(userType == null) 
                throw new ArgumentNullException(nameof(userType) + "Parametresi bulunamadı.");
            else if (userType.ToLower() == "customer")
            {
                var data = await _customerService.GetAllCustomerAsync();
                return Ok(data);
            }
            else if (userType.ToLower() == "supplier")
            {
                var data = await _supplierService.GetAllSupplierAsync();
                return Ok(data);
            }
            else
                throw new ArgumentException(nameof(userType) + "Yanlış parametre kullanımı.");

        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromQuery] bool status)
        {
            await _appUserService.ChangeStatusUser(id, status);
            return NoContent();
        }
        [HttpGet("{userId:int}/favoriteproducts")]
        public async Task<IActionResult> GetFavoriteProductsFromUserId(int userid)
        {
            return Ok();
        } 
        [HttpPost("{userId:int}/favoriteproducts/{productInStockId:int}")]
        public async Task<IActionResult> AddFavoriteProduct(int userid , int productInStockId)
        {
            await _favoriteProductService.AddFavoriteProduct(userid, productInStockId);
            return StatusCode(201);
        }
    }
}
