using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;

namespace TritonExpress.DAL
{
    #region Data
    public class Data : IData
    {
        #region Properties
        private TritonExpressDevContext _tritonExpressDevContext;
        #endregion

        #region Constructor
        public Data(TritonExpressDevContext tritonExpressDevContext) 
        {
            _tritonExpressDevContext = tritonExpressDevContext;
        }
        #endregion

        #region Methods

        #region Branch
        public IEnumerable<Branch> GetBranches()
        {
            return _tritonExpressDevContext.Branches.ToList();
        }

        public Branch GetBranch(int BranchID)
        {
            var branch = _tritonExpressDevContext.Branches.Where(b => b.Id == BranchID).SingleOrDefault();

            if (branch != null)
            {
                return branch;
            }

            return null;
        }
        public async Task<bool> AddBranch(Branch branch)
        {
            try
            {
                _tritonExpressDevContext.Add<Branch>(branch);
                await _tritonExpressDevContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Vehicle
        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            try
            {
                _tritonExpressDevContext.Add<Vehicle>(vehicle);
                await _tritonExpressDevContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _tritonExpressDevContext.Vehicles.ToList();
        }

        public Vehicle GetVehicle(int VehicleID)
        {
            var vehicle = _tritonExpressDevContext.Vehicles.Where(b => b.Id == VehicleID).SingleOrDefault();

            if (vehicle != null)
            {
                return vehicle;
            }

            return null;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle) 
        { 
            var _vehicle = _tritonExpressDevContext.Vehicles.Where(b => b.Id == vehicle.Id).SingleOrDefault();

            if (_vehicle != null) 
            {
                _vehicle.LicensePlateNumber = vehicle.LicensePlateNumber;
                _vehicle.Make = vehicle.Make;
                _vehicle.Model = vehicle.Model;
                _vehicle.Type = vehicle.Type;
                _vehicle.FkBranchId = vehicle.FkBranchId;

                _tritonExpressDevContext.Vehicles.Update(_vehicle);
                await _tritonExpressDevContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public IEnumerable<Vehicle> SearchVehicle(Vehicle vehicle)
        {
            var vehicles = _tritonExpressDevContext.Vehicles.Where(b => b.LicensePlateNumber == vehicle.LicensePlateNumber 
                                                                    || b.Make == vehicle.Make
                                                                    || b.Model == vehicle.Model
                                                                    || b.Type == vehicle.Type
                                                                    || (b.FkBranchId == vehicle.FkBranchId && vehicle.FkBranchId != null)).ToList();

            if (vehicles.Any())
            {
                return vehicles;
            }

            else if (vehicle.LicensePlateNumber == null && vehicle.Make == null && vehicle.Model == null && vehicle.Type == null && vehicle.FkBranchId == null) 
            {
                return _tritonExpressDevContext.Vehicles.ToList();
            }

            return null;
        }

        #endregion

        #region Waybill
        public async Task<bool> AddWayBill(WayBill wayBill)
        {
            try
            {
                _tritonExpressDevContext.Add<WayBill>(wayBill);
                await _tritonExpressDevContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddVehicleWayBillRef(int VehicleID, int WayBillID)
        {
            try
            {
                _tritonExpressDevContext.Add<VehicleWayBillRef>(new VehicleWayBillRef { FkVehicleId = VehicleID, FkWayBillId = WayBillID });
                await _tritonExpressDevContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<WayBill> GetWayBills()
        {
            return _tritonExpressDevContext.WayBills.ToList();
        }

        public WayBill GetWayBill(int WayBillID)
        {
            var wayBill = _tritonExpressDevContext.WayBills.Where(b => b.Id == WayBillID).SingleOrDefault();

            if (wayBill != null)
            {
                return wayBill;
            }

            return null;
        }

        public IEnumerable<WayBill> GetWayBillsAssigned(int VehicleID)
        {

            var waybillIDs = _tritonExpressDevContext.VehicleWayBillRefs.Where(v => v.FkVehicleId == VehicleID).Select(a => a.FkWayBillId).ToArray();

            if (waybillIDs != null && waybillIDs.Count() > 0)
            {
                var wayBillsList = _tritonExpressDevContext.WayBills.Where(b => waybillIDs.Contains(b.Id)).ToList();

                if (wayBillsList != null && wayBillsList.Count() > 0)
                {
                    return wayBillsList;
                }
            }

            return null;
        }

        public WayBill GetWayBill(string ReferenceNumber)
        {
            var wayBill = _tritonExpressDevContext.WayBills.Where(b => b.ReferenceNumber == ReferenceNumber).SingleOrDefault();

            if (wayBill != null)
            {
                return wayBill;
            }

            return null;
        }

        public async Task<bool> UpdateWayBill(WayBill wayBill)
        {
            _tritonExpressDevContext.WayBills.Update(wayBill);
            await _tritonExpressDevContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region ShippersInformation
        public bool AddShippersInformation(ShippersInformation obj)
        {
            try
            {
                _tritonExpressDevContext.Add<ShippersInformation>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateShippersInformation(ShippersInformation obj)
        {
            try
            {
                _tritonExpressDevContext.Update<ShippersInformation>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ShippersInformation GetShippersInformation(int WayBillID)
        {
            try
            {
                var _shipper = _tritonExpressDevContext.ShippersInformations.Where(s => s.FkWayBillId == WayBillID).SingleOrDefault();
                
                if (_shipper != null)
                {
                    return _shipper;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ReceiversInformation
        public bool AddReceiversInformation(ReceiversInformation obj)
        {
            try
            {
                _tritonExpressDevContext.Add<ReceiversInformation>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateReceiversInformation(ReceiversInformation obj)
        {
            try
            {
                _tritonExpressDevContext.Update<ReceiversInformation>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ReceiversInformation GetReceiversInformation(int WayBillID)
        {
            try
            {
                var _receiver = _tritonExpressDevContext.ReceiversInformations.Where(s => s.FkWayBillId == WayBillID).SingleOrDefault();

                if (_receiver != null)
                {
                    return _receiver;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Charge
        public bool AddCharge(Charge obj)
        {
            try
            {
                _tritonExpressDevContext.Add<Charge>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCharge(Charge obj)
        {
            try
            {
                _tritonExpressDevContext.Update<Charge>(obj);
                _tritonExpressDevContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Charge GetCharge(int WayBillID)
        {
            try
            {
                var _charge = _tritonExpressDevContext.Charges.Where(s => s.FkWayBillId == WayBillID).SingleOrDefault();

                if (_charge != null)
                {
                    return _charge;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region IData
    public interface IData
    {
        Branch GetBranch(int BranchID);
        IEnumerable<Branch> GetBranches();
        Task<bool> AddBranch(Branch branch);
        Task<bool> AddVehicle(Vehicle vehicle);
        Vehicle GetVehicle(int VehicleID);
        IEnumerable<Vehicle> GetVehicles();
        Task<bool> UpdateVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> SearchVehicle(Vehicle vehicle);
        Task<bool> AddWayBill(WayBill wayBill);
        IEnumerable<WayBill> GetWayBills();
        WayBill GetWayBill(int WayBillID);
        WayBill GetWayBill(string ReferenceNumber);
        bool AddShippersInformation(ShippersInformation obj);
        bool AddReceiversInformation(ReceiversInformation obj);
        bool AddCharge(Charge obj);
        Task<bool> UpdateWayBill(WayBill wayBill);
        bool UpdateShippersInformation(ShippersInformation obj);
        bool UpdateReceiversInformation(ReceiversInformation obj);
        bool UpdateCharge(Charge obj);
        Task<bool> AddVehicleWayBillRef(int VehicleID, int WayBillID);
        IEnumerable<WayBill> GetWayBillsAssigned(int VehicleID);
        ShippersInformation GetShippersInformation(int WayBillID);
        ReceiversInformation GetReceiversInformation(int WayBillID);
        Charge GetCharge(int WayBillID);
    }
    #endregion
}
