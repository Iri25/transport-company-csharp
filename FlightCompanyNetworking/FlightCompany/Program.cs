using FlightCompany.domain;
using FlightCompany.domain.validators;
using FlightCompany.form;
using FlightCompany.repository;
using FlightCompany.repository.database;
using FlightCompany.service;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightCompany
{
    static class Program
    {
        private static IValidator<User> validatorUser;
        private static IValidator<Flight> validatorFlight;
        private static IValidator<Ticket> validatorTicket;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
            Console.WriteLine("Database...");

            IRepository<int, User> repositoryUser = new UserDbRepository(validatorUser);
            IRepository<int, Flight> repositoryFlight = new FlightDbRepository(validatorFlight);
            IRepository<int, Ticket> repositoryTicket = new TicketDbRepository(validatorTicket);

            Service service = new Service(repositoryUser, repositoryFlight, repositoryTicket);

            LoginForm loginForm = new LoginForm();
            MenuForm menuForm = new MenuForm();

            loginForm.Set(service, menuForm);
            menuForm.Set(service, loginForm);


            Application.Run(loginForm);
        }
    }
}
