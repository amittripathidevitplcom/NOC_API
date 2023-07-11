using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class MedicalDocumentScrutiny : UtilityBase, IMedicalDocumentScrutiny
    {
        public MedicalDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MedicalDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<CommonDataModel_DataTable> GetDocumentScrutinyReportCompleted(int RoleId)
        {
            return UnitOfWork.MedicalDocumentScrutinyRepository.GetDocumentScrutinyReportCompleted(RoleId);
        }

    }
}
