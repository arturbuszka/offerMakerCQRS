using FluentValidation;

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
