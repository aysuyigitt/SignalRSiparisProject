﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
		public int TProductCountByCategoryNameHamburger();
		public int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TProductAvgPriceByHamburger();
		public decimal TProductPriceBySteakBurger();
		decimal TTotalPriceByDrinkCategory();
		decimal TTotalPriceBySaladCategory();
		public List<Product> TGetLast9Products();



	}
}
