using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.Models.ViewModels
{
    public class WayBillViewModel
    {
        public int Id { get; set; }
        public int VehicleID { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [Display(Name = "Pick Up By")]
        public DateTime? PickUpByDate { get; set; }
        [Required]
        [Display(Name = "Delivered By")]
        public DateTime? DeliveredByDate { get; set; }
      
        [Required]
        [Display(Name = "Company Name")]
        public string ShipperCompanyName { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string ShipperContactName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string ShipperAddress { get; set; }
        [Required]
        [Display(Name = "Telephone Number")]
        public string ShipperTelephoneNumber { get; set; }
        [Required]
        [Display(Name = "Actual Shipment Date")]
        public DateTime? ActualShipmentDate { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string ReceiverCompanyName { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string ReceiverContactName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string ReceiverAddress { get; set; }
        [Required]
        [Display(Name = "Telephone Number")]
        public string ReceiverTelephoneNumber { get; set; }
        [Required]
        [Display(Name = "Payment Of Charge")]
        public string PaymentOfCharge { get; set; }
        [Display(Name = "Description Of Contents")]
        public string DescriptionOfContent { get; set; }
        public string Comments { get; set; }
        [Required]
        [Display(Name = "Shipment Received By Date")]
        public DateTime? ActualShipmentReceivedByDate { get; set; }
        [Required]
        [Display(Name = "Number Of Parcels")]
        public int? TotalNumberOfParcels { get; set; }
        [Required]
        [Display(Name = "Weight(KGs)")]
        public int? TotalWeightInKgs { get; set; }
        [Required]
        [Display(Name = "Total Charge")]
        public decimal? TotalCharge { get; set; }
    }
}
