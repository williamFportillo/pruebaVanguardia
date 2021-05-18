using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Evento.Core.Entities;

namespace Evento.InfraStructure.Data.Context
{
    public class EventsDbContext : DbContext
    {

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(k => k.Id);
            //modelBuilder.Entity<Category>().Property(k => k.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Event>().HasKey(k => k.Id);
            modelBuilder.Entity<Event>().Property(k => k.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = -1,
                Name = "Conciertos"
            }, new Category { 
                Id = -2,
                Name = "Obras de teatro"
            });
            //haga seeding 
            modelBuilder.Entity<Event>().HasData(new Event {
                Id = -1,
                Name = "Evento 1",
                Amount = 5,
                Category = "Concierto",
                Price = 200
            }, new Event{
                Id = -2,
                Name = "Evento 2",
                Amount = 10,
                Category = "Concierto",
                Price = 500
            }, new Event
            {
                Id = -3,
                Name = "Evento 3",
                Amount = 7,
                Category = "Obras de teatro",
                Price = 300
            }, new Event
            {
                Id = -4,
                Name = "Evento 4",
                Amount = 15,
                Category = "Obras de teatro",
                Price = 600
            });
        }
    }
}
