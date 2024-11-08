﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetListAll();
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
           var value=_mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Sosyal medya bilgisi eklendi");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal medya silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {

            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal medya bilgisi güncellendi");
        }

    }
}

  