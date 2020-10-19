using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBUi.Models
{
    public class UiEventDetailStatus
    {
        [Key]
        public int EventDetailStatusId { get; set; }

        public string EventDetailStatusName { get; set; }
    }
}