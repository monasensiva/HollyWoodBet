using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBUi.Models
{
    public class UiEventDetail
    {

        public int EventDetailId { get; set; }

       
        public string EventDetailname { get; set; }

        
        public int EventDetailNumber { get; set; }

       
        public decimal EventDetailOdd { get; set; }

        
        public int Finishingposition { get; set; }

        
        public bool FirstTimer { get; set; }

        public int EventId { get; set; }
        public virtual UiEvent events { get; set; }
        public int EventDetailStatusId { get; set; }
        public virtual UiEventDetailStatus eventDetailStatus { get; set; }
    }
}