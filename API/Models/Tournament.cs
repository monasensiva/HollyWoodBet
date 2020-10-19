using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "Please enter Tournament Name")]
        [Display(Name = "Tournament Name")]
        [StringLength(20)]
        public string TournamentName { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}