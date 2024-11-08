﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, Mapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();	
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));	
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			var values= _notificationService.TNotificationCountByStatusFalse();
			return Ok(values);	
		}
		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			var values = _notificationService.TGetAllNotificationByFalse();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.Status = false;
			createNotificationDto.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());		
			var value= _mapper.Map<Notification>(createNotificationDto);	
			_notificationService.TAdd(value);
			return Ok("Ekleme işlemi başarıyla yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id) { 
         
			var value = _notificationService.TGetByID(id);	
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdNotificationDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var value = _mapper.Map<Notification>(updateNotificationDto);	
			_notificationService.TUpdate(value);
			return Ok("Güncelleme işlemi başarıyla yapıldı");
		}
		[HttpGet("NotificationStatusCahngeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}

		[HttpGet("NotificationStatusCahngeToFalse/{id}")]
		public IActionResult NotificationStatusCahngeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}
	}
}
