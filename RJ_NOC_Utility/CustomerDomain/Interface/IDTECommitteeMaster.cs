using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTECommitteeMaster
    {
        bool SaveData(DTECommitteeMasterDataModel request);
        bool IfExists(int DTECommitteeMasterID, string CommitteeType, string CommitteeName);
        List<DTECommitteeMasterDataModel> GetDTECommitteeMasterList(int DTECommitteeMasterID);
        bool DeleteCommitteeData(int DTECommitteeMasterID);

        //Save Application Commitee
       
    }
}