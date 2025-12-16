using MediatR;

namespace ValetaxTest.Application.Commands.RenameNode;

public record RenameNodeCommand(long NodeId, string NewNodeName) : IRequest<RenameNodeResponseDto>;