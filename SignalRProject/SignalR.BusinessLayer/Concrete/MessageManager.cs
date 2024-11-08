using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messsageDal;

		public MessageManager(IMessageDal messsageDal)
		{
			_messsageDal = messsageDal;
		}

		public void TAdd(Message entity)
		{
			_messsageDal.Add(entity);	
		}

		public void TDelete(Message entity)
		{
			_messsageDal.Delete(entity);
		}
		public Message TGetByID(int id)
		{
			return _messsageDal.GetByID(id);	
		}

		public List<Message> TGetListAll()
		{
			return _messsageDal.GetListAll();	
		}

		public void TUpdate(Message entity)
		{
			_messsageDal.Update(entity);	
		}
	}
}
