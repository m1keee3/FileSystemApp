using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Operations;

public interface IOperationService
{
    IEnumerable<Operation> GetOperationsByUserId(long userId);
}