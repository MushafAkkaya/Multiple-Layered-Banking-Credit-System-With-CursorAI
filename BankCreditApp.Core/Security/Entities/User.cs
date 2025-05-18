using BankCreditApp.Core.Repositories;
using System;

public abstract class User : Entity<Guid>, INameResolver
{
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public abstract string GetDisplayName();
} 