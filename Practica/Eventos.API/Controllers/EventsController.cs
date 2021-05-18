using Evento.API.Models;
using Evento.Core.Enum;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<EventDTO>> Get()
        {
            var events = _eventService.Get().Result.Select(x => new EventDTO { 
                 Id = x.Id,
                 Name = x.Name,
                 Amount = x.Amount,
                 Category = x.Category,
                 Price = x.Price
            });
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDTO> GetById(int id)
        {
            var events = _eventService.GetById(id);
            if (events.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(events.Error);
            }

            return Ok(new EventDTO
            {
                Id = events.Result.Id,
                Name = events.Result.Name,
                Amount = events.Result.Amount,
                Category = events.Result.Category,
                Price = events.Result.Price
            });
        }

        [HttpGet("Categories/{category}")]
        public ActionResult<EventDTO> GetByCategory(string category)
        {
            var events = _eventService.GetByCategory(category);
            if (events.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(events.Error);
            }

            return Ok(events.Result.Select(x => new EventDTO
            {
                Id = x.Id,
                Name = x.Name,
                Amount = x.Amount,
                Category = x.Category,
                Price = x.Price
            }));
        }
    }
}
