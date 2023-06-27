using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace CLDV6221_PoE_Part3.Models;

public partial class TblReturn
{
    [Required]
    public int ReturnId { get; set; }

    public int CarId { get; set; }

    public int InspectorId { get; set; }

    public int DriverId { get; set; }

    public DateTime ReturnDate { get; set; }

    public int ElapsedDate { get; set; }

    public decimal? Fine { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Inspector Inspector { get; set; } = null!;
}
// allows me to create a Return object.
