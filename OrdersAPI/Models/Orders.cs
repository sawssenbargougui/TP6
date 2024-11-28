
   


        using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

        namespace OrdersAPI.Models
        {
            public class Orders
            {
                public int OrdersId { get; set; }
                public DateTime OrdersDate { get; set; }
                public string? CustomerName { get; set; }
                public int ProductId { get; set; }
            }
        }

 