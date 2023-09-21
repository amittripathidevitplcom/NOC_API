using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICommitteeMaster
    {
        bool SaveData(CommitteeMasterDataModel request);
        bool IfExists(int CommitteeMasterID, string CommitteeType, string CommitteeName);
        List<CommitteeMasterDataModel> GetCommitteeMasterList(int CommitteeMasterID);
        bool DeleteCommitteeData(int CommitteeMasterID);

        //Save Application Commitee
        bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel ListData);
        bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel ListData);
        bool DeleteApplicationCommittee(int CommitteeMemberID);
        List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID);
        List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList_AH(int ApplyNocApplicationID, string ActionType);
        NodelOfficerDetails_DCE GetApplicationNodelOfficer(int ApplyNocApplicationID);
    }
}