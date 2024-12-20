using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type OperationTypes as enum
    (
        'PUT',
        'REMOVE'
    );
    
    create table Accounts
    (
        Account_id bigint primary key generated always as identity ,
        AccountPassword bigint ,
        Balance decimal,
    );

    create table OperationHistory 
    (
        OperationId bigint primary key generated always as identity,
        AccountId bigint references Accounts(AccountId),
        OperationType OperationTypes,
        Amount DECIMAL 
    );
    
    insert into Accounts(AccountId, AccountPassword, AccountBalance)
    values (1, 123, 0), 
           (2, 123, 1000),
           (3, 123, 20500)
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table Accounts;
    drop table OperationHistory;

    drop type user_role;
    drop type order_state;
    drop type order_result_state;
    """;
}