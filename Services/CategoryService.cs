using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Repository;
using Book.Entities;

namespace Book.Services
{
    // Classe CategoryService che deriva da ICategoryService
    public class CategoryService : ICategoryService
    {
        // istanzio categoryRepository
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // operazioni di Lettura

        public List<Categories> GetAll()
        {
            return categoryRepository.GetAll();
        }
        public Categories GetById(int Id)
        {
            return categoryRepository.GetById(Id);
        }

        // operazioni di Scrittura

        public Categories Insert(Categories c)
        {
            return categoryRepository.Insert(c);
        }
        public Categories Update(Categories c)
        {
            return categoryRepository.Update(c);
        }
        public Categories Delete(int Id)
        {
            return categoryRepository.Delete(Id);
        }
    }
}