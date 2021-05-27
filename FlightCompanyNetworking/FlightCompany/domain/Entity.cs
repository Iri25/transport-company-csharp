using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany.domain
{
    class Entity<ID>
    {
        public Entity(ID id)
        {
            Id = id;
        }

        public ID Id { get; set; }
    }
}
