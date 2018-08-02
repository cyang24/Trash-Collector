using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
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

        [Display(Name = "Invoice")]
        public double Invoice { get; set; }

        [Display(Name = "Pick Up Confirmation")]
        public string Confirmation { get; set; }

        [Display(Name = "Suspend Pick Up Start")]
        public string DateStart { get; set; }

        [Display(Name = "Suspend Pick Up End")]
        public string DateEnd { get; set; }


        [ForeignKey("PickUpDay")]

        [Display(Name = "Trash Day Selection")]
        public int PickUpDayId { get; set; }
        
        [Display(Name = "Extra Pick Up")]
        public int ExtraDayPickUp { get; set; }

        public PickUpDays PickUpDay { get; set; }

        public IEnumerable<PickUpDays> PickUpDays { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //[ForeignKey("PickUpConfirmation")]

        //[Display(Name = "Pick Up Status")]
        //public int PickUpConfirmID { get; set; }
        //public PickUpConfirmation PickUpConfirmation { get; set; }

        //public IEnumerable<PickUpConfirmation> PickUpConfirmations { get; set; }



    }
}