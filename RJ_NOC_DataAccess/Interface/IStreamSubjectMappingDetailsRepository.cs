using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IStreamSubjectMappingDetailsRepository
    {
        bool SaveData(StreamSubjectMappingDetailDataModel request);
        List<CommonDataModel_DataTable> GetAllStream(StreamSubjectMappingDetailDataModel Model);
        bool DeleteData(int StreamMappingID);
        List<StreamSubjectMappingDetailDataModel> GetStreamIDWise(int StreamMappingID, string LoginSSOID);

    }
}
