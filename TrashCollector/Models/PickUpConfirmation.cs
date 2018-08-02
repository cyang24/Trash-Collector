using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUpConfirmation
    {
        [key]

        public int Id { get; set; }

        [Display(Name = "Pick Up Confirmation")]
        public string Confirmation { get; set; }
    }
}