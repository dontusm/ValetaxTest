using MediatR;

namespace ValetaxTest.Application.Commands.DeleteNode;

public record DeleteNodeCommand(long NodeId) : IRequest<DeleteNodeResponseDto>;