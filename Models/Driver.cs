using System;
using System.Collections.Generic;

namespace CLDV6221_PoE_Part3.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public virtual ICollection<TblRental> TblRental { get; set; } = new List<TblRental>();

    public virtual ICollection<TblReturn> TblReturn { get; set; } = new List<TblReturn>();
}
// allows me to create a Driver object.
