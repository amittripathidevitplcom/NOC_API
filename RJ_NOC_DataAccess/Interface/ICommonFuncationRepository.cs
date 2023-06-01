using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICommonFuncationRepository
    {
        string UploadFilePath();

        List<CommonDataModel_DocumentMasterList> DocumentMasterList(string DocumentType, int ProjectID);
        List<CommonDataModel_EmployeeDocumentList> ProjectWise_EmployeeDocumentList(int ProjectID, int EmployeeID);
        List<DataTable> EmployeeProfileDetails(int EmployeeID);
    }
}

