using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IPdfConverter
    {
        string GeneratePdf(int id, List<Product> products);
    }
}
