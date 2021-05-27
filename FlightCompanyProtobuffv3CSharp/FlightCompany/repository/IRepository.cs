using FlightCompany.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.repository
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);

        IEnumerable<E> FindAll();

        void Save(E entity);

        void Update(E entity);

        void Delete(ID id);
    }
}
