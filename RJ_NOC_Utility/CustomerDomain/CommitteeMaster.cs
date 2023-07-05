using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CommitteeMaster : UtilityBase, ICommitteeMaster
    {
        public CommitteeMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool IfExists(int CommitteeMasterID, string CommitteeType, string CommitteeName)
        {
            return UnitOfWork.CommitteeMasterRepository.IfExists(CommitteeMasterID, CommitteeType, CommitteeName);
        }

        public bool SaveData(CommitteeMasterDataModel request)
        {
            return UnitOfWork.CommitteeMasterRepository.SaveData(request);
        }
        public List<CommitteeMasterDataModel> GetCommitteeMasterList(int CommitteeMasterID)
        {
            return UnitOfWork.CommitteeMasterRepository.GetCommitteeMasterList(CommitteeMasterID);
        }
        public bool DeleteCommitteeData(int CommitteeMasterID)
        {
            return UnitOfWork.CommitteeMasterRepository.DeleteCommitteeData(CommitteeMasterID);
        }
    }
}
