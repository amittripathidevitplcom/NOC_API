using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class Grievance : UtilityBase, IGrievance
    {
        public Grievance(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllGrievance()
        {
            return UnitOfWork.GrievanceRepository.GetAllGrievance();
        }

        public List<GrievanceDataModel> GetByID(int GrievanceID)
        {
            return UnitOfWork.GrievanceRepository.GetByID(GrievanceID);
        }
        public bool SaveData(GrievanceDataModel request)
        {
            return UnitOfWork.GrievanceRepository.SaveData(request);
        }       
        public bool DeleteData(int GrievanceID)
        {
            return UnitOfWork.GrievanceRepository.DeleteData(GrievanceID);
        }
        
        public bool IfExists(int GrievanceID, int DepartmentID, string AnimalName)
        {
            return UnitOfWork.GrievanceRepository.IfExists(GrievanceID, DepartmentID, AnimalName);
        }

        public List<DataTable> GetGrievance_AddedSSOIDWise(string SSOID)
        {
            return UnitOfWork.GrievanceRepository.GetGrievance_AddedSSOIDWise(SSOID);
        }
        public List<DataTable> Get_GrievanceTrail(int GrievanceID, string Action)
        {
            return UnitOfWork.GrievanceRepository.Get_GrievanceTrail(GrievanceID, Action);
        }
    }
}
