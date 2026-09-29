using NTU.CorePlatform.Domain.Common.Entities;
using NTU.CorePlatform.Domain.Common.Enums;
using NTU.CorePlatform.Domain.Entities.StudentManagement;

namespace NTU.CorePlatform.Domain.Entities.Identity;

public class User : AggregateRoot<Guid>
{
    public string Username { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public string? SecurityStamp { get; private set; }
    public UserStatus Status { get; private set; } = UserStatus.PendingActivation;
    public DateTime? LastLoginAt { get; private set; }
    public DateTime? LockedOutEnd { get; private set; }
    public int FailedLoginAttempts { get; private set; }

    // Navigation Properties
    public Student? Student { get; private set; }
}