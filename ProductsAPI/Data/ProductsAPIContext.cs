using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public class ProductsAPIContext : DbContext
    {
        public ProductsAPIContext (DbContextOptions<ProductsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsAPI.Models.Product> Product { get; set; } = default!;
    }
}
