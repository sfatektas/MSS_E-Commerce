using AutoMapper;
using Azure;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Business.Models;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SliderItemService : Service<SliderItemCreateDto, SliderItemListDto, SliderItemUpdateDto, SliderItem>, ISliderItemService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;
        public SliderItemService(IUow uow, IMapper mapper, IValidator<SliderItemCreateDto> createValidator, IStorage storage) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _storage = storage;
        }
        public async Task<List<SliderItemListDto>> GetAllSliderItemAsync()
        {
            var sliderItems = await _uow.GetRepository<SliderItem>().
                GetQueryable()
                .Include(x => x.Slider)
                .ToListAsync();

            if (sliderItems == null)
                throw new SliderItemNotFoundException();
            return _mapper.Map<List<SliderItemListDto>>(sliderItems);

        }

        public async Task<SliderItemListDto> GetSliderItemById(int id)
        {

            //var response = await _uow.GetRepository<SliderItem>().GetByFilterAsync(x=>x.Id == id);
            var response = await base.GetByIdAsync(id);
            if (response == null)
                throw new SliderItemNotFoundException();
            return _mapper.Map<SliderItemListDto>(response);
        }

        public async Task deleteSliderItemById(int id)
        {
            var sliderItem = await _uow.GetRepository<SliderItem>().GetByFilterAsync(x => x.Id == id);
            if (sliderItem == null)
                throw new SliderItemNotFoundException();

            var response = _storage.RemoveFile(sliderItem.ImageUrl);
            if (response == true)
            {
                _uow.GetRepository<SliderItem>().Remove(_mapper.Map<SliderItem>(sliderItem));
                await _uow.SaveChangesAsync();
            }
        }

        /*
        public async Task updateSliderItem(SliderItemUpdateDto dto)
        {
            var sliderItem = await _uow.GetRepository<SliderItem>().GetQueryable().SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (sliderItem == null)
                throw new SliderItemNotFoundException();
            _storage.RemoveFile(sliderItem.ImageUrl);
            sliderItem.Title = dto.Title;
            sliderItem.SliderId = dto.SliderId;
            sliderItem.SubTitle = dto.SubTitle;
            sliderItem.ImageUrl = dto.ImageUrl;
            sliderItem.ButtonLink = dto.ButtonLink;
            sliderItem.ButtonText = dto.ButtonText;

            _uow.GetRepository<SliderItem>().Update(sliderItem);
            await _uow.SaveChangesAsync();
        }

        */

        public async Task updateSliderItem(SliderItemUpdateModel model)
        {
            var sliderItem = await _uow.GetRepository<SliderItem>().GetByFilterAsync(x=>x.Id == model.Id);
            if(sliderItem == null)
                throw new SliderItemNotFoundException();


            sliderItem.Title=model.Title;
            sliderItem.SubTitle=model.SubTitle;
            sliderItem.ButtonText=model.ButtonText;
            sliderItem.ButtonLink = model.ButtonLink;
            sliderItem.SliderId = model.SliderId;

            if(model.File != null)
            {
                var imageUrlGuid = Guid.NewGuid().ToString();
                sliderItem.ImageUrl = imageUrlGuid + Path.GetExtension(model.File.FileName);
                await _storage.UploadFile(imageUrlGuid, model.File);    
            }
            _uow.GetRepository<SliderItem>().Update(sliderItem);
            await _uow.SaveChangesAsync();
        }




    }
}
