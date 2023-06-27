using System;
using System.Collections.Generic;

namespace CLDV6221_PoE_Part3.Models;

public partial class CarMake
{
    public int CarMakeId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
// allows me to create a CarMake object.
