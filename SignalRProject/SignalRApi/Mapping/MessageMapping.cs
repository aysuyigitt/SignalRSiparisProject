using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SignalRApi.Mapping
{
	public class MessageMapping : Profile
	{
		public MessageMapping()
		{
			CreateMap<CreateMessageDto, Message>().ReverseMap();
			CreateMap<ResultMessageDto, Message>().ReverseMap();
			CreateMap<GetByIdMessageDto, Message>().ReverseMap();
			CreateMap<UpdateMessageDto, Message>().ReverseMap();
		}
	}
}
