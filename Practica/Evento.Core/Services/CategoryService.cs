using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceResult<Category> AddCategory(Category cate)
        {

            var category = _categoryRepository.GetById(cate.Id);
            if (category == null)
            {
                _categoryRepository.Add(cate);
                _categoryRepository.Save();
                return ServiceResult<Category>.SuccessResult(cate);
                
            }
            return ServiceResult<Category>.ErrorResult($"Ya existe una categoria con este id: {cate.Id}");

        }

        public ServiceResult<Category> GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return ServiceResult<Category>.NotFoundResult($"No se encontro una categoria con el id: {id}");
            }

            return ServiceResult<Category>.SuccessResult(category);
        }

        public ServiceResult<IReadOnlyList<Category>> GetCategory()
        {
            var category = _categoryRepository.Get();
            return ServiceResult<IReadOnlyList<Category>>.SuccessResult(category);
        }
    }
}
