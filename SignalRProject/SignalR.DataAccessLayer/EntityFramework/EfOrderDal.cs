using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal: GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.Description == "Müşteri masada oturuyor").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			return 0;
			//using var context = new SignalRContext();
			//return context.Orders.Where(x=>x.Date==DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(YieldAwaitable=>YieldAwaitable.TotalPrice);			
		}

		public int TotalOrderCount()
		{
			using var context= new SignalRContext();
			return context.Orders.Count();	
		}
	}
}
