using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.DAL;
using TritonExpress.DAL.Entities;

namespace TritonExpress.Logic.Vehicles
{
    #region VehicleLogic
    public class VehicleLogic : IVehicleLogic
    {
        #region Properties
        private IData _data { get; set; }
        #endregion

        #region Constructor
        public VehicleLogic(IData data) 
        {
            _data = data;
        }
        #endregion

        #region Methods
        public async Task<bool> AddVehicle(Vehicle vehicle) 
        {
            return await _data.AddVehicle(vehicle);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _data.GetVehicles();
        }

        public Vehicle GetVehicle(int VehicleID)
        {
            return _data.GetVehicle(VehicleID);
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            return await _data.UpdateVehicle(vehicle);
        }
        public IEnumerable<Vehicle> SearchVehicle(Vehicle vehicle) 
        {
            return _data.SearchVehicle(vehicle);
        }
        #endregion
    }
    #endregion

    #region IVehicleLogic
    public interface IVehicleLogic
    {
        Task<bool> AddVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicle(int VehicleID);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> SearchVehicle(Vehicle vehicle);
    }
    #endregion
}
