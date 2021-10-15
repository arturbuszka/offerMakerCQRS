using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.UpdateProductCommand
{
    public class UpdateProductMenuCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
