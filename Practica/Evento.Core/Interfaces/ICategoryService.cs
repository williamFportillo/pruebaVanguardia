using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Interfaces
{
    public interface ICategoryService
    {
        ServiceResult<IReadOnlyList<Category>> GetCategory();

        ServiceResult<Category> GetById(int id);

        ServiceResult<Category> AddCategory(Category category);
    }
}
