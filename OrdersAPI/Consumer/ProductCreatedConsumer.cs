using MassTransit;
using OrdersAPI.Data;
using OrdersAPI.Models;
using Shared.Models;

namespace OrdersAPI.Consumer
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly OrdersAPIContext _OrdersDbContext;

        public ProductCreatedConsumer(OrdersAPIContext ordersAPIContext)
        {
            _OrdersDbContext = ordersAPIContext;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
         
            var newProduct = new Product
            {
                Name = context.Message.Name, 
                
            };

            // Ajout à la base de données
            _OrdersDbContext.Products.Add(newProduct);
            await _OrdersDbContext.SaveChangesAsync();
        }
    }

  
}
