using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLDV6221_PoE_Part3.Models;

public partial class TblRental
{
    [Required]
    public int RentalId { get; set; }

    public int CarId { get; set; }

    public int InspectorId { get; set; }

    public int DriverId { get; set; }

    public decimal RentalFee { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Inspector Inspector { get; set; } = null!;
}
// allows me to create a Rental object.