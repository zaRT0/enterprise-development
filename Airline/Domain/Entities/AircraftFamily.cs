using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AircraftFamily
{
    public required int Id { get; set; }

    public required string ModelName { get; set; }

    public required string ManufacturerName { get; set; }   
}
