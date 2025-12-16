using MediatR;
using ValetaxTest.Application.DTOs;

namespace ValetaxTest.Application.Queries.GetTree;

public record GetTreeQuery(string TreeName) : IRequest<TreeDto>;