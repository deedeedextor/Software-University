using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(5), MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
