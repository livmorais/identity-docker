using Microsoft.AspNetCore.Identity;

namespace project;

public class AppUser : IdentityUser
{
    public string? Address { get; set; }

}
