using System.Collections.Generic;
using Model;

namespace Persistence
{
    public interface FlightRepository : IRepository<int, Flight>
    {
        Flight FindOne(int id);

        IEnumerable<Flight> FindAll();

        void Save(Flight entity);

        void Update(Flight entity);

        void Delete(int id);
    }
}
