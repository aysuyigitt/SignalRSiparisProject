using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.MessageDto;
using SignalRWebUI.Dtos.TestimonialDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
	{
		
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync("http://localhost:12683/api/Contact");
			//var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
			//ViewBag.location = values.Location;
			//return View();

			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("http://localhost:12683/api/Contacts");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;
			return View();
		}
		[HttpGet]
		public PartialViewResult SendMessage() {

		
			return PartialView();	
		}
		[HttpPost]
		public async Task<IActionResult>SendMessage(CreateMessageDto createMessageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMessageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:12683/api/Messages", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Default");
			}
			return View();
		}
	}
	}

