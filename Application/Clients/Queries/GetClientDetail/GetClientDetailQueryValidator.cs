using FluentValidation;

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
