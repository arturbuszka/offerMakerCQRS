using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryValidator : AbstractValidator<GetClientDetailQuery>
    {
        public GetClientDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
