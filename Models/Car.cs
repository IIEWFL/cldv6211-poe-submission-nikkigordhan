using System;
using System.Collections.Generic;

namespace CLDV6221_PoE_Part3.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string CarNo { get; set; } = null!;

    public int CarMakeId { get; set; }

    public int CarBodyTypeId { get; set; }

    public string Model { get; set; } = null!;

    public int KilometersTravelled { get; set; }

    public int ServiceKilometers { get; set; }

    public bool Available { get; set; }

    public virtual CarBodyType CarBodyType { get; set; } = null!;

    public virtual CarMake CarMake { get; set; } = null!;

    public virtual ICollection<TblRental> TblRental { get; set; } = new List<TblRental>();

    public virtual ICollection<TblReturn> TblReturn { get; set; } = new List<TblReturn>();
}
// allows me to create a Car object.
