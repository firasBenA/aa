using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdRole { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
