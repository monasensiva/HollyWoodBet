using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EventDetail
    {
        [Key]
        public int EventDetailId { get; set; }

        [Required(ErrorMessage = "Please enter Event Detail Name")]
        [Display(Name = "Event Detail Name")]
        [StringLength(20)]
        public string EventDetailname { get; set; }

        [Required(ErrorMessage = "Please enter Event Detail Number")]
        [Display(Name = "Event Detail Number")]
        public int EventDetailNumber { get; set; }

        [Required(ErrorMessage = "Please enter Event Detail Odds ")]
        [Display(Name = "Event Detail Odds")]
        public decimal EventDetailOdd { get; set; }

        [Required(ErrorMessage = "Please enter Event Finishing Position ")]
        [Display(Name = "Event Details Finishing Position")]
        public int Finishingposition { get; set; }

        [Required(ErrorMessage = "Please enter Event Details is a First Timer ")]
        [Display(Name = "Event Details First Timer ")]
        public bool FirstTimer { get; set; }

        public int EventId { get; set; }
        public virtual Event events { get; set; }
        public int EventDetailStatusId { get; set; }
        public virtual EventDetailStatus eventDetailStatus { get; set; }
    }
}