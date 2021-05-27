using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket : Entity<int>
    {

        public Ticket(string ClientName, string TouristsName, string ClientAddress, int NumberOfSeats, int IdFlight) : this(0, ClientName, TouristsName, ClientAddress, NumberOfSeats, IdFlight)
        {
        }

        public Ticket(int Id, string ClientName, string TouristsName, string ClientAddress, int NumberOfSeats, int IdFlight) : base(Id)
        {
            this.Id = Id;
            this.ClientName = ClientName;
            this.TouristsName = TouristsName;
            this.ClientAddress = ClientAddress;
            this.NumberOfSeats = NumberOfSeats;
            this.IdFlight = IdFlight;
        }

        public string ClientName { get; set; }

        public string TouristsName { get; set; }

        public string ClientAddress { get; set; }

        public int NumberOfSeats { get; set; }

        public int IdFlight { get; set; }

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
            return "Id: " + Id + ", ClientName: " + ClientName + ", TouristsName: " + TouristsName + ", ClientAddress: " + ClientAddress + ", NumberOfSeats: " + NumberOfSeats + ", IdFlight: " + IdFlight;
        }
    }
}
