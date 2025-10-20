using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Passenger
{
    public required int Id { get; set; }

    public required string PassportNumber { get; set; }

    public required string FullName { get; set; }

    public required DateOnly BirthDate { get; set; }

}
