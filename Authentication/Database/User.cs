using Microsoft.AspNetCore.Identity;

namespace Authentication.Database;

public class User : IdentityUser
{
    public string? Initials { get; set; }
}
