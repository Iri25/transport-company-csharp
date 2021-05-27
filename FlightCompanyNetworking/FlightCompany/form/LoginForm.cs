using FlightCompany.domain;
using FlightCompany.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightCompany.form
{
    public partial class LoginForm : Form
    {
        private Service service;
        private MenuForm menuForm;

        internal void Set(Service service, MenuForm menuForm)
        {
            this.service = service;
            this.menuForm = menuForm;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
            Username.Text = "Ussername:";
            Password.Text = "Password";
            Login.Text = "Login";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 1;
            String username = textBox1.Text;
            String password = textBox2.Text;
            User user = new User(id, username, password);

            List<User> users = service.Login(user);
            if (users != null)
            {
                this.Hide();
                menuForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
