using SIS.MvcFramework.Attributes.Validation;

namespace MUSACA.App.ViewModels.Products
{
    public class ProductCreateInputModel
    {
        private const string NameErrorMessage = "Name length must be between 3 and 15!";
        private const string PriceErrorMessage = "Price must be between 0.001 and 100000!";

        [RequiredSis]
        [StringLengthSis(3, 15, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        public string Price { get; set; }

        [RequiredSis]
        public string Picture { get; set; }

        [RequiredSis]
        public string Barcode { get; set; }
    }
}
