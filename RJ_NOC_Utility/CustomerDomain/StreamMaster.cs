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
        public List<CommonDataModel_DataTable> GetAllStreamList()
        {
            return UnitOfWork.StreamMasterRepository.GetAllStreamList();
        }
        public List<StreamMasterDataModel> GetByID(int StreamMasterID)
        {
            return UnitOfWork.StreamMasterRepository.GetByID(StreamMasterID);
        }
        public bool SaveData(StreamMasterDataModel request)
        {
            return UnitOfWork.StreamMasterRepository.SaveData(request);
        }
        public bool DeleteData(int StreamMasterID)
        {
            return UnitOfWork.StreamMasterRepository.DeleteData(StreamMasterID);
        }

        public bool IfExists(int StreamMasterID, int CourseLevelID, int CourseID, int DepartmentID, string StreamName)
        {
            return UnitOfWork.StreamMasterRepository.IfExists(StreamMasterID, CourseLevelID, CourseID, DepartmentID, StreamName);
        }


    }
}
