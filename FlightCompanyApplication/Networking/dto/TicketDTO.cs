using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class TicketDTO
    {
        public TicketDTO(int Id, string ClientName, string TouristsName, string ClientAddress, int NumberOfSeats, int IdFlight)
        {
            this.Id = Id;
            this.ClientName = ClientName;
            this.TouristsName = TouristsName;
            this.ClientAddress = ClientAddress;
            this.NumberOfSeats = NumberOfSeats;
            this.IdFlight = IdFlight;
        }

        public int Id { get; set; }

        public string ClientName { get; set; }

        public string TouristsName { get; set; }

        public string ClientAddress { get; set; }

        public int NumberOfSeats { get; set; }

        public int IdFlight { get; set; }
    }
}
