using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.validators
{
    class TicketValidator : IValidator<Ticket>
    {
        public void Validate(Ticket ticket)
        {
            string errors = "";

            int id = ticket.Id;
            if (id.Equals(""))
                errors += "\n Invalid id ticket!";
            try
            {
                if (id < 0)
                    errors += "\nThe id of the ticket must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the ticket!";
            }

            string clientName = ticket.ClientName;
            if (clientName.Equals(""))
                errors += "\n Invalid client name!";

            string touristsName = ticket.TouristsName;
            if (touristsName.Equals(""))
                errors += "\n Invalid tourists name!";

            string clientAddress = ticket.ClientAddress;
            if (clientAddress.Equals(""))
                errors += "\n Invalid client address!";

            int numberOfSeats = ticket.NumberOfSeats;
            if (numberOfSeats.Equals(""))
                errors += "\n Invalid number of seats!";
            try
            {
                if (numberOfSeats <= 0)
                    errors += "\nThe number of seats must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid number of seats!";
            }

            if (!errors.Equals(""))
                throw new ValidationException(errors);

            int idFlight = ticket.IdFlight;
            try
            {
                if (idFlight <= 0)
                    errors += "\nThe id of the flight must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id flight!";
            }

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
