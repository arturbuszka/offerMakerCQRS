using Microsoft.EntityFrameworkCore;
using OfferMakerForCggCQRS.Domain.Entities;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Persistence
{
    public interface IOffermakerDbContext
    {
        DbSet<Offer> Offers { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}