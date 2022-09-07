using AutoMapper;
using FluentValidation;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationApp.Web.Controllers
{
    public class ProjectionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IValidator<EventDateDto> _eventDateValidator;

        public ProjectionController(IMapper mapper, IValidator<EventDateDto> eventDateValidator)
        {
            _mapper = mapper;
            _eventDateValidator = eventDateValidator;
        }

        public IActionResult Index()
        {
            var eventDateDto = new EventDateDto { Day = DateTime.Now.Day, Month = DateTime.Now.Month, Year = DateTime.Now.Year };
            ViewBag.EventDate = _mapper.Map<EventDate>(eventDateDto).Date.ToShortDateString();
            return View(eventDateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EventDateDto eventDateDto)
        {
            try
            {
                if ((await _eventDateValidator.ValidateAsync(eventDateDto)).IsValid)
                    ViewBag.EventDate = _mapper.Map<EventDate>(eventDateDto).Date.ToShortDateString();

            }
            catch (Exception ex)
            {
                eventDateDto = new EventDateDto { Day = DateTime.Now.Day, Month = DateTime.Now.Month, Year = DateTime.Now.Year };
                ViewBag.EventDate = _mapper.Map<EventDate>(eventDateDto).Date.ToShortDateString();
                ViewBag.Exception = ex;
            }
            return View(eventDateDto);
        }
    }
}
