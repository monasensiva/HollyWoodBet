using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBUi.Models
{
    public class UiTournament
    {
        [Key]
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "Please enter Tournament Name")]
        [Display(Name = "Tournament Name")]
        [StringLength(20)]
        public string TournamentName { get; set; }

        public virtual List<UiEvent> Events { get; set; }
    }
}