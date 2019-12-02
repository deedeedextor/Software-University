using System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ImportItemDto
    {
        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, StringLength(30), MinLength(3)]
        public string Category { get; set; }
    }
}
