using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails 
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }


    //public class DocumentScrutiny_Action
    //{
    //    public string Action { get; set; }
    //    public string Remark { get; set; }
       
    //}
}