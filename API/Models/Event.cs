using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please enter Event Name")]
        [Display(Name = "Event Name")]
        [StringLength(20)]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please enter Event Number")]
        [Display(Name = "Event Number")]
        public int EventNumber { get; set; }

        [Required(ErrorMessage = "Please enter start of Event Date")]
        [Display(Name = "Event Start Date")]
        public DateTime EventDateTime { get; set; }

        [Required(ErrorMessage = "Please enter end of Event Date")]
        [Display(Name = "Event End Name")]
        public DateTime EventEndDateTime { get; set; }

        [Required(ErrorMessage = "Please select if this Event is a First Timer ")]
        [Display(Name = "AutoClose")]
        public bool AutoClose { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament tournament { get; set; }
    }
}