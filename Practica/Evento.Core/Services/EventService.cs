using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public ServiceResult<IReadOnlyList<Event>> Get()
        {
            var events = _eventRepository.Get();
            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(events);
        }

        public ServiceResult<IReadOnlyList<Event>> GetByCategory(string category)
        {
            var events = _eventRepository.GetByCategory(category);
            if (events == null)
            {
                return ServiceResult<IReadOnlyList<Event>>.NotFoundResult($"No se encontro un evento con la categoria: {category}");
            }

            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(events);
        }

        public ServiceResult<Event> GetById(int id)
        {
            var events = _eventRepository.GetById(id);
            if (events == null)
            {
                return ServiceResult<Event>.NotFoundResult($"No se enconto un evento con el id {id}");
            }

            return ServiceResult<Event>.SuccessResult(events);
        }
    }
}
