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
    public class TicketDbRepository : TicketRepository
    {
        private static readonly ILog log = LogManager.GetLogger("TicketDbRepository");
        private IValidator<Ticket> validator;

        public TicketDbRepository() { }

        public TicketDbRepository(IValidator<Ticket> validator)
        {
            log.Info("Creating TicketDbRepository ");
            this.validator = validator;
        }

        public Ticket FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Tickets WHERE id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = id;
                    command.Parameters.Add(dbDataParameterId);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            int idTicket = dataReader.GetInt32(0);
                            string clientName = dataReader.GetString(1);
                            string touristsName = dataReader.GetString(2);
                            string clientAddress = dataReader.GetString(3);
                            int numberOfSeats = dataReader.GetInt32(4);
                            int idFlight = dataReader.GetInt32(5);

                            Ticket ticket = new Ticket(idTicket, clientName, touristsName, clientAddress, numberOfSeats, idFlight);

                            log.InfoFormat("Exiting findOne with value {0}", ticket);
                            return ticket;
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

        public IEnumerable<Ticket> FindAll()
        {
            IDbConnection connection = DbUtils.getConnection();
            IList<Ticket> tickets = new List<Ticket>();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Tickets";

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            int id = dataReader.GetInt32(0);
                            string clientName = dataReader.GetString(1);
                            string touristsName = dataReader.GetString(2);
                            string clientAddress = dataReader.GetString(3);
                            int numberOfSeats = dataReader.GetInt32(4);
                            int idFlight = dataReader.GetInt32(5);

                            Ticket ticket = new Ticket(id, clientName, touristsName, clientAddress, numberOfSeats, idFlight);

                            tickets.Add(ticket);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", exception.Message);
            }
            return tickets;
        }

        public void Save(Ticket entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity must be not null!");

            //validator.Validate(entity);

            var connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Tickets (id, clientName, touristsName, clientAddress, numberOfSeats, idFlight) VALUES (@id, @clientName, @touristsName, @clientAddress, @numberOfSeats, @idFlight)";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterClientName = command.CreateParameter();
                    dbDataParameterClientName.ParameterName = "@clientName";
                    dbDataParameterClientName.Value = entity.ClientName;
                    command.Parameters.Add(dbDataParameterClientName);

                    var dbDataParameterTouristsName = command.CreateParameter();
                    dbDataParameterTouristsName.ParameterName = "@touristsName";
                    dbDataParameterTouristsName.Value = entity.TouristsName;
                    command.Parameters.Add(dbDataParameterTouristsName);

                    var dbDataParameterClientAddress = command.CreateParameter();
                    dbDataParameterClientAddress.ParameterName = "@clientAddress";
                    dbDataParameterClientAddress.Value = entity.ClientAddress;
                    command.Parameters.Add(dbDataParameterClientAddress);

                    var dbDataParameterNumberOfSeats = command.CreateParameter();
                    dbDataParameterNumberOfSeats.ParameterName = "@numberOfSeats";
                    dbDataParameterNumberOfSeats.Value = entity.NumberOfSeats;
                    command.Parameters.Add(dbDataParameterNumberOfSeats);

                    var dbDataParameterIdFlight = command.CreateParameter();
                    dbDataParameterIdFlight.ParameterName = "@idFlight";
                    dbDataParameterIdFlight.Value = entity.IdFlight;
                    command.Parameters.Add(dbDataParameterIdFlight);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No ticket added!");
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

        public void Update(Ticket entity)
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
                    command.CommandText = "UPDATE Tickets SET id={@id}, clientName={@clientName}, touritsName={@touritsName}, clientAddress={@clientAddress}, numberOfSeats={@numberOfSeats}, idFlight={@idFlight}) where id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterClientName = command.CreateParameter();
                    dbDataParameterClientName.ParameterName = "@clientName";
                    dbDataParameterClientName.Value = entity.ClientName;
                    command.Parameters.Add(dbDataParameterClientName);

                    var dbDataParameterTouristsName = command.CreateParameter();
                    dbDataParameterTouristsName.ParameterName = "@touristsName";
                    dbDataParameterTouristsName.Value = entity.TouristsName;
                    command.Parameters.Add(dbDataParameterTouristsName);

                    var dbDataParameterClientAddress = command.CreateParameter();
                    dbDataParameterClientAddress.ParameterName = "@clientAddress";
                    dbDataParameterClientAddress.Value = entity.ClientAddress;
                    command.Parameters.Add(dbDataParameterClientAddress);

                    var dbDataParameterNumberOfSeats = command.CreateParameter();
                    dbDataParameterTouristsName.ParameterName = "@numberOfSeats";
                    dbDataParameterNumberOfSeats.Value = entity.NumberOfSeats;
                    command.Parameters.Add(dbDataParameterNumberOfSeats);

                    var dbDataParameterIdFlight = command.CreateParameter();
                    dbDataParameterIdFlight.ParameterName = "@idFlight";
                    dbDataParameterIdFlight.Value = entity.IdFlight;
                    command.Parameters.Add(dbDataParameterIdFlight);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No ticket added !");
                    else
                        log.InfoFormat("Saved the ticket {0}", entity);
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
                Ticket entity = FindOne(id);

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Tickets WHERE id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No ticket delete!");
                    else
                    {
                        log.InfoFormat("Deleted Ticket{0}", entity);

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
