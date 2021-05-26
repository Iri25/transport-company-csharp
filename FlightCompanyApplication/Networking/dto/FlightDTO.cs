using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class FlightDTO
    {
        public FlightDTO(int id, string Destination, string DepartureDate, string DepartureTime, string Airport, int NumberOfSeats) 
        {
            this.Id = Id;
            this.Destination = Destination;
            this.DepartureDate = DepartureDate;
            this.DepartureTime = DepartureTime;
            this.Airport = Airport;
            this.NumberOfSeats = NumberOfSeats;
            this.NumberOfSeatsAvailable = NumberOfSeats;
        }

        public int Id { get; set; }

        public string Destination { get; set; }

        public string DepartureDate { get; set; }

        public string DepartureTime { get; set; }

        public string Airport { get; set; }

        public int NumberOfSeats { get; set; }

        public int NumberOfSeatsAvailable { get; set; }
    }
}
