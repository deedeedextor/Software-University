using SIS.MvcFramework.Attributes.Validation;

namespace MUSACA.App.ViewModels.Products
{
    public class ProductOrderViewModel
    {

        [RequiredSis]
        public string Product { get; set; }
    }
}
