using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using static RJ_NOC_Model.VeterinaryHospitalDataModel;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IVeterinaryHospitalRepository
    {
        List<AnimalDataModel_AnimalList> GetAnimalMasterList();
        List<VeterinaryHospitalDataModelList> GetAllVeterinaryHospitalList(int CollegeID);
        VeterinaryHospitalDataModel GetVeterinaryHospitalByIDWise(int VeterinaryHospitalID);
        bool SaveData(VeterinaryHospitalDataModel request);
        bool DeleteData(int VeterinaryHospitalID);
        List<VeterinaryHospitalDataModelList> GetSeatInformationByCourse(int CollegeID, int DepartmentID);
        List<VeterinaryHospitalDataModelList> GetCourseLevelByCollegeIDAndDepartmentID_CourseWise(int CollegeID, int DepartmentID,int CourseID);
        List<CommonDataModel_DataSet> GetVeterinaryHospitalListForPdf(int DepartmentID, int CollegeID);

    }

}

