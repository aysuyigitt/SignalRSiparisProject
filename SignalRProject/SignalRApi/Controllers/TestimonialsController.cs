using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

            [HttpGet]
            public IActionResult TestimonialList()
            {
                var values = _testimonialService.TGetListAll();
                return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
            }
            [HttpPost]
            public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
            {
                var value = _mapper.Map<Testimonial>(createTestimonialDto);
                _testimonialService.TAdd(value);    
                return Ok("Müşteri yorum bilgisi eklendi");
            }
		     [HttpDelete("{id}")]
		     public IActionResult DeleteTestimonial(int id)
             {
                var value = _testimonialService.TGetByID(id);
                _testimonialService.TDelete(value);
                return Ok("Müşteri yorum bilgisi silindi");
            }

            [HttpGet("{id}")]
            public IActionResult GetTestimonial(int id)
            {
                var value = _testimonialService.TGetByID(id);
                return Ok(_mapper.Map<GetTestimonialDto>(value));
            }
            [HttpPut]
            public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
            {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Müşteri yorum bilgisi güncellendi");
            }

        }
    }

  