using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities;
public class AircraftModel
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required AircraftFamily ModelFamily { get; set; }

    public required float FlightRange { get; set; }

    public required int PassengerCapacity { get; set; }

    public required float CargoCapacity { get; set; }

}
