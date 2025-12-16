using MediatR;

namespace ValetaxTest.Application.Commands.CreateNode;

public record CreateNodeCommand(
    string TreeName,
    long? ParentId,
    string NodeName) : IRequest<long>;