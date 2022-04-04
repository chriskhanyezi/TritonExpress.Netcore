using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;
using TritonExpress.Logic.WayBills;
using TritonExpress.Models.ViewModels;

namespace TritonExpress.Netcore.Controllers
{
    [Route("WayBill")]
    [ApiController]
    public class WayBillController : ControllerBase
    {
        #region Properties
        private IWayBillLogic _wayBillLogic { get; set; }
        #endregion

        #region Constructor
        public WayBillController(IWayBillLogic wayBillLogic)
        {
            _wayBillLogic = wayBillLogic;
        }
        #endregion

        #region API Methods
        [Route("AddWayBill")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public async Task<bool> AddWayBill([FromBody] WayBillViewModel wayBill)
        {
            return await _wayBillLogic.AddWayBill(wayBill);
        }

        [Route("UpdateWayBill")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public async Task<bool> UpdateWayBill([FromBody] WayBillViewModel wayBill)
        {
            return await _wayBillLogic.UpdateWayBill(wayBill);
        }

        [Route("GetWayBill")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public WayBillViewModel GetWayBill(int WayBillID)
        {
            return _wayBillLogic.GetWayBill(WayBillID);
        }

        [Route("GetWayBillsAssigned")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public IEnumerable<WayBill> GetWayBillsAssigned(int VehicleID)
        {
            return _wayBillLogic.GetWayBillsAssigned(VehicleID);
        }


        #endregion
    }
}
