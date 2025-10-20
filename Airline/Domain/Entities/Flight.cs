using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Flight
{
    public required int Id { get; set; }

    public required string Code { get; set; }

    public required string DeparturePoint { get; set; }

    public required string ArrivalPoint { get; set; }

    public required DateOnly DepartureDate { get; set; }

    public required DateOnly ArrivalDate { get; set; }

    public required TimeOnly DepartureTime { get; set; }

    public required TimeSpan Duration { get; set; }

    public required AircraftModel AircraftModel { get; set; }

}
