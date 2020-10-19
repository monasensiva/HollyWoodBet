using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class HWAPIContext : DbContext 
    {
        public HWAPIContext() : base("HollyWoodTest")
        {

        }
        public DbSet<Tournament> tournaments { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<EventDetail> eventDetails { get; set; }
        public DbSet<EventDetailStatus> eventDetailStatuses { get; set; }

    }
}