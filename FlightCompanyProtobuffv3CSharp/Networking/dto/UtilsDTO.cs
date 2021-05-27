using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Networking.dto
{
    public class UtilsDTO
    {
        public static User ToUser(UserDTO userDto)
        {
            var id = userDto.Id;
            var username = userDto.Username;
            var password = userDto.Password;
            var user = new User(id, username, password);

            return user;
        }

        public static UserDTO ToUserDto(User user)
        {
            var id = user.Id;
            var username = user.Username;
            var password = user.Password;
            var userDto = new UserDTO(id, username, password);

            return userDto;
        }

        public static Flight ToFlight(FlightDTO flightDTO)
        {
            var id = flightDTO.Id;
            var destination = flightDTO.Destination;
            var departureDate = flightDTO.DepartureDate;
            var departureTime = flightDTO.DepartureTime;
            var airport = flightDTO.Airport;
            var numberOfSeats = flightDTO.NumberOfSeats;
            var flight = new Flight(id, destination, departureDate, departureTime, airport, numberOfSeats);

            return flight;
        }

        public static FlightDTO ToFlightDto(Flight flight)
        {
            var id = flight.Id;
            var destination = flight.Destination;
            var departureDate = flight.DepartureDate;
            var departureTime = flight.DepartureTime;
            var airport = flight.Airport;
            var numberOfSeats = flight.NumberOfSeats;
            var flightDTO = new FlightDTO(id, destination, departureDate, departureTime, airport, numberOfSeats);

            return flightDTO;
        }

        public static Ticket ToTicket(TicketDTO ticketDTO)
        {
            var id = ticketDTO.Id;
            var clientName = ticketDTO.ClientName;
            var touristsName = ticketDTO.TouristsName;
            var clientaddress = ticketDTO.ClientAddress;
            var numberOfSeats = ticketDTO.NumberOfSeats;
            var idFlight = ticketDTO.IdFlight;
            var ticket = new Ticket(id, clientName, touristsName, clientaddress, numberOfSeats, idFlight);

            return ticket;
        }

        public static TicketDTO ToTicketDto(Ticket ticket)
        {
            var id = ticket.Id;
            var clientName = ticket.ClientName;
            var touristsName = ticket.TouristsName;
            var clientaddress = ticket.ClientAddress;
            var numberOfSeats = ticket.NumberOfSeats;
            var idFlight = ticket.IdFlight;
            var ticketDTO = new TicketDTO(id, clientName, touristsName, clientaddress, numberOfSeats, idFlight);

            return ticketDTO;
        }
    }
}
