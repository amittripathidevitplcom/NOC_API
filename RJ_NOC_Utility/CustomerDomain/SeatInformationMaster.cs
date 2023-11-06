using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class SeatInformationMaster : UtilityBase, ISeatInformationMaster
    {
        public SeatInformationMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetSeatInformationList()
        {
            return UnitOfWork.SeatInformationMasterRepository.GetSeatInformationList();
        }
        public List<SeatInformationMasterDataModel> GetSeatByID(int ID)
        {
            return UnitOfWork.SeatInformationMasterRepository.GetSeatByID(ID);
        }
        public bool SaveData(SeatInformationMasterDataModel request)
        {
            return UnitOfWork.SeatInformationMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int ID)
        {
            return UnitOfWork.SeatInformationMasterRepository.DeleteData(ID);
        }
        
        public bool IfExists(int ID, int DepartmentID, int CourseID)
        {
            return UnitOfWork.SeatInformationMasterRepository.IfExists(ID, DepartmentID, CourseID);
        }

       
    }
}
