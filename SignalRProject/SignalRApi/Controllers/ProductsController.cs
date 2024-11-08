using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }
		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{

			var value = _productService.TProductCount();
			return Ok(value);
		}
		[HttpGet("TotalPriceByDrinkCategory")]
		public IActionResult TotalPriceByDrinkCategory()
		{
			return Ok(_productService.TTotalPriceByDrinkCategory());
		}

		[HttpGet("TotalPriceBySaladCategory")]
		public IActionResult TotalPriceBySaladCategory()
		{
			return Ok(_productService.TTotalPriceBySaladCategory());
		}
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{

			var value = _productService.TProductCountByCategoryNameHamburger();
			return Ok(value);
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{

			var value = _productService.TProductCountByCategoryNameDrink();
			return Ok(value);
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{

			var value = _productService.TProductPriceAvg();
			return Ok(value);
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{

			var value = _productService.TProductNameByMaxPrice();
			return Ok(value);
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{

			var value = _productService.TProductNameByMinPrice();
			return Ok(value);
		}
		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger()
		{

			var value = _productService.TProductAvgPriceByHamburger();
			return Ok(value);
		}
		[HttpGet("ProductPriceBySteakBurger")]
		public IActionResult ProductPriceBySteakBurger()
		{

			var value = _productService.TProductPriceBySteakBurger();
			return Ok(value);
		}
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
           var value=_mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ürün bilgisi eklendi");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value=_mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(value);	
            return Ok("Öne çıkan bilgisi güncellendi");
        }
		[HttpGet("GetTake9Products")]
		public IActionResult GetTake9Products()
		{
			var value = _productService.TGetLast9Products();
			return Ok(value);
		}

	}
}

   
