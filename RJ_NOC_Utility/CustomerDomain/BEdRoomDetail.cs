using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class BEdRoomDetail : UtilityBase, IBEdRoomDetail
    {
        public BEdRoomDetail(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<BEdRoomDetailDetailsDataModel> GetBEdRoomDetailList(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.BEdRoomDetailRepository.GetBEdRoomDetailList(DepartmentID, CollegeID);
        }
        public bool SaveData(BEdRoomDetailDataModel request)
        {
            return UnitOfWork.BEdRoomDetailRepository.SaveData(request);
        }

        public bool Delete(int Delete)
        {
            return UnitOfWork.BEdRoomDetailRepository.Delete(Delete);
        }


    }
}
