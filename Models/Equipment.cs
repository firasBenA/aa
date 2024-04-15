using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public virtual ICollection<Boat> Boats { get; set; } = new List<Boat>();
}
