using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RJ_NOC_Model
{
    public class VeterinaryHospitalDataModel
    {
        public int VeterinaryHospitalID { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int TehsilID { get; set; }
        public int PanchayatSamitiID { get; set; }
        public string CityTownVillage { get; set; }
        public string HospitalName { get; set; }
        public int DistanceFromInstitute { get; set; }
        public string AuthorizedPerson { get; set; }
        public string MobileNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string RuralUrban { get; set; }
        public string Pincode { get; set; }
        public string EmailAddress { get; set; }
        public string PersonField { get; set; }
        public string Relation { get; set; }
        public string Remark { get; set; }
        public string FileUpload { get; set; }
        public string Dis_FileUpload { get; set; }
        public string FileUploadPath { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int UserID { get; set; }
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string SSOID { get; set; }
        public string District_Eng { get; set; }
        public string Division_English { get; set; }
        public string TehsilName { get; set; }
        public string PanchyatSamitiName { get; set; }
        public List<AnimalDataModel> AnimalDetails { get; set; }

        public string? Action { get; set; }
        public string? Remarks { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }

    }   
    public class AnimalDataModel
    {
        public int AnimalDetailsID { get; set; }
        public int AnimalMasterID { get; set; }
        public int MaleAnimalCount { get; set; }
        public int FemaleAnimalCount { get; set; }
        public int AnimalCount { get; set; }
        public string AnimalName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
    public class AnimalDataModel_AnimalList
    {
        public int AnimalMasterID { get; set; }
        public int DepartmentID { get; set; }
        public string AnimalName { get; set; }
    }
    public class VeterinaryHospitalDataModelList
    {
        public DataTable data { get; set; }
    }

}

