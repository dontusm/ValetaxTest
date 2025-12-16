using FluentValidation;
using ValetaxTest.Application.Queries.GetJournalById;

namespace ValetaxTest.Application.Validators;

public class GetJournalByIdQueryValidator : AbstractValidator<GetJournalByIdQuery>
{
    public GetJournalByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");
    }
}
