using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerAndFees
    {
        public IEnumerable <PickUpDays> PickUpDays{ get; set; }
        public IEnumerable <Customer> Customer { get; set; }

    }
}