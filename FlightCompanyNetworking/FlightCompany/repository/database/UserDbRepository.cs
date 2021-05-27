using FlightCompany.domain;
using FlightCompany.domain.validators;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.repository.database
{
    class UserDbRepository : UserRepository
    {
        private static readonly ILog log = LogManager.GetLogger("UserDbRepository");
        private IValidator<User> validator;

        public UserDbRepository(IValidator<User> validator)
        {
            log.Info("Creating UserDbRepository ");
            this.validator = validator;
        }

        public User FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Users WHERE id=@id";
                    IDbDataParameter dbDataParameter = command.CreateParameter();
                    dbDataParameter.ParameterName = "@id";
                    dbDataParameter.Value = id;
                    command.Parameters.Add(dbDataParameter);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            int idUser = dataReader.GetInt32(0);
                            string username = dataReader.GetString(1);
                            string password = dataReader.GetString(2);

                            User user = new User(idUser, username, password);

                            log.InfoFormat("Exiting findOne with value {0}", user);
                            return user;
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

        public IEnumerable<User> FindAll()
        {
            IDbConnection connection = DbUtils.getConnection();
            IList<User> users = new List<User>();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Users";

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            int idUser = dataReader.GetInt32(0);
                            string username = dataReader.GetString(1);
                            string password = dataReader.GetString(2);

                            User user = new User(idUser, username, password);

                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The error message is: {0}", exception.Message);
            }
            return users;
        }

        public void Save(User entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity must be not null");

            var connection = DbUtils.getConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Users VALUES (@id, @usename, @password)";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterUsername = command.CreateParameter();
                    dbDataParameterUsername.ParameterName = "@username";
                    dbDataParameterUsername.Value = entity.Username;
                    command.Parameters.Add(dbDataParameterUsername);

                    var dbDataParameterPassword = command.CreateParameter();
                    dbDataParameterPassword.ParameterName = "@password";
                    dbDataParameterPassword.Value = entity.Password;
                    command.Parameters.Add(dbDataParameterPassword);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No user added !");
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

        public void Update(User entity)
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
                    command.CommandText = "UPDATE Users SET id={@id}, username={@username}, password={@password}) where id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var dbDataParameterUsername = command.CreateParameter();
                    dbDataParameterUsername.ParameterName = "@username";
                    dbDataParameterUsername.Value = entity.Username;
                    command.Parameters.Add(dbDataParameterUsername);

                    var dbDataParameterPassword = command.CreateParameter();
                    dbDataParameterPassword.ParameterName = "@password";
                    dbDataParameterPassword.Value = entity.Password;
                    command.Parameters.Add(dbDataParameterPassword);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No user added !");
                    else
                        log.InfoFormat("Saved the user {0}", entity);
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
                User entity = FindOne(id);

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Users WHERE id=@id";

                    var dbDataParameterId = command.CreateParameter();
                    dbDataParameterId.ParameterName = "@id";
                    dbDataParameterId.Value = entity.Id;
                    command.Parameters.Add(dbDataParameterId);

                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new RepositoryException("No user delete!");
                    else
                    {
                        log.InfoFormat("Deleted User{0}", entity);

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
