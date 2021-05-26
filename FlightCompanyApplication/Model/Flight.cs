using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Flight : Entity<int>
    {
        public Flight(int Id, string Destination, string DepartureDate, string DepartureTime, string Airport, int NumberOfSeats) : base(Id)
        {
            this.Id = Id;
            this.Destination = Destination;
            this.DepartureDate = DepartureDate;
            this.DepartureTime = DepartureTime;
            this.Airport = Airport;
            this.NumberOfSeats = NumberOfSeats;
            this.NumberOfSeatsAvailable = NumberOfSeats;
        }

        public string Destination { get; set; }

        public string DepartureDate { get; set; }

        public string DepartureTime { get; set; }

        public string Airport { get; set; }

        public int NumberOfSeats { get; set; }

        public int NumberOfSeatsAvailable { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Destination: " + Destination + ", DepartureDate: " + DepartureDate + ", DepartureTime: " + DepartureTime + ", Airport: " + Airport + ", NumberOfSeats: " + NumberOfSeats;
        }
    }
}
