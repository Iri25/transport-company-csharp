using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.validators;

namespace Persistence.database
{
    public class FlightDbRepository : FlightRepository
    {
        private static readonly ILog log = LogManager.GetLogger("FlightDbRepository");
        private IValidator<Flight> validator;

        public FlightDbRepository() { }

        public FlightDbRepository(IValidator<Flight> validator)
        {
            log.Info("Creating FlightDbRepository ");
            this.validator = validator;
        }

        public Flight FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Flights WHERE id=@id";
                    IDbDataParameter dbDataParameter = command.CreateParameter();
                    dbDataParameter.ParameterName = "@id";
                    dbDataParameter.Value = id;
                    command.Parameters.Add(dbDataParameter);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            int idFlight = dataReader.GetInt32(0);
                            string destination = dataReader.GetString(1);
                            string departureDate = dataReader.GetString(2);
                            string departureTime = dataReader.GetString(3);
                            string airport = dataReader.GetString(4);
                            int numberOfSeatsAvailable = dataReader.GetInt32(5);

                            Flight flight = new Flight(idFlight, destination, departureDate, departureTime, airport, numberOfSeatsAvailable);

                            log.InfoFormat("Exiting findOne with value {0}", flight);
                            return flight;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", exception.Message);
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Flight> FindAll()
        {
            IDbConnection connection = DbUtils.getConnection();
            IList<Flight> flights = new List<Flight>();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Flights";

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            int id = dataReader.GetInt32(0);
                            string destination = dataReader.GetString(1);
                            string departureDate = dataReader.GetString(2);
                            string departureTime = dataReader.GetString(3);
                            string airport = dataReader.GetString(4);
                            int numberOfSeatsAvailable = dataReader.GetInt32(5);

                            Flight flight = new Flight(id, destination, departureDate, departureTime, airport, numberOfSeatsAvailable);

                            flights.Add(flight);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", exception.Message);
            }
            return flights;
        }

        public void Save(Flight entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity must be not null");

            var connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Tickets VALUES (@id, @destination, @departureDate, @departureTime, @airport, @numberOfSeatsAvailable)";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterDestination = command.CreateParameter();
                    dbDataParameterDestination.ParameterName = "@destination";
                    dbDataParameterDestination.Value = entity.Destination;
                    command.Parameters.Add(dbDataParameterDestination);

                    var dbDataParameterDepartureDate = command.CreateParameter();
                    dbDataParameterDepartureDate.ParameterName = "@departureDate";
                    dbDataParameterDepartureDate.Value = entity.DepartureDate;
                    command.Parameters.Add(dbDataParameterDepartureDate);

                    var dbDataParameterDepartureTime = command.CreateParameter();
                    dbDataParameterDepartureTime.ParameterName = "@departureTime";
                    dbDataParameterDepartureTime.Value = entity.DepartureTime;
                    command.Parameters.Add(dbDataParameterDepartureTime);

                    var dbDataParameterAirport = command.CreateParameter();
                    dbDataParameterAirport.ParameterName = "@airport";
                    dbDataParameterAirport.Value = entity.Airport;
                    command.Parameters.Add(dbDataParameterAirport);

                    var dbDataParameterNumberOfSeatsAvailable = command.CreateParameter();
                    dbDataParameterNumberOfSeatsAvailable.ParameterName = "@numberOfSeatsAvailable";
                    dbDataParameterNumberOfSeatsAvailable.Value = entity.NumberOfSeats;
                    command.Parameters.Add(dbDataParameterNumberOfSeatsAvailable);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No flight added !");
                    else
                        log.InfoFormat("Saved the flight {0}", entity);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", ex.Message);
            }
        }

        public void Update(Flight entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity must be not null!");
            validator.Validate(entity);

            if (FindOne(entity.Id) == null)
                throw new RepositoryException("Non exists flight!");

            var connection = DbUtils.getConnection();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Flights SET id={@id}, destination={@destination}, depatureDate={@depatureDate}, departureTime={@departureTime}, airport={@airport}, numberOfSeatsAvailable={@numberOfSeatsAvailable}) where id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterDestination = command.CreateParameter();
                    dbDataParameterDestination.ParameterName = "@destination";
                    dbDataParameterDestination.Value = entity.Destination;
                    command.Parameters.Add(dbDataParameterDestination);

                    var dbDataParameterDepartureDate = command.CreateParameter();
                    dbDataParameterDepartureDate.ParameterName = "@departureDate";
                    dbDataParameterDepartureDate.Value = entity.DepartureDate;
                    command.Parameters.Add(dbDataParameterDepartureDate);

                    var dbDataParameterDepartureTime = command.CreateParameter();
                    dbDataParameterDepartureTime.ParameterName = "@departureTime";
                    dbDataParameterDepartureTime.Value = entity.DepartureTime;
                    command.Parameters.Add(dbDataParameterDepartureTime);

                    var dbDataParameterAirport = command.CreateParameter();
                    dbDataParameterAirport.ParameterName = "@airport";
                    dbDataParameterAirport.Value = entity.Airport;
                    command.Parameters.Add(dbDataParameterAirport);

                    var dbDataParameterNumberOfSeatsAvailable = command.CreateParameter();
                    dbDataParameterNumberOfSeatsAvailable.ParameterName = "@numberOfSeatsAvailable";
                    dbDataParameterNumberOfSeatsAvailable.Value = entity.NumberOfSeats;
                    command.Parameters.Add(dbDataParameterNumberOfSeatsAvailable);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No flight added !");
                    else
                        log.InfoFormat("Saved the flight {0}", entity);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", ex.Message);
            }
        }


        public void Delete(int id)
        {
            if (id == null)
                throw new ArgumentException("Non existent flight!");

            var connection = DbUtils.getConnection();
            try
            {
                Flight entity = FindOne(id);

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Flights WHERE id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No flight delete!");
                    else
                    {
                        log.InfoFormat("Deleted Flight{0}", entity);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", ex.Message);
            }
        }
    }
}
