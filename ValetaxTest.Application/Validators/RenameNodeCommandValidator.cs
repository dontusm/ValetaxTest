using FluentValidation;
using ValetaxTest.Application.Commands.RenameNode;

namespace ValetaxTest.Application.Validators;

public class RenameNodeCommandValidator : AbstractValidator<RenameNodeCommand>
{
    public RenameNodeCommandValidator()
    {
        RuleFor(x => x.NodeId)
            .GreaterThan(0)
            .WithMessage("NodeId must be greater than 0");

        RuleFor(x => x.NewNodeName)
            .NotEmpty()
            .MaximumLength(200);
    }
}