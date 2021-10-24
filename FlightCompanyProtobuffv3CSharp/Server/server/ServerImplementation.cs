using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence;
using Persistence.database;
using Services;

namespace Server.server
{
    public class ServerImplementation : IServices
    {
        private readonly UserRepository userRepository;
        private readonly FlightRepository flightRepository;
        private readonly TicketRepository ticketRepository;
        private readonly UserDbRepository userRepo;
        private readonly IDictionary<string, IObserver> loggedClients;

        public ServerImplementation(UserRepository userRepository, FlightRepository flightRepository, TicketRepository ticketRepository)
        {
            this.userRepository = userRepository;

            loggedClients = new Dictionary<string, IObserver>();
        }

        public ServerImplementation(UserDbRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<User> Login(User user, IObserver client)
        {
            List<User> users = new List<User>();

            User userOk = userRepository.FindOne(user.Id);
            if (userOk != null)
            {
                if (loggedClients.ContainsKey(user.Username))
                    throw new Exception("User already logged in.");
                loggedClients[user.Username] = client;
                users.Add(user);
            }
            else
                throw new Exception("Authentication failed.");

            return users;
        }

        public void Logout(User user, IObserver client)
        {
            IObserver localClient = loggedClients[user.Username];
            if (localClient == null)
                throw new Exception("User " + user.Username + " is not logged in.");
            loggedClients.Remove(user.Username);
        }

        public List<Flight> SearchFlights(string destination, string date)
        {
            List<Flight> flights = new List<Flight>();
            foreach (Flight flight in flightRepository.FindAll())
            {
                if (flight.Destination.Equals(destination) && flight.DepartureDate.Equals(date))
                    flights.Add(flight);
            }
            return flights;
        }

        public void BuyTicket(Ticket ticket)
        {
            int freeId = 0;
            foreach (Ticket ticketId in ticketRepository.FindAll())
            {
                freeId++;
                if (!freeId.Equals(ticketId.Id))
                {
                    break;
                }
            }
            freeId++;

            IEnumerable<Ticket> empty = new List<Ticket>();
            if (ticketRepository.FindAll() == empty)
                freeId++;

            Ticket ticketBuy = new Ticket(ticket.Id, ticket.ClientName, ticket.TouristsName, ticket.ClientAddress, ticket.NumberOfSeats, ticket.IdFlight);
            ticketBuy.Id = freeId;
            ticketRepository.Save(ticketBuy);
        }

        public int GetSeatsAvailable(Flight flight)
        {
            IEnumerable<Ticket> tickets = ticketRepository.FindAll();
            int seatUnavailable = 0;
            foreach (Ticket ticket in tickets)
            {
                if (ticket.IdFlight == flight.Id)
                    seatUnavailable++;
            }
            flight.NumberOfSeatsAvailable = flight.NumberOfSeatsAvailable - seatUnavailable;
            return flight.NumberOfSeatsAvailable;
        }

        public int GetSeatsAvailableUpdate(Flight flight)
        {
            flight.NumberOfSeatsAvailable = flight.NumberOfSeatsAvailable - 1;
            return flight.NumberOfSeatsAvailable;
        }

        public IEnumerable<Flight> InitializeFlightTable(string destination, string date)
        {
            List<Flight> flightsUpdate = new List<Flight>();

            if (destination == null || date == null)
                Console.WriteLine("Empty field!");
            else
            {
                List<Flight> flights = SearchFlights(destination, date);
                foreach (Flight flight in flights)
                {
                    if (flight.NumberOfSeats == flight.NumberOfSeatsAvailable)
                        flight.NumberOfSeatsAvailable = GetSeatsAvailable(flight);
                    else
                        flight.NumberOfSeatsAvailable = GetSeatsAvailableUpdate(flight);
                    flightsUpdate.Add(flight);
                }
            }
            return flightsUpdate;
        }
    }

}

