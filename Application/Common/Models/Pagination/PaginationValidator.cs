using FluentValidation;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Models.Pagination
{
    public class PaginationValidator : AbstractValidator<PaginationQuery>
    {
        public int[] allowedPageSizes = new[] { 5, 10, 15, 20, 30 };
        public string[] allowedSortByColumnNames = { nameof(Offer.Created) };
        public PaginationValidator()
        {
            RuleFor(v => v.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(v => v.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });
            RuleFor(o => o.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
