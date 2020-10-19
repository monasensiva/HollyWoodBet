using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBUi.Models
{
    public class UiEvent
    {
    
        public int EventId { get; set; }

       
        public string EventName { get; set; }

        public int EventNumber { get; set; }

       
        public DateTime EventDateTime { get; set; }

     
        public DateTime EventEndDateTime { get; set; }

      
        public bool AutoClose { get; set; }

        public int TournamentId { get; set; }
        public virtual UiTournament tournament { get; set; }
    }
}