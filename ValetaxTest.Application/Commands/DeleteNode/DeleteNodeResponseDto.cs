using MediatR;

namespace ValetaxTest.Application.Commands.DeleteNode;

public record DeleteNodeResponseDto(bool IsSuccess, long? NodeId = null);