using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : Entity<int>
    {
        public User(int Id, string Username, string Password) : base(Id)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
        }

        public User(string Username, string Password) : this(0, Username, Password)
        {
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
