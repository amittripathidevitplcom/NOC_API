using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using RJ_NOC_DataAccess.Common;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ApplyNocParameterMaster : UtilityBase, IApplyNocParameterMaster
    {
        public ApplyNocParameterMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public List<ApplyNocParameterMaster_ddl> GetApplyNocParameterMaster(int CollegeID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocParameterMaster(CollegeID);
            List<ApplyNocParameterMaster_ddl> model = new List<ApplyNocParameterMaster_ddl>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocParameterMaster_ddl>>(dt);
            }
            return model;
        }
        public ApplyNocParameterMaster_TNOCExtensionDataModel GetApplyNocFor_TNOCExtension(int CollegeID, string ApplyNocFor)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocForByParameter(CollegeID, ApplyNocFor);
            ApplyNocParameterMaster_TNOCExtensionDataModel model = new ApplyNocParameterMaster_TNOCExtensionDataModel();
            if (ds != null)
            {
                if (ds.Tables.Count >= 3)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        model = CommonHelper.ConvertDataTable<ApplyNocParameterMaster_TNOCExtensionDataModel>(ds.Tables[0]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        model.ApplyNocParameterCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterCourseDataModel>>(ds.Tables[1]);
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        var subjectlist = CommonHelper.ConvertDataTable<List<ApplyNocParameterSubjectDataModel>>(ds.Tables[2]);
                        // map
                        model.ApplyNocParameterCourseList.ForEach(c =>
                        {
                            c.ApplyNocParameterSubjectList = subjectlist.Where(s => s.CourseID == c.CourseID)
                            .Select(sd => new ApplyNocParameterSubjectDataModel
                            {
                                ApplyNocID = sd.CourseID,
                                CourseID = sd.CourseID,
                                SubjectID = sd.SubjectID,
                                SubjectName = sd.SubjectName,
                            }).ToList();
                        });
                    }
                    //model = CommonHelper.ConvertDataTable<ApplyNocParameterMaster_TNOCExtensionDataModel>(ds.Tables[0]);
                    //model.ApplyNocParameterCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterCourseDataModel>>(ds.Tables[1]);
                    //var subjectlist = CommonHelper.ConvertDataTable<List<ApplyNocParameterSubjectDataModel>>(ds.Tables[2]);

                }
            }
            return model;
        }
        public ApplyNocParameterMaster_AdditionOfNewSeats60DataModel GetApplyNocFor_AdditionOfNewSeats60(int CollegeID, string ApplyNocFor)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocForByParameter(CollegeID, ApplyNocFor);
            ApplyNocParameterMaster_AdditionOfNewSeats60DataModel model = new ApplyNocParameterMaster_AdditionOfNewSeats60DataModel();
            if (ds != null)
            {
                if (ds.Tables.Count >= 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        model = CommonHelper.ConvertDataTable<ApplyNocParameterMaster_AdditionOfNewSeats60DataModel>(ds.Tables[0]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        model.ApplyNocParameterCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterCourseDataModel>>(ds.Tables[1]);
                    }
                }
            }
            return model;
        }

        public bool SaveApplyNocApplication(ApplyNocParameterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            List<ApplyNocParameterFeesDataModel> obj = new List<ApplyNocParameterFeesDataModel>();

            decimal dNewCourseFees = 0;
            decimal dNewSubjectFees = 0;

            decimal dNewCoursePGFees = 0;
            decimal dNewCourseUGFees = 0;

            decimal dNewSubjectPGFees = 0;
            decimal dNewSubjectUGFees = 0;

            //if (request.ApplyNocParameterMasterList_NewCourse != null)
            //{
            //    obj = UnitOfWork.ApplyNocParameterMasterRepository.GetDCECourseSubjectFees(request.ApplyNocParameterMasterList_NewCourse.ApplyNocID);

            //    dNewCoursePGFees = obj.FirstOrDefault(f => f.strCollegeLevel == "PG") != null? obj.FirstOrDefault(f => f.strCollegeLevel == "PG").FeeAmount:0;
            //    dNewCourseUGFees = obj.FirstOrDefault(f => f.strCollegeLevel == "UG") != null? obj.FirstOrDefault(f => f.strCollegeLevel == "UG").FeeAmount:0;

            //    foreach (var item in request.ApplyNocParameterMasterList_NewCourse.ApplyNocParameterCourseList)
            //    {
            //        if (item.CollegeLevel != null)
            //        {
            //            if (item.CollegeLevel == "UG")
            //            {
            //                dNewCourseFees += dNewCourseUGFees;
            //            }
            //            else if (item.CollegeLevel == "PG")
            //            {
            //                dNewCourseFees += dNewCoursePGFees;
            //            }
            //        }
            //    }
            //}

            //if (request.ApplyNocParameterMasterList_NewCourseSubject != null)
            //{
            //    obj = UnitOfWork.ApplyNocParameterMasterRepository.GetDCECourseSubjectFees(request.ApplyNocParameterMasterList_NewCourseSubject.ApplyNocID);
            //    dNewSubjectPGFees = obj.FirstOrDefault(f => f.strCollegeLevel == "PG") != null ? obj.FirstOrDefault(f => f.strCollegeLevel == "PG").FeeAmount : 0;
            //    dNewSubjectUGFees = obj.FirstOrDefault(f => f.strCollegeLevel == "UG") != null ? obj.FirstOrDefault(f => f.strCollegeLevel == "UG").FeeAmount : 0;

            //    foreach (var item in request.ApplyNocParameterMasterList_NewCourseSubject.ApplyNocParameterCourseList)
            //    {
            //        foreach (var subjects in item.ApplyNocParameterSubjectList)
            //        {
            //            if (item.CollegeLevel != null)
            //            {
            //                if (item.CollegeLevel == "UG")
            //                {
            //                    dNewSubjectFees += dNewSubjectUGFees;
            //                }
            //                else if (item.CollegeLevel == "PG")
            //                {
            //                    dNewSubjectFees += dNewSubjectPGFees;
            //                }
            //            }
            //        }

            //    }
            //}


            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@CollegeID={0},", request.CollegeID);
            sb.AppendFormat("@ApplicationTypeID={0},", request.ApplicationTypeID);
            sb.AppendFormat("@TotalFeeAmount={0},", request.TotalFeeAmount + dNewCourseFees + dNewSubjectFees);
            sb.AppendFormat("@TotalNocFee={0},", request.TotalNocFee);
            sb.AppendFormat("@LateFee={0},", request.LateFee);
            sb.AppendFormat("@TotalDefaulterCollegePenalty={0},", request.TotalDefaulterCollegePenalty);
            sb.AppendFormat("@CreatedBy={0},", request.CreatedBy);
            sb.AppendFormat("@ModifyBy={0},", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);
            sb.AppendFormat("@ExistingLetterofEOA='{0}',", request.ExistingLetterofEOA);
            sb.AppendFormat("@DTE_ChangeInTheMinorityStatusoftheInstitution='{0}',", request.DTE_ChangeInTheMinorityStatusoftheInstitution);




            // put ''value'' for child string values
            // child            
            StringBuilder sb1 = new StringBuilder();

            if (request.ApplyNocParameterMasterListDataModel.Where(x => x.IsChecked == true).Count() > 0)
            {
                sb1.Append("select * into ##ApplyNocParameterDetailList from(");
                foreach (var item in request.ApplyNocParameterMasterListDataModel.Where(x => x.IsChecked == true))
                {
                    sb1.Append(" select");
                    sb1.AppendFormat(" ApplyNocParameterDetailID={0},", 0);
                    sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                    sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                    sb1.AppendFormat(" ApplyNocFor=''{0}'',", item.ApplyNocFor);
                    if (item.ApplyNocCode == "DEC_NewCourse")
                    {
                        sb1.AppendFormat(" FeeAmount={0}", request.ApplyNocParameterMasterList_NewCourse.FeeAmount);
                    }
                    else if (item.ApplyNocCode == "DEC_TNOCExtOfSubject")
                    {
                        sb1.AppendFormat(" FeeAmount={0}", request.ApplyNocParameterMasterList_TNOCExtOfSubject.FeeAmount);
                    }
                    else if (item.ApplyNocCode == "DEC_NewSubject")
                    {
                        sb1.AppendFormat(" FeeAmount={0}", request.ApplyNocParameterMasterList_NewCourseSubject.FeeAmount);
                    }
                    else if (item.ApplyNocCode == "DEC_PNOCSubject")
                    {
                        sb1.AppendFormat(" FeeAmount={0}", request.ApplyNocParameterMasterList_PNOCOfSubject.FeeAmount);
                    }
                    else
                    {
                        sb1.AppendFormat(" FeeAmount={0}", item.FeeAmount);
                    }
                    sb1.Append(" union all");
                }

                sb1.Length = sb1.Length - 9;// remove union all
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocParameterDetailList='{0}',", sb1.ToString());
            }





            if (request.ApplyNocParameterMasterList_TNOCExtension != null || request.ApplyNocParameterMasterList_AdditionOfNewSeats60 != null)
            {
                // child
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationDetailList from(");
                if (request.ApplyNocParameterMasterList_TNOCExtension != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_TNOCExtension.ApplyNocParameterCourseList.Where(x => x.IsChecked == true))
                    {
                        foreach (var item1 in item.ApplyNocParameterSubjectList)
                        {
                            sb1.Append(" select");
                            sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                            sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                            sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                            sb1.AppendFormat(" CourseID={0},", item.CourseID);
                            sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                            sb1.AppendFormat(" CheckedStatus={0}", 1);
                            sb1.Append(" union all");
                        }
                    }
                }
                if (request.ApplyNocParameterMasterList_AdditionOfNewSeats60 != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_AdditionOfNewSeats60.ApplyNocParameterCourseList.Where(x => x.IsChecked == true))
                    {
                        sb1.Append(" select");
                        sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                        sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                        sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                        sb1.AppendFormat(" CourseID={0},", item.CourseID);
                        sb1.AppendFormat(" SubjectID={0},", 0);
                        sb1.AppendFormat(" CheckedStatus={0}", 1);
                        sb1.Append(" union all");
                    }
                }
                sb1.Length = sb1.Length - 9;// remove union all  
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationDetailList='{0}',", sb1.ToString());
            }


            // child Change Name Data

            if (request.ApplyNocParameterMasterList_ChangeInNameOfCollege != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInNameDetailList from(");
                sb1.Append(" select");
                sb1.AppendFormat(" ChangeInNameID={0},", 0);
                sb1.AppendFormat(" NewName_Eng=''{0}'',", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.NewNameEnglish);
                sb1.AppendFormat(" NewName_Hi=N''{0}'',", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.NewNameHindi);
                sb1.AppendFormat(" DocumentName=''{0}''", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.DocumentName);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInNameDetailList=N'{0}',", sb1.ToString());
            }
            //Change Place Detail

            if (request.ApplyNocParameterMasterList_ChangeInPlaceOfCollege != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInPlaceDetailList from(");
                sb1.Append(" select");
                sb1.AppendFormat(" ChangeInPlaceID={0},", 0);
                sb1.AppendFormat(" PlaceName=''{0}'',", request.ApplyNocParameterMasterList_ChangeInPlaceOfCollege.PlaceName);
                sb1.AppendFormat(" DocumentName=''{0}'',", request.ApplyNocParameterMasterList_ChangeInPlaceOfCollege.DocumentName);
                sb1.AppendFormat(" PlaceDocumentName=''{0}''", request.ApplyNocParameterMasterList_ChangeInPlaceOfCollege.PlaceDocumentName);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInPlaceDetailList='{0}',", sb1.ToString());
            }

            // Co Education to Girls 

            if (request.ApplyNocParameterMasterList_ChangeInCoedtoGirls != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInCOEDtoGirlsDetailList from(");
                sb1.Append(" select ");
                sb1.AppendFormat("ChangeInCoedGirlsID={0},", 0);
                sb1.AppendFormat("ConsentManagementDocument=''{0}''", request.ApplyNocParameterMasterList_ChangeInCoedtoGirls.ConsentManagementDocument);

                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInCOEDtoGirlsDetailList='{0}',", sb1.ToString());
            }

            // Girls Co Education

            if (request.ApplyNocParameterMasterList_ChangeInGirlstoCoed != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInGirlsCOEDDetailList from(");
                sb1.Append(" select");
                sb1.AppendFormat(" ChangeInGirlsCoedID={0},", 0);
                sb1.AppendFormat(" ConsentManagementDocument=''{0}'',", request.ApplyNocParameterMasterList_ChangeInGirlstoCoed.ConsentManagementDocument);
                sb1.AppendFormat(" ConsentStudentDocument=''{0}''", request.ApplyNocParameterMasterList_ChangeInGirlstoCoed.ConsentStudentDocument);

                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInGirlsCOEDDetailList='{0}',", sb1.ToString());
            }

            //Merger Details

            if (request.ApplyNocParameterMasterList_MergerCollege != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInMergerDetailList from(");
                sb1.Append(" select");
                sb1.AppendFormat(" ChangesInMergerID={0},", 0);
                sb1.AppendFormat(" SocietyProposal=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.SocietyProposal);
                sb1.AppendFormat(" AllNOC=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.AllNOC);
                sb1.AppendFormat(" UniversityAffiliation=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.UniversityAffiliation);

                sb1.AppendFormat(" NOCAffiliationUniversity=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.NOCAffiliationUniversity);
                sb1.AppendFormat(" ConsentAffidavit=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.ConsentAffidavit);
                sb1.AppendFormat(" OtherAllNOC=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.OtherAllNOC);

                sb1.AppendFormat(" OtherUniversityAffiliation=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.OtherUniversityAffiliation);
                sb1.AppendFormat(" OtherNOCAffiliationUniversity=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.OtherNOCAffiliationUniversity);
                sb1.AppendFormat(" OtherConsentAffidavit=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.OtherConsentAffidavit);

                sb1.AppendFormat(" LandTitleCertificate=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.LandTitleCertificate);
                sb1.AppendFormat(" BuildingBluePrint=''{0}'',", request.ApplyNocParameterMasterList_MergerCollege.BuildingBluePrint);
                sb1.AppendFormat(" StaffInformation=''{0}''", request.ApplyNocParameterMasterList_MergerCollege.StaffInformation);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInMergerDetailList='{0}',", sb1.ToString());
            }


            // Girls Co Education

            if (request.ApplyNocParameterMasterList_ChangeInCollegeManagement != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocApplicationChangeInCollegeManagementDetailList from(");
                sb1.Append(" select");
                sb1.AppendFormat(" ChangeInManagementID={0},", 0);
                sb1.AppendFormat(" NewSocietyName=''{0}'',", request.ApplyNocParameterMasterList_ChangeInCollegeManagement.NewSocietyName);
                sb1.AppendFormat(" DocumentName=''{0}'',", request.ApplyNocParameterMasterList_ChangeInCollegeManagement.DocumentName);
                sb1.AppendFormat(" AnnexureDocument=''{0}''", request.ApplyNocParameterMasterList_ChangeInCollegeManagement.AnnexureDocument);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInCollegeManagementDetailList='{0}',", sb1.ToString());
            }



            //Dec New Course Subject
            if (request.ApplyNocParameterMasterList_NewCourse != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocParameterMasterList_NewCourse from(");
                if (request.ApplyNocParameterMasterList_NewCourse != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_NewCourse.ApplyNocParameterCourseList)
                    {
                        foreach (var item1 in item.ApplyNocParameterSubjectList)
                        {
                            sb1.Append(" select");
                            sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                            sb1.AppendFormat(" ApplyNocParameterID={0},", request.ApplyNocParameterMasterList_NewCourse.ApplyNocID);
                            sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                            sb1.AppendFormat(" CourseID={0},", item.CourseID);
                            sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                            sb1.AppendFormat(" CheckedStatus={0}", 1);
                            sb1.Append(" union all");
                        }
                    }
                }
                sb1.Length = sb1.Length - 9;// remove union all  
                sb1.Append(" ) as t ");
                sb.AppendFormat("@ApplyNocParameterMasterList_NewCourse='{0}',", sb1.ToString());
            }

            if (request.ApplyNocParameterMasterList_NewCourseSubject != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocParameterMasterList_NewCourseSubject from(");
                if (request.ApplyNocParameterMasterList_NewCourseSubject != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_NewCourseSubject.ApplyNocParameterCourseList)
                    {
                        foreach (var item1 in item.ApplyNocParameterSubjectList)
                        {
                            sb1.Append(" select");
                            sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                            sb1.AppendFormat(" ApplyNocParameterID={0},", request.ApplyNocParameterMasterList_NewCourseSubject.ApplyNocID);
                            sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                            sb1.AppendFormat(" CourseID={0},", item.CourseID);
                            sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                            sb1.AppendFormat(" CheckedStatus={0}", 1);
                            sb1.Append(" union all");
                        }
                    }
                }
                sb1.Length = sb1.Length - 9;// remove union all  
                sb1.Append(" ) as t ");
                sb.AppendFormat("@ApplyNocParameterMasterList_NewCourseSubject='{0}',", sb1.ToString());
            }


            //DEC TNOC OF SUBJECT
            if (request.ApplyNocParameterMasterList_TNOCExtOfSubject != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocParameterMasterList_TNOCExtOfSubject from(");
                if (request.ApplyNocParameterMasterList_TNOCExtOfSubject != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_TNOCExtOfSubject.ApplyNocParameterCourseList)
                    {
                        foreach (var item1 in item.ApplyNocParameterSubjectList)
                        {
                            sb1.Append(" select");
                            sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                            sb1.AppendFormat(" ApplyNocParameterID={0},", request.ApplyNocParameterMasterList_TNOCExtOfSubject.ApplyNocID);
                            sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                            sb1.AppendFormat(" CourseID={0},", item.CourseID);
                            sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                            sb1.AppendFormat(" CheckedStatus={0}", 1);
                            sb1.Append(" union all");
                        }
                    }
                }
                sb1.Length = sb1.Length - 9;// remove union all  
                sb1.Append(" ) as t ");
                sb.AppendFormat("@ApplyNocParameterMasterList_TNOCExtOfSubject='{0}',", sb1.ToString());
            }


            //DEC TNOC OF SUBJECT
            if (request.ApplyNocParameterMasterList_PNOCOfSubject != null)
            {
                sb1 = new StringBuilder();
                sb1.Append("select * into ##ApplyNocParameterMasterList_PNOCOfSubject from(");
                if (request.ApplyNocParameterMasterList_PNOCOfSubject != null)
                {
                    foreach (var item in request.ApplyNocParameterMasterList_PNOCOfSubject.ApplyNocParameterCourseList)
                    {
                        foreach (var item1 in item.ApplyNocParameterSubjectList)
                        {
                            sb1.Append(" select");
                            sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                            sb1.AppendFormat(" ApplyNocParameterID={0},", request.ApplyNocParameterMasterList_PNOCOfSubject.ApplyNocID);
                            sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                            sb1.AppendFormat(" CourseID={0},", item.CourseID);
                            sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                            sb1.AppendFormat(" CheckedStatus={0}", 1);
                            sb1.Append(" union all");
                        }
                    }
                }
                sb1.Length = sb1.Length - 9;// remove union all  
                sb1.Append(" ) as t ");
                sb.AppendFormat("@ApplyNocParameterMasterList_PNOCOfSubject='{0}',", sb1.ToString());
            }



            //@ApplyNocParameterMasterList_TNOCExtOfSubject text = '',
            //@ApplyNocParameterMasterList_PNOCOfSubject  text = '',
            if (request.ApplyNocLateFeeDetailList != null)
            {
                if (request.ApplyNocLateFeeDetailList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocLateFeeDetails='{0}',", CommonHelper.GetDetailsTableQry(request.ApplyNocLateFeeDetailList, "ApplyNocLateFeeDetails"));
                }
            }
            //DefaulterCollegePenaltyDetailList
            if (request.DefaulterCollegePenaltyDetailList != null)
            {
                if (request.DefaulterCollegePenaltyDetailList.Count > 0)
                {
                    sb.AppendFormat("@DefaulterCollegePenaltyDetailList='{0}',", CommonHelper.GetDetailsTableQry(request.DefaulterCollegePenaltyDetailList, "DefaulterCollegePenaltyDetailList"));
                }
            }

            //DTE Deparment Apply NOC Start

            if (request.DTE_BankDetails != null)
            {
                sb.AppendFormat("@ApplyNocParameterMasterList_BankDetails='{0}',",
                    "select ''"+request.DepartmentID + "''" + " as DepartmentID, " +
                    "''"+request.CollegeID + "''" + " as CollegeID, " +
                    "''"+request.DTE_BankDetails.OldBankName + "''" + " as OldBankName, " +
                    "''"+request.DTE_BankDetails.NewBankName + "''" + " as NewBankName, " +
                    "''"+request.DTE_BankDetails.OldBranchName + "''" + " as OldBranchName, " +
                    "''"+request.DTE_BankDetails.NewBranchName + "''" + " as NewBranchName, " +
                    "''"+request.DTE_BankDetails.OldIFSC + "''" + " as OldIFSC, " +
                    "''"+request.DTE_BankDetails.NewIFSC + "''" + " as NewIFSC, " +
                    "''"+request.DTE_BankDetails.OldAccountNumber + "''" + " as OldAccountNumber, " +
                    "''"+request.DTE_BankDetails.NewAccountNumber + "''" + " as NewAccountNumber, " +
                    "''" + request.DTE_BankDetails.FeeAmount + "''" + " as FeeAmount");
            }

            if (request.DTE_MergerofInstitutions != null)
            {
                sb.AppendFormat("@ApplyNocParameterMasterList_MergerofInstitutions='{0}',",
                    "select ''" + request.DepartmentID + "''" + " as DepartmentID, " +
                    "''" + request.CollegeID + "''" + " as CollegeID, " +
                    "''" + request.DTE_MergerofInstitutions.InstituteID1 + "''" + " as InstituteID1, " +
                    "''" + request.DTE_MergerofInstitutions.InstituteID2 + "''" + " as InstituteID2, " +
                    "''" + request.DTE_MergerofInstitutions.MergeInstituteID + "''" + " as MergeInstituteID, " +
                    "''" + request.DTE_MergerofInstitutions.TrustType + "''" + " as TrustType, " +
                    "''" + request.DTE_MergerofInstitutions.NewTrustName + "''" + " as NewTrustName, " +
                    "''" + request.DTE_MergerofInstitutions.NewInstituteName + "''" + " as NewInstituteName, " +
                    "''" + request.DTE_MergerofInstitutions.FeeAmount + "''" + " as FeeAmount");
            }

            if (request.DTE_ChangeinNameofSociety != null)
            {
                sb.AppendFormat("@ApplyNocParameterMasterList_ChangeinNameofSociety='{0}',",
                    "select ''" + request.DepartmentID + "''" + " as DepartmentID, " +
                    "''" + request.CollegeID + "''" + " as CollegeID, " +
                    "''" + request.DTE_ChangeinNameofSociety.CurrentName + "''" + " as CurrentName, " +
                    "''" + request.DTE_ChangeinNameofSociety.NewName + "''" + " as NewName, " +
                    "''" + request.DTE_ChangeinNameofSociety.ChangeType + "''" + " as ChangeType, " +
                    "''" + request.DTE_ChangeinNameofSociety.OldAddress + "''" + " as OldAddress, " +
                    "''" + request.DTE_ChangeinNameofSociety.NewAddress + "''" + " as NewAddress, " +
                    "''" + request.DTE_ChangeinNameofSociety.FeeAmount + "''" + " as FeeAmount");
            }

            if (request.DTE_IncreaseinIntakeAdditionofCourse_List != null)
            {
                if (request.DTE_IncreaseinIntakeAdditionofCourse_List.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_IncreaseinIntakeAdditionofCourse_List, "ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse"));
                }
            }

            if (request.DTE_AdditionofIntegratedDualDegreeList != null)
            {
                if (request.DTE_AdditionofIntegratedDualDegreeList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_AdditionofIntegratedDualDegree='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_AdditionofIntegratedDualDegreeList, "ApplyNocParameterMasterList_AdditionofIntegratedDualDegree"));
                }
            }
            if (request.DTE_ChangeInNameOfCourseList != null)
            {
                if (request.DTE_ChangeInNameOfCourseList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_ChangeInNameOfCourse='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_ChangeInNameOfCourseList, "ApplyNocParameterMasterList_ChangeInNameOfCourse"));
                }
            }
            if (request.DTE_ReductionInIntakeList != null)
            {
                if (request.DTE_ReductionInIntakeList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_ReductionInIntake='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_ReductionInIntakeList, "ApplyNocParameterMasterList_ReductionInIntake"));
                }
            }           
            if (request.DTE_TostartNewProgramme_List != null)
            {
                if (request.DTE_TostartNewProgramme_List.Count > 0)
                { 
                    sb.AppendFormat("@ApplyNocParameterMasterList_TostartNewProgramme='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_TostartNewProgramme_List, "ApplyNocParameterMasterList_TostartNewProgramme"));
                }
            }

            if (request.DTE_ChangeInNameofInstitution != null)
            {
                sb.AppendFormat("@ApplyNocParameterMasterList_ChangeInNameofInstitution='{0}',",
                    "select ''" + request.DepartmentID + "''" + " as DepartmentID, " +
                    "''" + request.CollegeID + "''" + " as CollegeID, " +
                    "''" + request.DTE_ChangeInNameofInstitution.CurrentCollegeName + "''" + " as CurrentCollegeName, " +
                    "''" + request.DTE_ChangeInNameofInstitution.NewCollegeName + "''" + " as NewCollegeName, " +
                    "''" + request.DTE_ChangeInNameofInstitution.NewCollegeNameHi + "''" + " as NewCollegeNameHi, " +
                    "''" + request.DTE_ChangeInNameofInstitution.FeeAmount + "''" + " as FeeAmount");
            }          
            if (request.DTE_ChangeofSite_Location != null)
            {
                sb.AppendFormat("@ApplyNocParameterMasterList_ChangeofSite_Location='{0}',",
                    "select ''" + request.DepartmentID + "''" + " as DepartmentID, " +
                    "''" + request.CollegeID + "''" + " as CollegeID, " +
                    "''" + request.DTE_ChangeofSite_Location.CurrentAddress + "''" + " as CurrentAddress, " +
                    "''" + request.DTE_ChangeofSite_Location.NewAddress + "''" + " as NewAddress, " +
                    "''" + request.DTE_ChangeofSite_Location.FeeAmount + "''" + " as FeeAmount");
            }
            if (request.DTE_IncreaseInIntake_AdditionofCourse_List != null)
            {
                if (request.DTE_IncreaseInIntake_AdditionofCourse_List.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_IncreaseInIntake_AdditionofCourse_List, "ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse"));
                }
            }

            if (request.DTE_ClosureOfProgramList != null)
            {
                if (request.DTE_ClosureOfProgramList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_ClosureOfProgram='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_ClosureOfProgramList, "ApplyNocParameterMasterList_ClosureOfProgram"));
                }
            }
            if (request.DTE_ClosureOfCoursesList != null)
            {
                if (request.DTE_ClosureOfCoursesList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_ClosureOfCourses='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_ClosureOfCoursesList, "ApplyNocParameterMasterList_ClosureOfCourses"));
                }
            }
            if (request.DTE_MergerOfTheCourseList != null)
            {
                if (request.DTE_MergerOfTheCourseList.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_MergerOfTheCourse='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_MergerOfTheCourseList, "ApplyNocParameterMasterList_MergerOfTheCourse"));
                }
            }
            if (request.DTE_IntroductionOffCampus_List != null)
            {
                if (request.DTE_IntroductionOffCampus_List.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_IntroductionOffCampus='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_IntroductionOffCampus_List, "ApplyNocParameterMasterList_IntroductionOffCampus"));
                }
            }
            if (request.DTE_CoursesforWorkingProfessionals_List != null)
            {
                if (request.DTE_CoursesforWorkingProfessionals_List.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_CoursesforWorkingProfessionals='{0}',", CommonHelper.GetDetailsTableQry(request.DTE_CoursesforWorkingProfessionals_List, "ApplyNocParameterMasterList_CoursesforWorkingProfessionals"));
                }
            }
            //DTE Deparment Apply NOC End

            //Medical Group 3 Seat Enhancement 
            if (request.ApplyNocParameterSeatEnhancement != null)
            {
                if (request.ApplyNocParameterSeatEnhancement.Count > 0)
                {
                    sb.AppendFormat("@ApplyNocParameterMasterList_ApplyNocParameterSeatEnhancement='{0}',", CommonHelper.GetDetailsTableQry(request.ApplyNocParameterSeatEnhancement.Where(w=>w.IsChecked==true).ToList(), "ApplyNocParameterMasterList_ApplyNocParameterSeatEnhancement"));
                }
            }

            // action
            sb.AppendFormat("@Action='{0}'", "SaveApplyNocApplication");
            // execute
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveApplyNocApplication(sb.ToString());
        }
        public List<ApplyNocFDRDetailsDataModel> GetApplyNoc_FDRMasterByCollegeID(int CollegeID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNoc_FDRMasterByCollegeID(CollegeID);
            List<ApplyNocFDRDetailsDataModel> model = new List<ApplyNocFDRDetailsDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocFDRDetailsDataModel>>(dt);
            }
            return model;
        }
        public bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveApplyNoc_FDRMasterDetail(request);
        }
        public bool SaveOfflinePaymnetDetail(ApplyNocOfflinePaymentModal request)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveOfflinePaymnetDetail(request);
        }
        public List<ApplyNocFDRDetailsDataModel> GetApplyNocFDRDetails(int ApplyNocFDRID, int ApplyNocID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocFDRDetails(ApplyNocFDRID, ApplyNocID);
            List<ApplyNocFDRDetailsDataModel> model = new List<ApplyNocFDRDetailsDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocFDRDetailsDataModel>>(dt);
            }
            return model;
        }

        public List<ApplyNocApplicationDataModel> GetApplyNocApplicationList(string SSOID, int SessionYear)
        {
            //var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationList(SSOID);
            //List<ApplyNocApplicationDataModel> model = new List<ApplyNocApplicationDataModel>();
            //if (dt != null)
            //{
            //    model = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDataModel>>(dt);
            //}
            //return model;

            DataSet dataSet = new DataSet();
            dataSet = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationList(SSOID, SessionYear);
            List<ApplyNocApplicationDataModel> listdataModels = new List<ApplyNocApplicationDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplyNocApplicationDataModel>>(JsonDataTable_Data);

            if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
            {
                List<NOCPdfFileDataModel> NOCPdfFileDataModel = new List<NOCPdfFileDataModel>();
                string JsonDataTable_PDFData = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                NOCPdfFileDataModel = JsonConvert.DeserializeObject<List<NOCPdfFileDataModel>>(JsonDataTable_PDFData);
                for (int i = 0; i < listdataModels.Count; i++)
                {
                    var Data = NOCPdfFileDataModel.Where(w => w.ApplyNOCID == listdataModels[i].ApplyNocApplicationID).ToList();
                    if (Data != null && Data.Count > 0)
                    {
                        listdataModels[i].NOCPdfFileDataModel = Data;
                    }
                }
            }
            return listdataModels;
        }

        public ApplyNocApplicationDataModel GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationByApplicationID(ApplyNocApplicationID);
            ApplyNocApplicationDataModel model = new ApplyNocApplicationDataModel();
            if (ds != null && ds.Tables.Count >= 3)
            {
                // trn application
                model = CommonHelper.ConvertDataTable<ApplyNocApplicationDataModel>(ds.Tables[0]);
                // trn parameter
                if (model != null)
                {
                    model.ApplyNocApplicationParameterList = CommonHelper.ConvertDataTable<List<ApplyNocApplicationParameterDataModel>>(ds.Tables[1]);
                    // trn application detail
                    var trnApplicationDetail = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDetailDataModel>>(ds.Tables[2]);
                    // map
                    model.ApplyNocApplicationParameterList.ForEach(c =>
                    {
                        c.ApplyNocApplicationDetailList = trnApplicationDetail.Where(s => s.ApplyNocParameterID == c.ApplyNocParameterID)
                        .Select(sd => new ApplyNocApplicationDetailDataModel
                        {
                            ApplyNocApplicationID = sd.ApplyNocApplicationID,
                            ApplyNocParameterID = sd.ApplyNocParameterID,
                            CourseID = sd.CourseID,
                            CourseName = sd.CourseName,
                            SubjectID = sd.SubjectID,
                            SubjectName = sd.SubjectName,
                        }).ToList();
                    });
                    //

                    model.ChangeInNameOfCollegeList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInNameOfCollege>>(ds.Tables[3]);
                    model.ChangeInPlaceOfCollegeList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInPlaceOfCollege>>(ds.Tables[4]);
                    model.ChangeInCoedtoGirlsList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInCoedtoGirls>>(ds.Tables[5]);
                    model.ChangeInGirlstoCoedList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInGirlstoCoed>>(ds.Tables[6]);
                    model.MergerCollegeList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_MergerCollege>>(ds.Tables[7]);
                    model.ChangeInCollegeManagementList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInCollegeManagement>>(ds.Tables[8]);

                    //DTE
                    model.DTE_ChangeofSite_Location= CommonHelper.ConvertDataTable<ApplyNocParameterMasterList_ChangeofSite_Location>(ds.Tables[9]);
                    model.DTE_IncreaseInIntake_AdditionofCourse_List = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse>>(ds.Tables[10]);
                    model.DTE_AdditionofIntegratedDualDegreeList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_AdditionofIntegratedDualDegree>>(ds.Tables[11]);
                    model.DTE_ChangeInNameOfCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ChangeInNameOfCourse>>(ds.Tables[12]);
                    model.DTE_ChangeInNameofInstitution = CommonHelper.ConvertDataTable<ApplyNocParameterMasterList_ChangeInNameofInstitution>(ds.Tables[13]);
                    model.DTE_ChangeinNameofSociety = CommonHelper.ConvertDataTable<ApplyNocParameterMasterList_ChangeinNameofSociety>(ds.Tables[14]);

                    model.DTE_TostartNewProgramme_List = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_TostartNewProgramme>>(ds.Tables[15]);
                    model.DTE_MergerofInstitutions = CommonHelper.ConvertDataTable<ApplyNocParameterMasterList_MergerofInstitutions>(ds.Tables[16]);
                    model.DTE_BankDetails = CommonHelper.ConvertDataTable<ApplyNocParameterMasterList_BankDetails>(ds.Tables[17]);
                    model.DTE_ReductionInIntakeList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ReductionInIntake>>(ds.Tables[18]);
                    model.DTE_ClosureOfProgramList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ClosureOfProgram>>(ds.Tables[19]);
                    model.DTE_ClosureOfCoursesList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_ClosureOfCourses>>(ds.Tables[20]);
                    model.DTE_MergerOfTheCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_MergerOfTheCourse>>(ds.Tables[21]);
                    model.DTE_IncreaseinIntakeAdditionofCourse_List = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse>>(ds.Tables[22]);
                    model.DTE_IntroductionOffCampus_List = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_IntroductionOffCampus>>(ds.Tables[23]);
                    model.DTE_CoursesforWorkingProfessionals_List = CommonHelper.ConvertDataTable<List<ApplyNocParameterMasterList_CoursesforWorkingProfessionals>>(ds.Tables[24]);
                    model.DefaulterCollegePenaltyDetailList = CommonHelper.ConvertDataTable<List<DefaulterCollegePenaltyDataModal>>(ds.Tables[25]);
                    model.ApplyNocLateFeeDetailList = CommonHelper.ConvertDataTable<List<ApplyNocLateFeeDetailDataModal>>(ds.Tables[26]);
                    model.ApplyNocParameterSeatEnhancement = CommonHelper.ConvertDataTable<List<ApplyNocParameterSeatEnhancement>>(ds.Tables[27]);
                }
            }
            return model;
        }

        public bool DeleteApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            return UnitOfWork.ApplyNocParameterMasterRepository.DeleteApplyNocApplicationByApplicationID(ApplyNocApplicationID, ModifyBy, IPAddress);
        }
        public bool FinalSubmitApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            return UnitOfWork.ApplyNocParameterMasterRepository.FinalSubmitApplyNocApplicationByApplicationID(ApplyNocApplicationID, ModifyBy, IPAddress);
        }

        public List<CommonDataModel_DataTable> GetApplyNocPaymentHistoryApplicationID(int ApplyNocApplicationID, string PaymentFor)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocPaymentHistoryApplicationID(ApplyNocApplicationID, PaymentFor);
        }

        public List<CommonDataModel_DataTable> GetApplicationPaymentHistoryApplicationID(int ApplyNocApplicationID)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetApplicationPaymentHistoryApplicationID(ApplyNocApplicationID);
        }
        public List<CommonDataModel_DataTable> GetOfflinePaymentDetails(int ApplyNocApplicationID, int PaymentOfflineID, string ActionName)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetOfflinePaymentDetails(ApplyNocApplicationID, PaymentOfflineID, ActionName);
        }


        public List<ApplyNocApplicationDataModel> GetApplyNocApplicationLists(int SelectedCollageID, int SelectedDepartmentID, int SessionYear)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationLists(SelectedCollageID, SelectedDepartmentID, SessionYear);
            List<ApplyNocApplicationDataModel> model = new List<ApplyNocApplicationDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDataModel>>(dt);
            }
            return model;
        }
        public List<ApplyNocFDRDetailsDataModel> ViewApplyNocFDRDetailsByCollegeID(int CollegeID,int SessionYear)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.ViewApplyNocFDRDetailsByCollegeID(CollegeID, SessionYear);
            List<ApplyNocFDRDetailsDataModel> model = new List<ApplyNocFDRDetailsDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocFDRDetailsDataModel>>(dt);
            }
            return model;
        }
        public List<ApplyNOCCourseListDataModal> GetCourseSubjectByApplyNOCID(int ApplyNOCID, int ParameterID)
        {
            DataTable dt = new DataTable();
            List<ApplyNOCCourseListDataModal> applyNOCCourseList = new List<ApplyNOCCourseListDataModal>();
            List<ApplyNOCCourseSubjectListDataModal> model = new List<ApplyNOCCourseSubjectListDataModal>();
            dt = UnitOfWork.ApplyNocParameterMasterRepository.GetCourseSubjectByApplyNOCID(ApplyNOCID, ParameterID);
            if (dt != null && dt.Rows.Count > 0)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNOCCourseSubjectListDataModal>>(dt);
                if (model != null)
                {
                    var DistinctCourse = model.Select(s => s.CourseID).Distinct();
                    foreach (var c in DistinctCourse)
                    {
                        var data = model.Where(w => w.CourseID == c).FirstOrDefault();
                        applyNOCCourseList.Add(new ApplyNOCCourseListDataModal()
                        {
                            ApplyNocApplicationID = data.ApplyNocApplicationID,
                            CourseID = data.CourseID,
                            CourseName = data.CourseName,
                            SubjectList = model.Where(w => w.CourseID == c).Select(sub => new ApplyNOCSubjectListCourseWiseDataModal()
                            {
                                ApplyNocParameterID = sub.ApplyNocParameterID,
                                SubjectID = sub.SubjectID,
                                SubjectName = sub.SubjectName
                            }).ToList()
                        });
                    }
                }
            }
            return applyNOCCourseList;
        }
        public bool SaveApplyNocMinisterFile(ApplyNoc_MinisterFile request)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveApplyNocMinisterFile(request);
        }

    }
}
