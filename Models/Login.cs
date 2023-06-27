using System;
using System.Collections.Generic;

namespace CLDV6221_PoE_Part3.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int InspectorId { get; set; }

    public virtual Inspector Inspector { get; set; } = null!;
}
// allows me to create a Login object.
