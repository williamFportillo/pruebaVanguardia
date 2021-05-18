using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.API.Models
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
    }
}
