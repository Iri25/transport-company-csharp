using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.domain
{
    class User : Entity<int>
    {
        public User(int Id, string Username, string Password) : base(Id)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + ", Username: " + Username + ", Password: " + Password;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
