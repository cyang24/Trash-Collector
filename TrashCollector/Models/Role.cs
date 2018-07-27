using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Role
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }



        [ForeignKey("PickUpDays")]
        [Display(Name = "Trash Day Selection")]
        public int PickUpDayID { get; set; }
        public PickUpDays PickUpDay { get; set; }

        public IEnumerable<PickUpDays> PickUpDays { get; set; }



    }
}