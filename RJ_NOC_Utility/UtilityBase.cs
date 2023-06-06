using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility
{
    public class UtilityBase
    {
        protected IRepositories UnitOfWork;
        public UtilityBase(IRepositories unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
