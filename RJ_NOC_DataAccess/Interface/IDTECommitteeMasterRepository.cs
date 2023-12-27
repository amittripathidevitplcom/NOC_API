using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTECommitteeMasterRepository
    {
        bool SaveData(DTECommitteeMasterDataModel request);
        bool IfExists(int DTECommitteeMasterID, string CommitteeType, string CommitteeName);
        List<DTECommitteeMasterDataModel> GetDTECommitteeMasterList(int DTECommitteeMasterID);
        bool DeleteCommitteeData(int DTECommitteeMasterID);

        //Save Application Commitee
        bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel ListData);
        bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel ListData);
        bool SaveApplicationCommitteeData_Agri(PostApplicationCommitteeMemberdataModel ListData);
        bool DeleteApplicationCommittee(int CommitteeMemberID);
        List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID);
        List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList_AH(int ApplyNocApplicationID, string ActionType);
        NodelOfficerDetails_DCE GetApplicationNodelOfficer(int ApplyNocApplicationID);


    }

}

