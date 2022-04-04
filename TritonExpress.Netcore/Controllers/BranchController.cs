using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;
using TritonExpress.Logic.Branches;

namespace TritonExpress.Netcore.Controllers
{
    [Route("Branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        #region Properties
        private IBranchLogic _branchLogic { get; set; }
        #endregion

        #region Constructor
        public BranchController(IBranchLogic branchLogic)
        {
            _branchLogic = branchLogic;
        }
        #endregion

        #region API Methods
        [Route("AddBranch")]
        [EnableCors("APICorsPolicy")]
        [HttpPost]
        public async Task<bool> AddBranch([FromBody] Branch branch)
        {
           return await _branchLogic.AddBranch(branch);
        }

        [Route("Branches")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public IEnumerable<Branch> GetBranches()
        {
            return _branchLogic.GetBranches();
        }

        [Route("GetBranch")]
        [EnableCors("APICorsPolicy")]
        [HttpGet]
        public Branch GetBranch(int BranchID)
        {
            return _branchLogic.GetBranch(BranchID);
        }
        #endregion
    }
}
