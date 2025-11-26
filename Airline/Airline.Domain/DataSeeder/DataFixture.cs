using Airline.Domain.Entities;

namespace Airline.Domain.DataSeeder;

public class DataFixture
{
    public List<AircraftFamily> Families { get; }
    public List<AircraftModel> Models { get; }
    public List<Flight> Flights { get; }
    public List<Passenger> Passengers { get; }
    public List<Ticket> Tickets { get; }

    public DataFixture()
    {
        // Aircraft Families
        Families = new()
        {
            new AircraftFamily { ModelName = "737", ManufacturerName = "Boeing" },
            new AircraftFamily { ModelName = "777", ManufacturerName = "Boeing" },
            new AircraftFamily { ModelName = "A320", ManufacturerName = "Airbus" },
            new AircraftFamily { ModelName = "A350", ManufacturerName = "Airbus" },
            new AircraftFamily { ModelName = "E190", ManufacturerName = "Embraer" },
            new AircraftFamily { ModelName = "CRJ900", ManufacturerName = "Bombardier" },
            new AircraftFamily { ModelName = "An-124", ManufacturerName = "Antonov" },
            new AircraftFamily { ModelName = "Tu-154", ManufacturerName = "Tupolev" },
            new AircraftFamily { ModelName = "Superjet 100", ManufacturerName = "Sukhoi" },
            new AircraftFamily { ModelName = "C919", ManufacturerName = "Comac" }
        };

        // Aircraft Models
        Models = new()
        {
            new AircraftModel { Name = "737-800", ModelFamily = Families[0], FlightRange = 5765, PassengerCapacity = 189, CargoCapacity = 20.5f },
            new AircraftModel { Name = "777-300ER", ModelFamily = Families[1], FlightRange = 13650, PassengerCapacity = 396, CargoCapacity = 45.5f },
            new AircraftModel { Name = "A320neo", ModelFamily = Families[2], FlightRange = 6300, PassengerCapacity = 195, CargoCapacity = 21.0f },
            new AircraftModel { Name = "A350-900", ModelFamily = Families[3], FlightRange = 15000, PassengerCapacity = 325, CargoCapacity = 42.4f },
            new AircraftModel { Name = "Embraer E190-E2", ModelFamily = Families[4], FlightRange = 4800, PassengerCapacity = 114, CargoCapacity = 10.2f },
            new AircraftModel { Name = "CRJ900", ModelFamily = Families[5], FlightRange = 2876, PassengerCapacity = 90, CargoCapacity = 7.5f },
            new AircraftModel { Name = "An-124", ModelFamily = Families[6], FlightRange = 4500, PassengerCapacity = 0, CargoCapacity = 150.0f },
            new AircraftModel { Name = "Tu-154M", ModelFamily = Families[7], FlightRange = 5280, PassengerCapacity = 180, CargoCapacity = 18.0f },
            new AircraftModel { Name = "Superjet 100", ModelFamily = Families[8], FlightRange = 4578, PassengerCapacity = 98, CargoCapacity = 9.0f },
            new AircraftModel { Name = "C919", ModelFamily = Families[9], FlightRange = 5555, PassengerCapacity = 168, CargoCapacity = 19.5f }
        };

        // Flights
        Flights = new()
        {
            new Flight { Code = "SU1234", DeparturePoint = "Moscow (SVO)", ArrivalPoint = "Sochi (AER)", DepartureDateTime = new DateTime(2025, 10, 20, 10, 30, 0), ArrivalDateTime = new DateTime(2025, 10, 20, 13, 0, 0), AircraftModel = Models[0] },
            new Flight { Code = "A4567", DeparturePoint = "Saint Petersburg (LED)", ArrivalPoint = "Yekaterinburg (SVX)", DepartureDateTime = new DateTime(2025, 10, 21, 14, 15, 0), ArrivalDateTime = new DateTime(2025, 10, 21, 17, 0, 0), AircraftModel = Models[1] },
            new Flight { Code = "U6789", DeparturePoint = "Novosibirsk (OVB)", ArrivalPoint = "Vladivostok (VVO)", DepartureDateTime = new DateTime(2025, 10, 22, 8, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 22, 14, 30, 0), AircraftModel = Models[2] },
            new Flight { Code = "DP2468", DeparturePoint = "Kazan (KZN)", ArrivalPoint = "Mineralnye Vody (MRV)", DepartureDateTime = new DateTime(2025, 10, 23, 16, 45, 0), ArrivalDateTime = new DateTime(2025, 10, 23, 19, 10, 0), AircraftModel = Models[3] },
            new Flight { Code = "Y7890", DeparturePoint = "Rostov-on-Don (ROV)", ArrivalPoint = "Kaliningrad (KGD)", DepartureDateTime = new DateTime(2025, 10, 24, 12, 20, 0), ArrivalDateTime = new DateTime(2025, 10, 24, 14, 20, 0), AircraftModel = Models[4] },
            new Flight { Code = "S7111", DeparturePoint = "Moscow (DME)", ArrivalPoint = "Omsk (OMS)", DepartureDateTime = new DateTime(2025, 10, 25, 9, 10, 0), ArrivalDateTime = new DateTime(2025, 10, 25, 12, 40, 0), AircraftModel = Models[5] },
            new Flight { Code = "R2222", DeparturePoint = "Ufa (UFA)", ArrivalPoint = "Simferopol (SIP)", DepartureDateTime = new DateTime(2025, 10, 26, 11, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 26, 14, 0, 0), AircraftModel = Models[6] },
            new Flight { Code = "T3333", DeparturePoint = "Samara (KUF)", ArrivalPoint = "Murmansk (MMK)", DepartureDateTime = new DateTime(2025, 10, 27, 7, 30, 0), ArrivalDateTime = new DateTime(2025, 10, 27, 10, 55, 0), AircraftModel = Models[7] },
            new Flight { Code = "G4444", DeparturePoint = "Krasnoyarsk (KJA)", ArrivalPoint = "Yuzhno-Sakhalinsk (UUS)", DepartureDateTime = new DateTime(2025, 10, 28, 13, 45, 0), ArrivalDateTime = new DateTime(2025, 10, 28, 19, 45, 0), AircraftModel = Models[8] },
            new Flight { Code = "Z5555", DeparturePoint = "Irkutsk (IKT)", ArrivalPoint = "Khabarovsk (KHV)", DepartureDateTime = new DateTime(2025, 10, 29, 15, 20, 0), ArrivalDateTime = new DateTime(2025, 10, 29, 19, 50, 0), AircraftModel = Models[9] }
        };

        // Passengers
        Passengers = new()
        {
            new Passenger { PassportNumber = "4244-123456", FullName = "Ivanov Ivan Ivanovic", BirthDate = new DateOnly(1985, 3, 12) },
            new Passenger { PassportNumber = "4244-234567", FullName = "Petrova Maria Sergeevna", BirthDate = new DateOnly(1990, 7, 22) },
            new Passenger { PassportNumber = "4244-345678", FullName = "Sidorov Alexey Vladimirovich", BirthDate = new DateOnly(1978, 11, 5) },
            new Passenger { PassportNumber = "4244-456789", FullName = "Kuznetsova Anna Olegovna", BirthDate = new DateOnly(2000, 1, 30) },
            new Passenger { PassportNumber = "4202-567890", FullName = "Smirnov Dmitry Andreevich", BirthDate = new DateOnly(1982, 9, 14) },
            new Passenger { PassportNumber = "4201-678901", FullName = "Popova Ekaterina Nikolaevna", BirthDate = new DateOnly(1995, 4, 18) },
            new Passenger { PassportNumber = "4568-789012", FullName = "Volkov Sergey Pavlovich", BirthDate = new DateOnly(1970, 12, 25) },
            new Passenger { PassportNumber = "4857-890123", FullName = "Morozova Olga Viktorovna", BirthDate = new DateOnly(1988, 6, 9) },
            new Passenger { PassportNumber = "3618-524872", FullName = "Lebedev Artyom Yuryevich", BirthDate = new DateOnly(1992, 8, 3) },
            new Passenger { PassportNumber = "8574-658974", FullName = "Novikova Daria Igorevna", BirthDate = new DateOnly(1997, 2, 14) },
            new Passenger { PassportNumber = "1111-111111", FullName = "Abramov Nikolay Petrovich", BirthDate = new DateOnly(1983, 5, 10) },
            new Passenger { PassportNumber = "2222-222222", FullName = "Belova Vera Stepanovna", BirthDate = new DateOnly(1991, 12, 3) },
            new Passenger { PassportNumber = "3333-333333", FullName = "Grigoryev Maxim Igorevich", BirthDate = new DateOnly(1987, 8, 22) },
            new Passenger { PassportNumber = "4444-444444", FullName = "Dmitrieva Sofya Andreevna", BirthDate = new DateOnly(1999, 3, 17) },
            new Passenger { PassportNumber = "5555-555555", FullName = "Efimov Roman Valeryevich", BirthDate = new DateOnly(1975, 11, 30) },
            new Passenger { PassportNumber = "6666-666666", FullName = "Zhukova Polina Dmitrievna", BirthDate = new DateOnly(1994, 7, 8) },
            new Passenger { PassportNumber = "7777-777777", FullName = "Zaitsev Ilya Olegovich", BirthDate = new DateOnly(1989, 1, 15) },
            new Passenger { PassportNumber = "8888-888888", FullName = "Ivanova Kseniya Sergeevna", BirthDate = new DateOnly(1996, 9, 25) },
            new Passenger { PassportNumber = "9999-999999", FullName = "Kozlov Vladislav Yuryevich", BirthDate = new DateOnly(1981, 4, 12) },
            new Passenger { PassportNumber = "0041-125874", FullName = "Larionova Alina Viktorovna", BirthDate = new DateOnly(1993, 6, 20) },
            new Passenger { PassportNumber = "8547-123456", FullName = "Makarov Daniil Pavlovich", BirthDate = new DateOnly(1986, 10, 5) },
            new Passenger { PassportNumber = "3657-234567", FullName = "Nesterova Elizaveta Mikhailovna", BirthDate = new DateOnly(1998, 2, 28) },
            new Passenger { PassportNumber = "5241-658923", FullName = "Preobrazhenskaya Daria Vyacheslavovna", BirthDate = new DateOnly(1992, 5, 15) }
        };

        // Tickets
        Tickets = new()
        {
            new Ticket { Flight = Flights[0], Passenger = Passengers[0], SeatNumber = "12A", IsHandLuggage = true, TotalBaggageWeight = 23.5f },
            new Ticket { Flight = Flights[0], Passenger = Passengers[1], SeatNumber = "12B", IsHandLuggage = true, TotalBaggageWeight = 0},
            new Ticket { Flight = Flights[0], Passenger = Passengers[2], SeatNumber = "12C", IsHandLuggage = false, TotalBaggageWeight = 0 },
            new Ticket { Flight = Flights[0], Passenger = Passengers[11], SeatNumber = "13A", IsHandLuggage = true, TotalBaggageWeight = 18.0f },
            new Ticket { Flight = Flights[0], Passenger = Passengers[12], SeatNumber = "13B", IsHandLuggage = false, TotalBaggageWeight = 25.0f },

            new Ticket { Flight = Flights[1], Passenger = Passengers[3], SeatNumber = "15C", IsHandLuggage = false, TotalBaggageWeight = 30.0f },
            new Ticket { Flight = Flights[1], Passenger = Passengers[4], SeatNumber = "15D", IsHandLuggage = true, TotalBaggageWeight = 0 },
            new Ticket { Flight = Flights[1], Passenger = Passengers[13], SeatNumber = "16A", IsHandLuggage = false, TotalBaggageWeight = 22.5f },

            new Ticket { Flight = Flights[2], Passenger = Passengers[5], SeatNumber = "20F", IsHandLuggage = true, TotalBaggageWeight = 0 },
            new Ticket { Flight = Flights[2], Passenger = Passengers[6], SeatNumber = "21A", IsHandLuggage = false, TotalBaggageWeight = 32.7f },
            new Ticket { Flight = Flights[2], Passenger = Passengers[7], SeatNumber = "21B", IsHandLuggage = true, TotalBaggageWeight = 20.0f },
            new Ticket { Flight = Flights[2], Passenger = Passengers[8], SeatNumber = "21C", IsHandLuggage = false, TotalBaggageWeight = 28.5f },
            new Ticket { Flight = Flights[2], Passenger = Passengers[14], SeatNumber = "22A", IsHandLuggage = true, TotalBaggageWeight = 0 },
            new Ticket { Flight = Flights[2], Passenger = Passengers[15], SeatNumber = "22B", IsHandLuggage = false, TotalBaggageWeight = 19.8f },

            new Ticket { Flight = Flights[3], Passenger = Passengers[9], SeatNumber = "8D", IsHandLuggage = true, TotalBaggageWeight = 18.2f },
            new Ticket { Flight = Flights[3], Passenger = Passengers[16], SeatNumber = "8E", IsHandLuggage = false, TotalBaggageWeight = 0 },

            new Ticket { Flight = Flights[4], Passenger = Passengers[10], SeatNumber = "10B", IsHandLuggage = false, TotalBaggageWeight = 25.0f },
            new Ticket { Flight = Flights[4], Passenger = Passengers[17], SeatNumber = "10C", IsHandLuggage = true, TotalBaggageWeight = 0 },

            new Ticket { Flight = Flights[5], Passenger = Passengers[18], SeatNumber = "14E", IsHandLuggage = true, TotalBaggageWeight = 0 },
            new Ticket { Flight = Flights[6], Passenger = Passengers[19], SeatNumber = "5A", IsHandLuggage = false, TotalBaggageWeight = 32.7f },
            new Ticket { Flight = Flights[7], Passenger = Passengers[20], SeatNumber = "18C", IsHandLuggage = true, TotalBaggageWeight = 20.0f },
            new Ticket { Flight = Flights[8], Passenger = Passengers[21], SeatNumber = "7F", IsHandLuggage = false, TotalBaggageWeight = 28.5f },
            new Ticket { Flight = Flights[9], Passenger = Passengers[22], SeatNumber = "11D", IsHandLuggage = true, TotalBaggageWeight = 0 }
        };
    }
}
