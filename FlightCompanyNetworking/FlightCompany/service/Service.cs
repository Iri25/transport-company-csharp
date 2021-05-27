using FlightCompany.domain;
using FlightCompany.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.service
{
    class Service
    {
        private IRepository<int, User> repositoryUser;
        private IRepository<int, Flight> repositoryFlight;
        private IRepository<int, Ticket> repositoryTicket;

        public Service(IRepository<int, User> repositoryUser, IRepository<int, Flight> repositoryFlight, IRepository<int, Ticket> repositoryTicket)
        {
            this.repositoryUser = repositoryUser;
            this.repositoryFlight = repositoryFlight;
            this.repositoryTicket = repositoryTicket;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return repositoryUser.FindAll();
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return repositoryFlight.FindAll();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return repositoryTicket.FindAll();
        }

        public IEnumerable<String> GetAllDestination()
        {
            List<String> destinations = new List<String>();
            foreach(Flight flight in GetAllFlights())
            {
                destinations.Add(flight.Destination);
            }
            return destinations;
        }

        public List<User> Login(User user)
        {
            List<User> users = new List<User>();
            User userLogin = repositoryUser.FindOne(user.Id);
            if (userLogin.Username == user.Username && userLogin.Password == user.Password)
                users.Add(userLogin);
            return users;
        }

        public List<Flight> SearchFlights(string destination, string date)
        {
            List<Flight> flights = new List<Flight>();
            foreach (Flight flight in GetAllFlights())
            {
                if (flight.Destination.Equals(destination) && flight.DepartureDate.Equals(date))
                    flights.Add(flight);
            }
            return flights;
        }

        public void BuyTicket(Ticket ticket)
        {
            int freeId = 0;
            foreach (Ticket ticketId in GetAllTickets())
            {
                freeId++;
                if (!freeId.Equals(ticketId.Id))
                {
                    break;
                }
            }
            freeId++;

            IEnumerable<Ticket> empty = new List<Ticket>();
            if (GetAllTickets() == empty)
                freeId++;

            Ticket ticketBuy = new Ticket(ticket.Id, ticket.ClientName, ticket.TouristsName, ticket.ClientAddress, ticket.NumberOfSeats, ticket.IdFlight);
            ticketBuy.Id = freeId;
            repositoryTicket.Save(ticketBuy);
        }

        public int GetSeatsAvailable(Flight flight)
        {
            IEnumerable<Ticket> tickets = GetAllTickets();
            int seatUnavailable = 0;
            foreach (Ticket ticket in tickets)
            {
                if (ticket.IdFlight == flight.Id)
                    seatUnavailable++;
            }
            flight.NumberOfSeatsAvailable = flight.NumberOfSeatsAvailable - seatUnavailable;
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
                    flightsUpdate.Add(flight);
                }
            }
            return flightsUpdate;
        }
    }
}
