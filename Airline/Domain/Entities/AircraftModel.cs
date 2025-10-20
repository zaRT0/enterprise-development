using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class AircraftModel
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required AircraftFamily ModelFamily { get; set; }

    public required int FlightRange { get; set; }

    public required int PassengerCapacity { get; set; }

    public required float CargoCapacity { get; set; }

}
