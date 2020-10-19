using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EventDetailStatus
    {
        [Key]
        public int EventDetailStatusId { get; set; }

        public string EventDetailStatusName { get; set; }
    }
}