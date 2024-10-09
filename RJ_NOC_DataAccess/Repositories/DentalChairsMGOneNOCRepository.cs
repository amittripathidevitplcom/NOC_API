using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class DentalChairsMGOneNOCRepository: IDentalChairsMGOneNOCRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DentalChairsMGOneNOCRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveDentalChairs(DentalChairsMGOneNOCModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveDentalChairs_ApplyNoc_IU_MGOne  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNocID + "',@CollegeID='" + request.CollegeID + "',@TotalChairs='" + request.TotalChairs + "',@Allfunctioning='" + request.Allfunctioning + "',@FunctionalChairs='" + request.FunctionalChairs + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DentalChairsMGOneNOC.SaveDentalChairs");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataTable> GetDentalChairsById(int applyNocId, int collegeId)
        
        {
            DataTable dataTable = new DataTable();
            string SqlQuery = $"exec USP_GetDentalChairs_ApplyNoc_MGOne @ApplyNOCID={applyNocId},@CollegeID={collegeId}";
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DentalChairsMGOneNOC.GetDentalChairsById");
            

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
