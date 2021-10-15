using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.DeleteProductCommand
{
    public class DeleteProductMenuCommand : IRequest
    {
        public int Id { get; set; }
    }
}
