using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Interfaces
{
    public interface IRepository<T>
    {
        IReadOnlyList<T> Get();

        T GetById(int id);

        void Add(T category);

        void Save();
    }
}
