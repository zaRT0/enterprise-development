using Airline.Domain.Entities;

namespace Airline.Tests;

/// <summary>
/// Provides a comprehensive set of predefined data for airline domain entities to be used in unit tests.
/// Contains collections of aircraft families, aircraft models, flights, passengers, and tickets.
/// This fixture supplies consistent and realistic data scenarios for reliable and repeatable testing.
/// </summary>
public class TestsDataFixture
{
    /// <summary>
    /// A list of aircraft families categorizing aircraft models by manufacturer and design lineage.
    /// </summary>
    public List<AircraftFamily> Families =>
    [
        new()
        {
            Id = 1,
            ModelName = "737",
            ManufacturerName = "Boeing"
        },
        new()
        {
            Id = 2,
            ModelName = "777",
            ManufacturerName = "Boeing"
        },
        new()
        {
            Id = 3,
            ModelName = "A320",
            ManufacturerName = "Airbus"
        },
        new()
        {
            Id = 4,
            ModelName = "A350",
            ManufacturerName = "Airbus"
        },
        new()
        {
            Id = 5,
            ModelName = "E190",
            ManufacturerName = "Embraer"
        },
        new()
        {
            Id = 6,
            ModelName = "CRJ900",
            ManufacturerName = "Bombardier"
        },
        new()
        {
            Id = 7,
            ModelName = "An-124",
            ManufacturerName = "Antonov"
        },
        new()
        {
            Id = 8,
            ModelName = "Tu-154",
            ManufacturerName = "Tupolev"
        },
        new()
        {
            Id = 9,
            ModelName = "Superjet 100",
            ManufacturerName = "Sukhoi"
        },
        new()
        {
            Id = 10,
            ModelName = "C919",
            ManufacturerName = "Comac"
        }
    ];

    /// <summary>
    /// A list of specific aircraft models with detailed specifications including capacities and associated family.
    /// </summary>
    public List<AircraftModel> Models =>
    [
        new()
        {
            Id = 1,
            Name = "737-800",
            ModelFamily = Families[0],
            FlightRange = 5765,
            PassengerCapacity = 189,
            CargoCapacity = 20.5f
        },
        new()
        {
            Id = 2,
            Name = "777-300ER",
            ModelFamily = Families[1],
            FlightRange = 13650,
            PassengerCapacity = 396,
            CargoCapacity = 45.5f
        },
        new()
        {
            Id = 3,
            Name = "A320neo",
            ModelFamily = Families[2],
            FlightRange = 6300,
            PassengerCapacity = 195,
            CargoCapacity = 21.0f
        },
        new()
        {
            Id = 4,
            Name = "A350-900",
            ModelFamily = Families[3],
            FlightRange = 15000,
            PassengerCapacity = 325,
            CargoCapacity = 42.4f
        },
        new()
        {
            Id = 5,
            Name = "Embraer E190-E2",
            ModelFamily = Families[4],
            FlightRange = 4800,
            PassengerCapacity = 114,
            CargoCapacity = 10.2f
        },
        new()
        {
            Id = 6,
            Name = "CRJ900",
            ModelFamily = Families[5],
            FlightRange = 2876,
            PassengerCapacity = 90,
            CargoCapacity = 7.5f
        },
        new()
        {
            Id = 7,
            Name = "An-124",
            ModelFamily = Families[6],
            FlightRange = 4500,
            PassengerCapacity = 0,
            CargoCapacity = 150.0f
        },
        new()
        {
            Id = 8,
            Name = "Tu-154M",
            ModelFamily = Families[7],
            FlightRange = 5280,
            PassengerCapacity = 180,
            CargoCapacity = 18.0f
        },
        new()
        {
            Id = 9,
            Name = "Superjet 100",
            ModelFamily = Families[8],
            FlightRange = 4578,
            PassengerCapacity = 98,
            CargoCapacity = 9.0f
        },
        new()
        {
            Id = 10,
            Name = "C919",
            ModelFamily = Families[9],
            FlightRange = 5555,
            PassengerCapacity = 168,
            CargoCapacity = 19.5f
        }
    ];

    /// <summary>
    /// A list of scheduled flights, including identifiers, route information, timing, and assigned aircraft.
    /// </summary>
    public List<Flight> Flights =>
    [
        new()
        {
            Id = 1,
            Code = "SU1234",
            DeparturePoint = "Moscow (SVO)",
            ArrivalPoint = "Sochi (AER)",
            DepartureDate = new (2025, 10, 20),
            ArrivalDate = new (2025, 10, 20),
            DepartureTime = new TimeOnly(10, 30),
            Duration = TimeSpan.FromHours(2.5),
            AircraftModel = Models[0]
        },
        new()
        {
            Id = 2,
            Code = "A4567",
            DeparturePoint = "Saint Petersburg (LED)",
            ArrivalPoint = "Yekaterinburg (SVX)",
            DepartureDate = new DateOnly(2025, 10, 21),
            ArrivalDate = new DateOnly(2025, 10, 21),
            DepartureTime = new TimeOnly(14, 15),
            Duration = TimeSpan.FromHours(2.75),
            AircraftModel = Models[1]
        },
        new()
        {
            Id = 3,
            Code = "U6789",
            DeparturePoint = "Novosibirsk (OVB)",
            ArrivalPoint = "Vladivostok (VVO)",
            DepartureDate = new DateOnly(2025, 10, 22),
            ArrivalDate = new DateOnly(2025, 10, 22),
            DepartureTime = new TimeOnly(8, 0),
            Duration = TimeSpan.FromHours(6.5),
            AircraftModel = Models[2]
        },
        new()
        {
            Id = 4,
            Code = "DP2468",
            DeparturePoint = "Kazan (KZN)",
            ArrivalPoint = "Mineralnye Vody (MRV)",
            DepartureDate = new DateOnly(2025, 10, 23),
            ArrivalDate = new DateOnly(2025, 10, 23),
            DepartureTime = new TimeOnly(16, 45),
            Duration = TimeSpan.FromHours(2.25),
            AircraftModel = Models[3] },
        new()
        {
            Id = 5,
            Code = "Y7890",
            DeparturePoint = "Rostov-on-Don (ROV)",
            ArrivalPoint = "Kaliningrad (KGD)",
            DepartureDate = new DateOnly(2025, 10, 24),
            ArrivalDate = new DateOnly(2025, 10, 24),
            DepartureTime = new TimeOnly(12, 20),
            Duration = TimeSpan.FromHours(2.0),
            AircraftModel = Models[4]
        },
        new()
        {
            Id = 6,
            Code = "S7111",
            DeparturePoint = "Moscow (DME)",
            ArrivalPoint = "Omsk (OMS)",
            DepartureDate = new DateOnly(2025, 10, 25),
            ArrivalDate = new DateOnly(2025, 10, 25),
            DepartureTime = new TimeOnly(9, 10),
            Duration = TimeSpan.FromHours(3.5),
            AircraftModel = Models[5]
        },
        new()
        {
            Id = 7,
            Code = "R2222",
            DeparturePoint = "Ufa (UFA)",
            ArrivalPoint = "Simferopol (SIP)",
            DepartureDate = new DateOnly(2025, 10, 26),
            ArrivalDate = new DateOnly(2025, 10, 26),
            DepartureTime = new TimeOnly(11, 0),
            Duration = TimeSpan.FromHours(3.0),
            AircraftModel = Models[6]
        },
        new()
        {
            Id = 8,
            Code = "T3333",
            DeparturePoint = "Samara (KUF)",
            ArrivalPoint = "Murmansk (MMK)",
            DepartureDate = new DateOnly(2025, 10, 27),
            ArrivalDate = new DateOnly(2025, 10, 27),
            DepartureTime = new TimeOnly(7, 30),
            Duration = TimeSpan.FromHours(3.25),
            AircraftModel = Models[7]
        },
        new()
        {
            Id = 9,
            Code = "G4444",
            DeparturePoint = "Krasnoyarsk (KJA)",
            ArrivalPoint = "Yuzhno-Sakhalinsk (UUS)",
            DepartureDate = new DateOnly(2025, 10, 28),
            ArrivalDate = new DateOnly(2025, 10, 28),
            DepartureTime = new TimeOnly(13, 45),
            Duration = TimeSpan.FromHours(6.0),
            AircraftModel = Models[8]
        },
        new()
        {
            Id = 10,
            Code = "Z5555",
            DeparturePoint = "Irkutsk (IKT)",
            ArrivalPoint = " Khabarovsk (KHV)",
            DepartureDate = new DateOnly(2025, 10, 29),
            ArrivalDate = new DateOnly(2025, 10, 29),
            DepartureTime = new TimeOnly(15, 20),
            Duration = TimeSpan.FromHours(4.5),
            AircraftModel = Models[9]
        }
    ];

    /// <summary>
    /// A list representing airline passengers, including identifying details and birth dates.
    /// </summary>
    public List<Passenger> Passengers =>
    [
        new()
        {
            Id = 1,
            PassportNumber = "4244-123456",
            FullName = "Ivanov Ivan Ivanovic",
            BirthDate = new DateOnly(1985, 3, 12)
        },
        new()
        {
            Id = 2,
            PassportNumber = "4244-234567",
            FullName = "Petrova Maria Sergeevna",
            BirthDate = new DateOnly(1990, 7, 22)
        },
        new()
        {
            Id = 3,
            PassportNumber = "4244-345678",
            FullName = "Sidorov Alexey Vladimirovich",
            BirthDate = new DateOnly(1978, 11, 5)
        },
        new()
        {
            Id = 4,
            PassportNumber = "4244-456789",
            FullName = "Kuznetsova Anna Olegovna",
            BirthDate = new DateOnly(2000, 1, 30)
        },
        new()
        {
            Id = 5,
            PassportNumber = "4202-567890",
            FullName = "Smirnov Dmitry Andreevich",
            BirthDate = new DateOnly(1982, 9, 14)
        },
        new()
        {
            Id = 6,
            PassportNumber = "4201-678901",
            FullName = "Popova Ekaterina Nikolaevna",
            BirthDate = new DateOnly(1995, 4, 18)
        },
        new()
        {
            Id = 7,
            PassportNumber = "4568-789012",
            FullName = "Volkov Sergey Pavlovich",
            BirthDate = new DateOnly(1970, 12, 25)
        },
        new()
        {
            Id = 8,
            PassportNumber = "4857-890123",
            FullName = "Morozova Olga Viktorovna",
            BirthDate = new DateOnly(1988, 6, 9)
        },
        new()
        {
            Id = 9,
            PassportNumber = "3618-524872",
            FullName = "Lebedev Artyom Yuryevich",
            BirthDate = new DateOnly(1992, 8, 3)
        },
        new()
        {
            Id = 10,
            PassportNumber = "8574-658974",
            FullName = "Novikova Daria Igorevna",
            BirthDate = new DateOnly(1997, 2, 14)
        },
        new()
        {
            Id = 11,
            PassportNumber = "1111-111111",
            FullName = "Abramov Nikolay Petrovich",
            BirthDate = new DateOnly(1983, 5, 10)
        },
        new()
        {
            Id = 12,
            PassportNumber = "2222-222222",
            FullName = "Belova Vera Stepanovna",
            BirthDate = new DateOnly(1991, 12, 3)
        },
        new()
        {
            Id = 13,
            PassportNumber = "3333-333333",
            FullName = "Grigoryev Maxim Igorevich",
            BirthDate = new DateOnly(1987, 8, 22)
        },
        new()
        {
            Id = 14,
            PassportNumber = "4444-444444",
            FullName = "Dmitrieva Sofya Andreevna",
            BirthDate = new DateOnly(1999, 3, 17)
        },
        new()
        { Id = 15,
            PassportNumber = "5555-555555",
            FullName = "Efimov Roman Valeryevich",
            BirthDate = new DateOnly(1975, 11, 30)
        },
        new()
        {
            Id = 16,
            PassportNumber = "6666-666666",
            FullName = "Zhukova Polina Dmitrievna",
            BirthDate = new DateOnly(1994, 7, 8)
        },
        new()
        {
            Id = 17,
            PassportNumber = "7777-777777",
            FullName = "Zaitsev Ilya Olegovich",
            BirthDate = new DateOnly(1989, 1, 15)
        },
        new()
        {
            Id = 18,
            PassportNumber = "8888-888888",
            FullName = "Ivanova Kseniya Sergeevna",
            BirthDate = new DateOnly(1996, 9, 25)
        },
        new()
        {
            Id = 19,
            PassportNumber = "9999-999999",
            FullName = "Kozlov Vladislav Yuryevich",
            BirthDate = new DateOnly(1981, 4, 12)
        },
        new()
        {
            Id = 20,
            PassportNumber = "0041-125874",
            FullName = "Larionova Alina Viktorovna",
            BirthDate = new DateOnly(1993, 6, 20)
        },
        new()
        {
            Id = 21,
            PassportNumber = "8547-123456",
            FullName = "Makarov Daniil Pavlovich",
            BirthDate = new DateOnly(1986, 10, 5)
        },
        new()
        {
            Id = 22,
            PassportNumber = "3657-234567",
            FullName = "Nesterova Elizaveta Mikhailovna",
            BirthDate = new DateOnly(1998, 2, 28)
        },
        new()
        {
            Id = 23,
            PassportNumber = "5241-658923",
            FullName = "Preobrazhenskaya Daria Vyacheslavovna",
            BirthDate = new DateOnly(1992, 5, 15)
        }
    ];

    /// <summary>
    /// Records linking passengers to flights through tickets, including seating and baggage data.
    /// </summary>
    public List<Ticket> Tickets =>
    [
        new()
        {
            Id = 1,
            Flight = Flights[0],
            Passenger = Passengers[0],
            SeatNumber = "12A",
            IsHandLuggage = true,
            TotalBaggageWeight = 23.5f
        },
        new()
        {
            Id = 2,
            Flight = Flights[0],
            Passenger = Passengers[1],
            SeatNumber = "12B",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 3,
            Flight = Flights[0],
            Passenger = Passengers[2],
            SeatNumber = "12C",
            IsHandLuggage = false,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 4,
            Flight = Flights[0],
            Passenger = Passengers[11],
            SeatNumber = "13A",
            IsHandLuggage = true,
            TotalBaggageWeight = 18.0f
        },
        new()
        {
            Id = 5,
            Flight = Flights[0],
            Passenger = Passengers[12],
            SeatNumber = "13B",
            IsHandLuggage = false,
            TotalBaggageWeight = 25.0f
        },

        new()
        {
            Id = 6,
            Flight = Flights[1],
            Passenger = Passengers[3],
            SeatNumber = "15C",
            IsHandLuggage = false,
            TotalBaggageWeight = 30.0f
        },
        new()
        {
            Id = 7,
            Flight = Flights[1],
            Passenger = Passengers[4],
            SeatNumber = "15D",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 8,
            Flight = Flights[1],
            Passenger = Passengers[13],
            SeatNumber = "16A",
            IsHandLuggage = false,
            TotalBaggageWeight = 22.5f
        },

        new()
        {
            Id = 9,
            Flight = Flights[2],
            Passenger = Passengers[5],
            SeatNumber = "20F",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 10,
            Flight = Flights[2],
            Passenger = Passengers[6],
            SeatNumber = "21A",
            IsHandLuggage = false,
            TotalBaggageWeight = 32.7f
        },
        new()
        {
            Id = 11,
            Flight = Flights[2],
            Passenger = Passengers[7],
            SeatNumber = "21B",
            IsHandLuggage = true,
            TotalBaggageWeight = 20.0f
        },
        new()
        {
            Id = 12,
            Flight = Flights[2],
            Passenger = Passengers[8],
            SeatNumber = "21C",
            IsHandLuggage = false,
            TotalBaggageWeight = 28.5f
        },
        new()
        {
            Id = 13,
            Flight = Flights[2],
            Passenger = Passengers[14],
            SeatNumber = "22A",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 14,
            Flight = Flights[2],
            Passenger = Passengers[15],
            SeatNumber = "22B",
            IsHandLuggage = false,
            TotalBaggageWeight = 19.8f
        },

        new()
        {
            Id = 15,
            Flight = Flights[3],
            Passenger = Passengers[9],
            SeatNumber = "8D",
            IsHandLuggage = true,
            TotalBaggageWeight = 18.2f
        },
        new()
        {
            Id = 16,
            Flight = Flights[3],
            Passenger = Passengers[16],
            SeatNumber = "8E",
            IsHandLuggage = false,
            TotalBaggageWeight = null
        },

        new()
        {
            Id = 17,
            Flight = Flights[4],
            Passenger = Passengers[10],
            SeatNumber = "10B",
            IsHandLuggage = false,
            TotalBaggageWeight = 25.0f
        },
        new()
        {
            Id = 18,
            Flight = Flights[4],
            Passenger = Passengers[17],
            SeatNumber = "10C",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },

        new()
        {
            Id = 19,
            Flight = Flights[5],
            Passenger = Passengers[18],
            SeatNumber = "14E",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        },
        new()
        {
            Id = 20,
            Flight = Flights[6],
            Passenger = Passengers[19],
            SeatNumber = "5A",
            IsHandLuggage = false,
            TotalBaggageWeight = 32.7f
        },
        new()
        {
            Id = 21,
            Flight = Flights[7],
            Passenger = Passengers[20],
            SeatNumber = "18C",
            IsHandLuggage = true,
            TotalBaggageWeight = 20.0f
        },
        new()
        {
            Id = 22,
            Flight = Flights[8],
            Passenger = Passengers[21],
            SeatNumber = "7F",
            IsHandLuggage = false,
            TotalBaggageWeight = 28.5f
        },
        new()
        {
            Id = 23,
            Flight = Flights[9],
            Passenger = Passengers[22],
            SeatNumber = "11D",
            IsHandLuggage = true,
            TotalBaggageWeight = null
        }
    ];
}