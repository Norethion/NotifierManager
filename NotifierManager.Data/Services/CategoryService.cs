using System.Collections.Generic;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Repository;

namespace NotifierManager.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository<Category> _repository;

        public CategoryService(NotifierDbContext context)
        {
            _repository = new Repository<Category>(context);
        }

        public bool CreateCategory(Category category)
        {
            try
            {
                _repository.Add(category);
                _repository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = _repository.GetById(id);
                if (category != null)
                {
                    _repository.Delete(category);
                    _repository.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _repository.GetById(id);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _repository.Update(category);
                _repository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}