using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SizeService : ServiceRead<SizeListDto ,Size> ,ISizeService
    {
        readonly IMapper _mapper;

        public SizeService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _mapper = mapper;   
        }

        public async Task<IEnumerable<SizeListDto>> GetAllSize()
        {
             var data = await base.GetAllAsync();
            if (data == null)
                throw new SizeNotFoundException();
            return data;
        }

        public async Task<IEnumerable<SizeListDto>> GetAllSize(Expression<Func<Size, bool>> filter)
        {
            var data = await base.GetAllAsync(filter);
            if (data == null)
                throw new SizeNotFoundException();
            return data;
        }

        public Task<SizeListDto> GetOneSizeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SizeListDto> GetOneSizeAsync(Expression<Func<Size, bool>> filter)
        {
            var data = await base.GetOneAsync(filter);
            if (data == null)
                throw new SizeNotFoundException();
            return _mapper.Map<SizeListDto>(data);
        }
    }
}
