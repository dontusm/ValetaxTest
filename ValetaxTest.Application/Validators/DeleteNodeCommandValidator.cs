using FluentValidation;
using ValetaxTest.Application.Commands.DeleteNode;

namespace ValetaxTest.Application.Validators;

public class DeleteNodeCommandValidator : AbstractValidator<DeleteNodeCommand>
{
    public DeleteNodeCommandValidator()
    {
        RuleFor(x => x.NodeId)
            .GreaterThan(0)
            .WithMessage("NodeId must be greater than 0");
    }
}