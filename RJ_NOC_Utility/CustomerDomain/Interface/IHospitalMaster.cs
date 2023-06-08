using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IHospitalMaster
    {
        List<HospitalAreaValidation> GetHospitalAreaValidation();
    }
}