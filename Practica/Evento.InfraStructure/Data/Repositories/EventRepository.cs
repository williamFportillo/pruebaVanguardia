using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Evento.InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evento.InfraStructure.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsDbContext _context;

        public EventRepository(EventsDbContext context)
        {
            _context = context;
        }
        public IReadOnlyList<Event> Get()
        {
            return _context.Events.ToList();
        }

        public IReadOnlyList<Event> GetByCategory(string category)
        {
            return _context.Events.Where(x =>  x.Category == category).ToList();
        }

        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }
    }
}
