using Lab5.Application.Models.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    IEnumerable<Operation> GetOperationsByUserId(long userId);
}