using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class FarmLandDetailsModel
    {
        public int FarmLandDetailID { get; set; }
        public int UserID { get; set; }
        public int CollegeID { get; set; }
        public string CertificatefOfTehsildarPath { get; set; }
        public string CertificatefOfTehsildarName { get; set; }
        public string CertificatefOfTehsildar_DisName { get; set; }
        public decimal TotalFarmLandArea { get; set; }
        public string FarmLandIs { get; set; }

        public string KhasraNumber { get; set; }
        public string LandOwnerName { get; set; }
        public string LandTitleCertificatePath { get; set; }
        public string LandTitleCertificateName { get; set; }
        public string LandTitleCertificate_DisName { get; set; }
        public decimal TotalLandArea { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string RuralUrban { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int TehsilID { get; set; }
        public int PanchayatSamitiID { get; set; }
        public string CityTownVillage { get; set; }
        public string Pincode { get; set; }
        public string ContactNo { get; set; }
        public string LandType { get; set; }
        public string SourceIrrigation { get; set; }
        public bool ActiveStatus { get; set; }

        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string TehsilName { get; set; }
        public string PanchayatSamitiName { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }
        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
    }

    public class FarmLandDetailsListModel
    {
        public DataTable data { get; set; }

    }
}
