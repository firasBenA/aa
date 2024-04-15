using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public double? Prix { get; set; }

    public int? IdFacture { get; set; }

    public virtual ICollection<Boat> Boats { get; set; } = new List<Boat>();

    public virtual Facture? IdFactureNavigation { get; set; }
}
