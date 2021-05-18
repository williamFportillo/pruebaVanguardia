using Evento.API.Models;
using Evento.Core.Entities;
using Evento.Core.Enum;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<CategoryDTO>> GetAll()
        {
            var category = _categoryService.GetCategory().Result.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(category);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(category.Error);
            }

            return Ok(new CategoryDTO { 
                Id = category.Result.Id,
                Name = category.Result.Name
            });
        }

        [HttpPost]
        public ActionResult<CategoryDTO> NewCategory([FromBody] CategoryDTO cate)
        {
            var entity = new Category
            {
                Id = cate.Id,
                Name = cate.Name
            };
            var category = _categoryService.AddCategory(entity);
            if (category.ResponseCode == ResponseCode.Error )
            {
                return BadRequest(category.Error);
            }

            return Ok(category);
        }
    }
}
