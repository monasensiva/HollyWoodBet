using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBUi.Models
{
    public class DataValidation
    {
        public class ValidationCheckBox : RequiredAttribute
        {
            public override bool IsValid(object value)
            {
                return (bool)value;
            }
        }
    }
}