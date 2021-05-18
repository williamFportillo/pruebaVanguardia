using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Interfaces
{
    public interface IEventService
    {
        ServiceResult<IReadOnlyList<Event>> Get();

        ServiceResult< Event> GetById(int id);

        ServiceResult<IReadOnlyList<Event>> GetByCategory(string category);
    }
}
