using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.DAL;
using TritonExpress.DAL.Entities;

namespace TritonExpress.Logic.Branches
{
    #region
    public class BranchLogic : IBranchLogic
    {
        #region Properties
        private IData _data { get; set; }
        #endregion

        #region Constructor
        public BranchLogic(IData data) 
        {
            _data = data;
        }
        #endregion

        #region Methods

        public IEnumerable<Branch> GetBranches()
        {
            return _data.GetBranches();
        }

        public Branch GetBranch(int BranchID)
        {
            return _data.GetBranch(BranchID);
        }

        public async Task<bool> AddBranch(Branch branch)
        {
            return await _data.AddBranch(branch);
        }
        #endregion
    }
    #endregion

    #region IBranchLogic
    public interface IBranchLogic
    {
        Branch GetBranch(int BranchID);
        IEnumerable<Branch> GetBranches();
        Task<bool> AddBranch(Branch branch);
    }
    #endregion
}
