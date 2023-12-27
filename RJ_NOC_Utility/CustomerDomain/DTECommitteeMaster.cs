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
    public class DTECommitteeMaster : UtilityBase, IDTECommitteeMaster
    {
        public DTECommitteeMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool IfExists(int DTECommitteeMasterID, string CommitteeType, string CommitteeName)
        {
            return UnitOfWork.DTECommitteeMasterRepository.IfExists(DTECommitteeMasterID, CommitteeType, CommitteeName);
        }

        public bool SaveData(DTECommitteeMasterDataModel request)
        {
            return UnitOfWork.DTECommitteeMasterRepository.SaveData(request);
        }
        public List<DTECommitteeMasterDataModel> GetDTECommitteeMasterList(int DTECommitteeMasterID)
        {
            return UnitOfWork.DTECommitteeMasterRepository.GetDTECommitteeMasterList(DTECommitteeMasterID);
        }
        public bool DeleteCommitteeData(int DTECommitteeMasterID)
        {
            return UnitOfWork.DTECommitteeMasterRepository.DeleteCommitteeData(DTECommitteeMasterID);
        }

        public bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel ListData)
        {
            return UnitOfWork.DTECommitteeMasterRepository.SaveApplicationCommitteeData(ListData);
        }
        public bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel ListData)
        {
            return UnitOfWork.DTECommitteeMasterRepository.SaveApplicationCommitteeData_AH(ListData);
        }
        public bool SaveApplicationCommitteeData_Agri(PostApplicationCommitteeMemberdataModel ListData)
        {
            return UnitOfWork.DTECommitteeMasterRepository.SaveApplicationCommitteeData_Agri(ListData);
        }

        public bool DeleteApplicationCommittee(int CommitteeMemberID)
        {
            return UnitOfWork.DTECommitteeMasterRepository.DeleteCommitteeData(CommitteeMemberID);
        }

        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID)
        {
            return UnitOfWork.DTECommitteeMasterRepository.GetApplicationCommitteeList(ApplyNocApplicationID);
        }
        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList_AH(int ApplyNocApplicationID, string ActionType)
        {
            return UnitOfWork.DTECommitteeMasterRepository.GetApplicationCommitteeList_AH(ApplyNocApplicationID, ActionType);
        }
        public NodelOfficerDetails_DCE GetApplicationNodelOfficer(int ApplyNocApplicationID)
        {
            return UnitOfWork.DTECommitteeMasterRepository.GetApplicationNodelOfficer(ApplyNocApplicationID);
        }
    }
}
