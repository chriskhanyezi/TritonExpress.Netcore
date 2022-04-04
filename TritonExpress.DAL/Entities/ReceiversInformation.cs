using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class ReceiversInformation
    {
        public int Id { get; set; }
        public string ReceiverCompanyName { get; set; }
        public string ReceiverContactName { get; set; }
        public string ReceiverAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? ActualShipmentReceivedByDate { get; set; }
        public int FkWayBillId { get; set; }
    }
}
