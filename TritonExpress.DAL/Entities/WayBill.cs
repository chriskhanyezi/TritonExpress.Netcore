using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class WayBill
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? PickUpByDate { get; set; }
        public DateTime? DeliveredByDate { get; set; }
        public string PaymentOfCharge { get; set; }
        public string DescriptionOfContent { get; set; }
        public string Comments { get; set; }
    }
}
