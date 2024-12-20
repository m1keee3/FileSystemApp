using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserById(long id);

    void InsertUser(long id, long password);

    void AddMoney(long id, decimal amount);

    void RemoveMoney(long id, decimal amount);
}