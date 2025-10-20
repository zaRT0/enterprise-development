    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Domain.Entities;
    public class Ticket
    {
        public required int Id { get; set; }

        public required Flight Flight { get; set; }

        public required Passenger Passenger { get; set; }

        public required string SeatNumber { get; set; }

        public required bool IsHandLuggage { get; set; }

        public float? TotalBaggageWeight { get; set; }

    }
