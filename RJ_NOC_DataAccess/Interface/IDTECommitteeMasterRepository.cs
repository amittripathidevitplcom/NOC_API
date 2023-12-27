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
        

    }

}

