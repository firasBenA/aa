using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class Facture
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? Prix { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
