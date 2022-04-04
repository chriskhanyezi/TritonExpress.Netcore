using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TritonExpress.DAL;
using TritonExpress.DAL.Entities;
using TritonExpress.Models.ViewModels;

namespace TritonExpress.Logic.WayBills
{
    #region WayBillLogic
    public class WayBillLogic : IWayBillLogic
    {
        #region Properties
        private IData _data { get; set; }
        #endregion

        #region Constructor
        public WayBillLogic(IData data)
        {
            _data = data;
        }
        #endregion

        #region Methods
        public async Task<bool> AddWayBill(WayBillViewModel model)
        {
            bool success = false;

            var _wayBill = GetWayBill(model);
            success =  await _data.AddWayBill(_wayBill);

            if (success) 
            {
                var _wayBillObj = _data.GetWayBill(_wayBill.ReferenceNumber);

                if (_wayBillObj != null)
                {
                    await _data.AddVehicleWayBillRef(model.VehicleID, _wayBillObj.Id);

                    success = _data.AddShippersInformation(GetShippersInformation(model));

                    success = _data.AddReceiversInformation(GetReceiversInformation(model));

                    success = _data.AddCharge(GetCharge(model));
                }

                return success;
            }

            return false;
        }

        private WayBill GetWayBill(WayBillViewModel model)
        {
            var newWayBill = new WayBill
            {
                PickUpByDate = model.PickUpByDate,
                DeliveredByDate = model.DeliveredByDate,
                Origin = model.Origin,
                Destination = model.Destination,
                PaymentOfCharge = model.PaymentOfCharge,
                DescriptionOfContent = model.DescriptionOfContent,
                Comments = model.Comments,
                ReferenceNumber = "TEXPRESS-" + DateTime.Now.ToString("yyyyMMddHHmmss")
            };

            return newWayBill;
        }

        private ShippersInformation GetShippersInformation(WayBillViewModel model) 
        {
            var shipper = new ShippersInformation 
            { 
                 ShipperCompanyName = model.ShipperCompanyName,
                 ShipperContactName = model.ShipperContactName,
                 ShipperAddress = model.ShipperAddress,
                 ActualShipmentDate = model.ActualShipmentDate,
                 TelephoneNumber = model.ShipperTelephoneNumber,
                 FkWayBillId = model.Id
            };

            return shipper;
        }

        private ReceiversInformation GetReceiversInformation(WayBillViewModel model) 
        {
            var receiver = new ReceiversInformation
            {
                ReceiverCompanyName= model.ReceiverCompanyName,
                ReceiverContactName = model.ShipperContactName,
                ReceiverAddress = model.ReceiverAddress,
                ActualShipmentReceivedByDate = model.ActualShipmentReceivedByDate,
                TelephoneNumber = model.ReceiverTelephoneNumber,
                FkWayBillId = model.Id
            };

            return receiver;
        }

        private Charge GetCharge(WayBillViewModel model) 
        {
            var charge = new Charge 
            { 
               TotalCharge = model.TotalCharge,
               TotalNumberOfParcels = model.TotalNumberOfParcels,
               TotalWeightInKgs = model.TotalWeightInKgs,
               FkWayBillId = model.Id
            };

            return charge;
        }

        public IEnumerable<WayBill> GetWayBills()
        {
            return _data.GetWayBills();
        }

        public WayBillViewModel GetWayBill(int WayBillID)
        {
            var _toReturn = new WayBillViewModel();

            var wayBill = _data.GetWayBill(WayBillID);

            if (wayBill != null)
            {
                _toReturn.PickUpByDate = wayBill.PickUpByDate;
                _toReturn.DeliveredByDate = wayBill.DeliveredByDate;
                _toReturn.Origin = wayBill.Origin;
                _toReturn.Destination = wayBill.Destination;
                _toReturn.PaymentOfCharge = wayBill.PaymentOfCharge;
                _toReturn.DescriptionOfContent = wayBill.DescriptionOfContent;
                _toReturn.Comments = wayBill.Comments;

                var _shipper = _data.GetShippersInformation(WayBillID);

                if (_shipper != null)
                {
                    _toReturn.ShipperCompanyName = _shipper.ShipperCompanyName;
                    _toReturn.ShipperContactName = _shipper.ShipperContactName;
                    _toReturn.ShipperAddress = _shipper.ShipperAddress;
                    _toReturn.ActualShipmentDate = _shipper.ActualShipmentDate;
                    _toReturn.ShipperTelephoneNumber = _shipper.TelephoneNumber;
                }

                var _receiver = _data.GetReceiversInformation(WayBillID);

                if (_receiver != null)
                {
                    _toReturn.ReceiverCompanyName = _receiver.ReceiverCompanyName;
                    _toReturn.ReceiverContactName = _receiver.ReceiverContactName;
                    _toReturn.ReceiverAddress = _receiver.ReceiverAddress;
                    _toReturn.ActualShipmentReceivedByDate = _receiver.ActualShipmentReceivedByDate;
                    _toReturn.ReceiverTelephoneNumber = _receiver.TelephoneNumber;
                }

                var _charge = _data.GetCharge(WayBillID);

                if (_charge != null)
                {
                    _toReturn.TotalCharge = _charge.TotalCharge;
                    _toReturn.TotalNumberOfParcels = _charge.TotalNumberOfParcels;
                    _toReturn.TotalWeightInKgs = _charge.TotalWeightInKgs;
                }
            }

            return _toReturn;
        }

        public IEnumerable<WayBill> GetWayBillsAssigned(int VehicleID) 
        {
            return _data.GetWayBillsAssigned(VehicleID);
        }

        public async Task<bool> UpdateWayBill(WayBillViewModel model)
        {
            bool success = false;

            var _wayBill = _data.GetWayBill(model.Id);

            _wayBill.PickUpByDate = model.PickUpByDate;
            _wayBill.DeliveredByDate = model.DeliveredByDate;
            _wayBill.Origin = model.Origin;
            _wayBill.Destination = model.Destination;
            _wayBill.PaymentOfCharge = model.PaymentOfCharge;
            _wayBill.DescriptionOfContent = model.DescriptionOfContent;
            _wayBill.Comments = model.Comments;

            success = await _data.UpdateWayBill(_wayBill);

            if (success)
            {
                success = _data.UpdateShippersInformation(GetShippersInformation(model));

                success = _data.UpdateReceiversInformation(GetReceiversInformation(model));

                success = _data.UpdateCharge(GetCharge(model));

                return success;
            }

            return false;
        }

        #endregion
    }
    #endregion

    #region IWayBillLogic
    public interface IWayBillLogic
    {
        Task<bool> AddWayBill(WayBillViewModel wayBill);
        IEnumerable<WayBill> GetWayBills();
        WayBillViewModel GetWayBill(int WayBillID);
        Task<bool> UpdateWayBill(WayBillViewModel wayBill);
        IEnumerable<WayBill> GetWayBillsAssigned(int VehicleID);
    }
    #endregion
}
