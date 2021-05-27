using FlightCompany.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.repository
{
    interface FlightRepository : IRepository<int, Flight>
    {
        Flight FindOne(int id);

        IEnumerable<Flight> FindAll();

        void Save(Flight entity);

        void Update(Flight entity);

        void Delete(int id);
    }
}
