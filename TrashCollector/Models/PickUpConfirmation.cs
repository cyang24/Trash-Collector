using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUpConfirmation
    {

        [Key]
        public string PickUpStatus { get; set;}
    }
}