using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
    }
}
