using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string StockQte { get; set; }
        public double Price { get; set; }
    }
}
