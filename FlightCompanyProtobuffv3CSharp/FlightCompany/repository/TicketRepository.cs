using FlightCompany.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.repository
{
    interface TicketRepository : IRepository<int, Ticket>
    {
        Ticket FindOne(int id);

        IEnumerable<Ticket> FindAll();

        void Save(Ticket entity);

        void Update(Ticket entity);

        void Delete(int id);
    }
}
