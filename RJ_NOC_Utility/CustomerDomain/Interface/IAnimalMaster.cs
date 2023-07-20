using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAnimalMaster
    {
        List<CommonDataModel_DataTable> GetAllAnimalList();
        List<AnimalMasterDataModel> GetByID(int AnimalMasterID);
        bool SaveData(AnimalMasterDataModel request);       
        bool DeleteData(int AnimalMasterID);
        bool IfExists(int AnimalMasterID,int DepartmentID, string AnimalName);


    }
}