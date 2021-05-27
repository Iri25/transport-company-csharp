using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
    [Serializable]
    public class UserDTO
    {
        public UserDTO(int Id, string Username, string Password) 
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
