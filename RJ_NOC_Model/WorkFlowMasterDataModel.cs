using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class WorkFlowMasterDataModel
    {
        public int WorkFlowMasterID { get; set; }
        public int DepartmentID { get; set; }
        public int NOCTypeID { get; set; }
        public string? NOCTypeName { get; set; }
        public int RoleLevelID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public bool? ActiveStatus { get; set; }
        public bool? DeleteStatus { get; set; }
        public string? DepartmentName { get; set; }
        public string? RoleLevelName { get; set; }
        public string? RoleName { get; set; }
        public string? ReportType { get; set; }

        public List<WorkFlowMasterDetail> WorkFlowMasterDetailList { get; set; }
    }
    public class WorkFlowMasterDetail
    {
        public int WorkFlowMasterDetailID { get; set; }
        public int WorkFlowMasterID { get; set; }
        public int ActionHeadID { get; set; }
        public int ActionID { get; set; }
        public string ListCode { get; set; }
        public int RoleLevelID { get; set; }
        public int NextRoleID { get; set; }
        public int? Priority { get; set; }
        public int? CompletionDays { get; set; }
        public int OfficeGroupID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public string? ActionHeadName { get; set; }
        public string? ActionName { get; set; }
        public string? RoleLevelName { get; set; }
        public string? NextRoleName { get; set; }
        public string? OfficeGroupName { get; set; }
        public string? RoleName { get; set; }
        public int? DepartmentID { get; set; }

    }
}
