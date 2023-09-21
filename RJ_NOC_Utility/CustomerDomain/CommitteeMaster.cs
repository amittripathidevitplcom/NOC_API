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

        public bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel ListData)
        {
            return UnitOfWork.CommitteeMasterRepository.SaveApplicationCommitteeData(ListData);
        }
        public bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel ListData)
        {
            return UnitOfWork.CommitteeMasterRepository.SaveApplicationCommitteeData_AH(ListData);
        }

        public bool DeleteApplicationCommittee(int CommitteeMemberID)
        {
            return UnitOfWork.CommitteeMasterRepository.DeleteCommitteeData(CommitteeMemberID);
        }

        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID)
        {
            return UnitOfWork.CommitteeMasterRepository.GetApplicationCommitteeList(ApplyNocApplicationID);
        }
        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList_AH(int ApplyNocApplicationID, string ActionType)
        {
            return UnitOfWork.CommitteeMasterRepository.GetApplicationCommitteeList_AH(ApplyNocApplicationID, ActionType);
        }
        public NodelOfficerDetails_DCE GetApplicationNodelOfficer(int ApplyNocApplicationID)
        {
            return UnitOfWork.CommitteeMasterRepository.GetApplicationNodelOfficer(ApplyNocApplicationID);
        }
    }
}
