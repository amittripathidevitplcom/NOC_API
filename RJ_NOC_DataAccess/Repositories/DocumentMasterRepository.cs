using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_DataAccess.Repositories
{
    public class DocumentMasterRepository : IDocumentMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DocumentMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool SaveData(DocumentMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_DocumentMaster_IU  ";
            SqlQuery += " @DocumentMasterID='" + request.DocumentMasterID + "',@DepartmentID='" + request.DepartmentID + "',@DocumentTypeID='" + request.DocumentTypeID + "',@DocumentName='" + request.DocumentName + "',@MinSize='" + request.MinSize + "',@MaxSize='" + request.MaxSize + "',@IsCompulsory='" + request.IsCompulsory + "',@IsActiveStatus='" + request.IsActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DocumentMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetAllDocument(int DepartmentID)
        {
            string SqlQuery = " exec USP_DocumentMaster_GetData @DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DocumentMaster.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<DocumentMasterDataModel> GetDocumentMasterIDWise(int DocumentMasterID)
        {
            string SqlQuery = " exec USP_DocumentMaster_GetData @DocumentMasterID='" + DocumentMasterID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DocumentMaster.GetDataIDWise");

            List<DocumentMasterDataModel> dataModels = new List<DocumentMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DocumentMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool UpdateData(DocumentMasterDataModel request)
        {

            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            //string SqlQuery = " exec USP_DocumentMaster_IU  ";
            //SqlQuery += " @DepartmentID='" + request.DepartmentID + "',@DocumentTypeID='" + request.DocumentTypeID + "',@DocumentName='" + request.DocumentName + "',@MinSize='" + request.MinSize + "',@MaxSize='" + request.MaxSize + "',@IsCompulsory='" + request.IsCompulsory + "',@IsActiveStatus='" + request.IsActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery, "DocumentMaster.SaveData");
            //if (Rows > 0)
            //    return true;
            //else
                return false;
        }

        public bool DeleteData(int DocumentMasterID)
        {
            string SqlQuery = " Update M_DocumentMaster set ActiveStatus=0 ,IsMandatory=0, DeleteStatus=1  WHERE DID='" + DocumentMasterID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DocumentMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int DocumentMasterID,int DepartmentID, string DocumentName)
        {
            string SqlQuery = " select DocumentName from M_DocumentMaster Where DocumentName='" + DocumentName.Trim() + "'  and DepartmentID ='" + DepartmentID + "'  and DID !='" + DocumentMasterID + "'  and DeleteStatus=0 and ActiveStatus=1";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DocumentMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
