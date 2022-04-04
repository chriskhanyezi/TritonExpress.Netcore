using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;
using TritonExpress.Logic.Http;
using TritonExpress.Models.ViewModels;
using TritonExpress.Netcore.Models;

namespace TritonExpress.Netcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataHttpClient _dataHttpClient;

        public HomeController(IDataHttpClient dataHttpClient)
        {
            _dataHttpClient = dataHttpClient;
        }

        public IActionResult Index()
        {
            return RedirectToAction("SearchVehicle", "Home");
        }
       
        public IActionResult SearchVehicle()
        {
            return View(new List<VehicleViewModel>());
        }

        [HttpPost]
        public IActionResult SearchVehicle(VehicleViewModel vehicle)
        {
            return View(_dataHttpClient.SearchVehicle(vehicle).Result);
        }

        public IActionResult AddVehicle()
        {
            return View(new VehicleViewModel());
        }

        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel vehicle)
        {
            _dataHttpClient.AddVehicle(vehicle).ConfigureAwait(false);
            return RedirectToAction("SearchVehicle", "Home");
        }

        public IActionResult UpdateVehicle(int Id)
        {
            return View(_dataHttpClient.GetVehicle(Id).Result);
        }

        [HttpPost]
        public IActionResult UpdateVehicle(VehicleViewModel vehicle)
        {
            _dataHttpClient.UpdateVehicle(vehicle).ConfigureAwait(false);
            return RedirectToAction("SearchVehicle", "Home");
        }

        public IActionResult AddWayBill(int Id)
        {
            return View(new WayBillViewModel { VehicleID = Id });
        }

        [HttpPost]
        public IActionResult AddWayBill(WayBillViewModel waybill)
        {
            _dataHttpClient.AddWayBill(waybill).ConfigureAwait(false);
            return RedirectToAction("SearchVehicle", "Home");
        }

        public IActionResult ViewWayBills(int Id)
        {
            return View("WaybillsPartial", _dataHttpClient.ViewWayBills(Id).Result);
        }

        public IActionResult UpdateWayBill(int Id)
        {
            return View(_dataHttpClient.GetWayBill(Id).Result);
        }

        [HttpPost]
        public IActionResult UpdateWayBill(WayBillViewModel model)
        {
            _dataHttpClient.UpdateWayBill(model).ConfigureAwait(false);
            return RedirectToAction("SearchVehicle", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
