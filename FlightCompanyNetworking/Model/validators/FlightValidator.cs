using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.validators
{
    class FlightValidator : IValidator<Flight>
    {
        public void Validate(Flight flight)
        {
            string errors = "";

            long id = flight.Id;
            if (id.Equals("") || id <= 0)
                errors += "\n Invalid id flight!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the flight must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the flight!";
            }

            string destination = flight.Destination;
            if (destination.Equals(""))
                errors += "\n Invalid destination!";

            string airport = flight.Airport;
            if (airport.Equals(""))
                errors += "\n Invalid airport!";

            int numberOfSeats = flight.NumberOfSeats;
            if (numberOfSeats <= 0)
                errors += "\n Invalid number of seats available!";
            try
            {
                if (numberOfSeats <= 0)
                    errors += "\nThe number of seats available must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid number of seats available!";
            }

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
