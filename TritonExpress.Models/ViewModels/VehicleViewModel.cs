using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Number Plate ")]
        public string LicensePlateNumber { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
