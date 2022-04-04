using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class VehicleWayBillRef
    {
        public int Id { get; set; }
        public int FkVehicleId { get; set; }
        public int FkWayBillId { get; set; }
    }
}
