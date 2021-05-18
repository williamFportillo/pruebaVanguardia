using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Interfaces
{
    public interface IEventRepository
    {
        IReadOnlyList<Event> Get();

        Event GetById(int id);

        IReadOnlyList<Event> GetByCategory(string category);
    }
}
