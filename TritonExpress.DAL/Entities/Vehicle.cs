using System;
using System.Collections.Generic;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Type { get; set; }
        public int? FkBranchId { get; set; }
    }
}
