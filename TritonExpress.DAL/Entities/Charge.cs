using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class Charge
    {
        public int Id { get; set; }
        public int? TotalNumberOfParcels { get; set; }
        public int? TotalWeightInKgs { get; set; }
        public decimal? TotalCharge { get; set; }
        public int FkWayBillId { get; set; }
    }
}
