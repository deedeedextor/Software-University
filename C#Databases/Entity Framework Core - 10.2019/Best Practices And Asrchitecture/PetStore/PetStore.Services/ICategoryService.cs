using PetStore.Services.Models.Category;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        void Create(CreateCategoryServiceModel model);

        void Edit(CategoryEditServiceModel model);

        bool Remove(int id);

        CategoryDetailsServiceModel GetById(int id);

        IEnumerable<AllCategoriesServiceModel> All();

        bool Exists(int categoryId);
    }
}
