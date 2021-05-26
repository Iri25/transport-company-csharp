using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public interface IServices
    {
        List<User> Login (User user, IObserver client);

        void Logout(User user, IObserver client);

        List<Flight> SearchFlights(string destination, string date);

        void BuyTicket(Ticket ticket);

        int GetSeatsAvailable(Flight flight);

        IEnumerable<Flight> InitializeFlightTable(string destination, string date);
    }
}
