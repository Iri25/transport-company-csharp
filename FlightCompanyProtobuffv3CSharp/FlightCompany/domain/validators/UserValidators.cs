using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.domain.validators
{
    class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            string errors = "";

            int id = user.Id;
            if (id.Equals(""))
                errors += "\n Invalid id user!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the user must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the user!";
            }

            string username = user.Username;
            if (username.Equals(""))
                errors += "\n Invalid username!";

            string password = user.Password;
            if (password.Equals(""))
                errors += "\n Invalid password!";

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
