using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail
{
    public class GetOfferDetailQueryValidator : AbstractValidator<GetOfferDetailQuery>
    {
        public GetOfferDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
