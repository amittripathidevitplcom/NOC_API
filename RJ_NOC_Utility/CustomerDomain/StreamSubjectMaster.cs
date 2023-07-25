using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_DataAccess.Repositories;
using Azure.Core;
using System.Reflection;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class StreamSubjectMaster:UtilityBase, IStreamSubjectMaster
    {
        public StreamSubjectMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool DeleteData(int StreamMappingID)
        {
            return UnitOfWork.StreamSubjectMappingDetailsRepository.DeleteData(StreamMappingID);
        }

        public List<CommonDataModel_DataTable> GetAllStream(StreamSubjectMappingDetailDataModel Model)
        {
            return UnitOfWork.StreamSubjectMappingDetailsRepository.GetAllStream(Model);
        }

        public List<StreamSubjectMappingDetailDataModel> GetStreamIDWise(int StreamMappingID, string LoginSSOID)
        {
            return UnitOfWork.StreamSubjectMappingDetailsRepository.GetStreamIDWise(StreamMappingID,LoginSSOID);
        }

        public bool IfExists(StreamSubjectMappingDetailDataModel Model)
        {
            return UnitOfWork.StreamSubjectMappingDetailsRepository.IfExists(Model);
        }

        public bool SaveData(StreamSubjectMappingDetailDataModel request)
        {
            return UnitOfWork.StreamSubjectMappingDetailsRepository.SaveData(request);   
        }



    }
}
