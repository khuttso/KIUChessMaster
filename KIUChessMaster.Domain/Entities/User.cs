using KIUChessMaster.Domain.Common;
using KIUChessMaster.Domain.Enums;

namespace KIUChessMaster.Domain.Entities;

public class User : BaseEntity<long>
{   
    public Guid UserId { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public GenderType Gender { get; set; }
    public DateTime DoB { get; set; }

    public User()
    {
        IsActive = true;
        IsDeleted = false;
        CreatedDate = DateTime.Now;
    }

    public User(Guid userId, string firstname, string lastname, string email, GenderType gender, DateTime dob)
    {   
        UserId = userId;
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Gender = gender;
        DoB = dob;
    }
    
    public void UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));
        
        Email = email;
        SetUpdated();
    }
}