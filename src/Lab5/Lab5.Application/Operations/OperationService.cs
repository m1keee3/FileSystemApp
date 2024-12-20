using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Operations;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _repository;

    public OperationService(IOperationRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Operation> GetOperationsByUserId(long userId)
    {
        return _repository.GetOperationsByUserId(userId);
    }
}