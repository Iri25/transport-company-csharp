using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.form
{
    public class Controller : IObserver
    {
        private readonly IServices server;
        private User currentUser;

        public Controller(IServices server)
        {
            this.server = server;
            currentUser = null;
        }

        public List<User> LoggedIn(User user)
        {
            List<User> users = new List<User>();

            server.Login(user, this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
            users.Add(user);

            return users;
        }

        internal object GetAllFlights()
        {
            throw new NotImplementedException();
        }

        internal object GetAllDestination()
        {
            throw new NotImplementedException();
        }

        public void LoggedOut(User user)
        {
            server.Logout(currentUser, this);
            Console.WriteLine("Logout succeeded ....");
            currentUser = null;
        }

        internal object SearchFlights(string destination, string date)
        {
            throw new NotImplementedException();
        }

        internal object InitializeFlightTable(string destination, string date)
        {
            throw new NotImplementedException();
        }

        internal void BuyTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
