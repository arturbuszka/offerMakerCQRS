using Microsoft.EntityFrameworkCore;
using OfferMakerForCggCQRS.Domain.Entities;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Persistence
{
    public class OffermakerDbContext : DbContext, IOffermakerDbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMenu> ProductsMenu { get; set; }
        public OffermakerDbContext(DbContextOptions<OffermakerDbContext> options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
