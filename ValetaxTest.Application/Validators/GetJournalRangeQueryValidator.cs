using FluentValidation;
using ValetaxTest.Application.Queries.GetJournalRange;

namespace ValetaxTest.Application.Validators;

public class GetJournalRangeQueryValidator : AbstractValidator<GetJournalRangeQuery>
{
    public GetJournalRangeQueryValidator()
    {
        RuleFor(x => x.Skip)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Take)
            .GreaterThan(0)
            .LessThanOrEqualTo(100);

        RuleFor(x => x.From)
            .LessThanOrEqualTo(x => x.To)
            .When(x => x.From.HasValue && x.To.HasValue);
    }
}