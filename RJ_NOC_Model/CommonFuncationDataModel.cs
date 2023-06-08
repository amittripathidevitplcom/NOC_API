using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CommonFuncationDataModel
    {
        public int DrID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public string POBox { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public bool RefDr { get; set; }

        public int DepartmentID { get; set; }
        public int SpecialistID { get; set; }


        public bool AutoMoneyReceive { get; set; }
        public bool AutoMoneyReceivePrint { get; set; }
        public int ServiceID { get; set; }

        public string Photo { get; set; }
        public string Dis_Photo { get; set; }

        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime RTS { get; set; }
        public string IPAddress { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class CommonDataModel_QualificationMasterDepartmentAndTypeWise
    {
        public int QualificationID { get; set; }
        public string QualificationName { get; set; }
        public string Type { get; set; }
    }

}
