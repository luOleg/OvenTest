using System;
using System.Collections.Generic;

namespace OvenTest.Model
{
    public class Flight
    {
        public List<Passenger>? Passengers { get; set; }
        public DateTime DepartureTime { get; set; }
        public string? FlightNumber { get; set; }
    }
}
