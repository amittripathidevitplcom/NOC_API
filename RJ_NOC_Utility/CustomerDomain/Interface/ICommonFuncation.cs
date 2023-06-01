using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICommonFuncation
    {
        string UploadFilePath();
        List<CommonDataModel_DocumentMasterList> DocumentMasterList(string DocumentType,int ProjectID);
        List<CommonDataModel_EmployeeDocumentList> ProjectWise_EmployeeDocumentList(int ProjectID, int EmployeeID);
        List<DataTable> EmployeeProfileDetails(int EmployeeID);
    }
}
