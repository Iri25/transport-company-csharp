using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.form
{
    public partial class MenuForm : Form
    {
        private Controller service;
        private LoginForm loginForm;

        internal void Set(Controller service, LoginForm login)
        {
            this.service = service;
            this.loginForm = login;
            LoadData();
        }

        private void LoadData()
        {
            //comboBox1.DataSource = service.GetAllDestination();

        }

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.Text = "Main Menu";
            tabPage1.Text = "Search Flight";
            tabPage2.Text = "Buy Ticket";
            Search.Text = "Search";
            Buy.Text = "Buy";
            Logout.Text = "Logout";
            ClientName.Text = "Client Name";
            TouristsName.Text = "Tourits Name";
            ClientAddress.Text = "Client Address";
            NumberOfSeats.Text = "Number Of Seats";
            IdFlight.Text = "Id flight";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string destination = comboBox1.Text;
            string date = dateTimePicker1.Text;

            dataGridView1.DataSource = service.SearchFlights(destination, date);
            dataGridView1.DataSource = service.InitializeFlightTable(destination, date);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            string clientName = textBox1.Text;
            string touristsName = textBox2.Text;
            string clienAddress = textBox3.Text;
            string number = textBox4.Text;
            int numberOfSeats = Int32.Parse(number);
            string idF = textBox5.Text;
            int idFlight = Int32.Parse(idF);

            Ticket ticket = new Ticket(id, clientName, touristsName, clienAddress, numberOfSeats, idFlight);
            service.BuyTicket(ticket);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }
    }
}
