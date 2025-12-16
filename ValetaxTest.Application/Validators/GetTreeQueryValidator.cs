using FluentValidation;
using ValetaxTest.Application.Queries.GetTree;

namespace ValetaxTest.Application.Validators;

public class GetTreeQueryValidator : AbstractValidator<GetTreeQuery>
{
    public GetTreeQueryValidator()
    {
        RuleFor(x => x.TreeName)
            .NotEmpty()
            .MaximumLength(200);
    }
}