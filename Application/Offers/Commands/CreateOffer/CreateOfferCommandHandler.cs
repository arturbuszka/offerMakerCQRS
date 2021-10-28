using MediatR;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands
{
        public class CreateOfferCommandHandler: IRequestHandler<CreateOfferCommand, int>
        {
            private readonly IOffermakerDbContext _context;
            private readonly IUserContext _userContext;
            public CreateOfferCommandHandler(IOffermakerDbContext context, IUserContext userContext)
            {
                _context = context;
                _userContext = userContext;
            }

            public async Task<int> Handle(CreateOfferCommand command, CancellationToken cancellationToken)
            {
                var userName = _userContext.User.Identity.Name;

                var entity = new Offer
                {
                    Id = command.Id,
                    ClientId = command.ClientId,
                    City = command.City,
                    Street = command.Street,
                    PostalCode = command.PostalCode,
                    Description = command.Description,
                    Products = command.Products,
                    ProductsCount = command.ProductsCount,
                    ProductsPrice = command.ProductsPrice,
                    Created = command.Created,
                    CreatedBy = userName,
                    DateOfWork = command.DateOfWork
                };

                _context.Offers.Add(entity);

                await _context.SaveChangesAsync();

                 return entity.Id;
            }
        }
}
