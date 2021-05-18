using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Evento.InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evento.InfraStructure.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly EventsDbContext _context;

        public CategoryRepository(EventsDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public IReadOnlyList<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
