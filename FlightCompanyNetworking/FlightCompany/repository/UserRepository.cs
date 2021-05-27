using FlightCompany.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.repository
{
    interface UserRepository : IRepository<int, User>
    {
        User FindOne(int id);

        IEnumerable<User> FindAll();

        void Save(User entity);

        void Update(User entity);

        void Delete(int id);
    }
}
