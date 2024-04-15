using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class Boat
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Capacity { get; set; }

    public int? NbrCabins { get; set; }

    public int? NbrBathrooms { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public string? Availability { get; set; }

    public int? IdEquipments { get; set; }

    public int? IdFeedBack { get; set; }

    public int? IdReservation { get; set; }

    public virtual Equipment? IdEquipmentsNavigation { get; set; }

    public virtual FeedBack? IdFeedBackNavigation { get; set; }

    public virtual Reservation? IdReservationNavigation { get; set; }
}
