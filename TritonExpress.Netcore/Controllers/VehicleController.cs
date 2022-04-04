using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;
using TritonExpress.Logic.Vehicles;

namespace TritonExpress.Netcore.Controllers
{
    [Route("Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        #region Properties
        private IVehicleLogic _vehicleLogic { get; set; }
        #endregion

        #region Constructor
        public VehicleController(IVehicleLogic vehicleLogic)
        {
            _vehicleLogic = vehicleLogic;
        }
        #endregion

        #region API Methods
        [Route("AddVehicle")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public async Task<bool> AddVehicle([FromBody] Vehicle vehicle)
        {
            return await _vehicleLogic.AddVehicle(vehicle);
        }

        [Route("Vehicles")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleLogic.GetVehicles();
        }

        [Route("GetVehicle")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public Vehicle GetVehicle(int VehicleID)
        {
            return _vehicleLogic.GetVehicle(VehicleID);
        }

        [Route("UpdateVehicle")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public async Task<bool> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            return await _vehicleLogic.UpdateVehicle(vehicle);
        }

        [Route("SearchVehicle")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public IEnumerable<Vehicle> SearchVehicle([FromBody] Vehicle vehicle)
        {
            return _vehicleLogic.SearchVehicle(vehicle);
        }
        #endregion
    }
}
