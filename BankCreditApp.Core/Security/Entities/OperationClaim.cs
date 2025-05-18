using BankCreditApp.Core.Repositories;
using System;

public class OperationClaim : Entity<Guid>
{
    public string Name { get; set; }
} 