using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class StreamMaster : UtilityBase, IStreamMaster
    {
        public StreamMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllStreamList(int DepartmentID)
        {
            return UnitOfWork.StreamMasterRepository.GetAllStreamList(DepartmentID);
        }
        public List<StreamMasterDataModel> GetByID(int StreamMappingID)
        {
            return UnitOfWork.StreamMasterRepository.GetByID(StreamMappingID);
        }
        public bool SaveData(StreamMasterDataModel request)
        {
            return UnitOfWork.StreamMasterRepository.SaveData(request);
        }
        public bool DeleteData(int StreamMappingID)
        {
            return UnitOfWork.StreamMasterRepository.DeleteData(StreamMappingID);
        }

        public bool IfExists(int StreamMappingID, int CourseLevelID, int CourseID, int DepartmentID, int StreamID)
        {
            return UnitOfWork.StreamMasterRepository.IfExists(StreamMappingID, CourseLevelID, CourseID, DepartmentID, StreamID);
        }


    }
}
