using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class AppUserService : IAppUserService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public AppUserService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task ChangeStatusUser(int id, bool isActive) // 
        {
            var user = await _uow.GetIdentityRepository<AppUser>().GetByFilterAsync(x=>x.Id== id);
            if (user == null)
                throw new AppUserNotFoundException();
            user.IsActive = isActive;
            _uow.GetIdentityRepository<AppUser>().Update(user);
            await _uow.SaveChangesAsync();
        }
    }
}
