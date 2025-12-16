using FluentValidation;
using ValetaxTest.Application.Commands.CreateNode;

namespace ValetaxTest.Application.Validators;

public class CreateNodeCommandValidator : AbstractValidator<CreateNodeCommand>
{
    public CreateNodeCommandValidator()
    {
        RuleFor(x => x.ParentId)
            .GreaterThan(0)
            .WithMessage("ParentId must be greater than 0");
        
        RuleFor(x => x.TreeName)
            .NotEmpty()
            .MaximumLength(200);
        
        RuleFor(x => x.NodeName)
            .NotEmpty()
            .MaximumLength(200);
    }
}