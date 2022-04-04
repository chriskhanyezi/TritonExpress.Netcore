using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class ShippersInformation
    {
        public int Id { get; set; }
        public string ShipperCompanyName { get; set; }
        public string ShipperContactName { get; set; }
        public string ShipperAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? ActualShipmentDate { get; set; }
        public int FkWayBillId { get; set; }
    }
}
