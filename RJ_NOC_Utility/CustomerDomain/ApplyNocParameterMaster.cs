using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using RJ_NOC_DataAccess.Common;
using System.Data;
using System.Text;
using System.Collections.Generic;

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
            sb.AppendFormat("@CreatedBy={0},", request.CreatedBy);
            sb.AppendFormat("@ModifyBy={0},", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);




            // put ''value'' for child string values
            // child            
            StringBuilder sb1 = new StringBuilder();


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
                else if(item.ApplyNocCode == "DEC_TNOCExtOfSubject")
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
                sb1.AppendFormat(" NewName_Hi=''{0}'',", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.NewNameHindi);
                sb1.AppendFormat(" DocumentName=''{0}''", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.DocumentName);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInNameDetailList='{0}',", sb1.ToString());
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

        public List<ApplyNocApplicationDataModel> GetApplyNocApplicationList(string SSOID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationList(SSOID);
            List<ApplyNocApplicationDataModel> model = new List<ApplyNocApplicationDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDataModel>>(dt);
            }
            return model;
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

        public List<CommonDataModel_DataTable> GetApplyNocPaymentHistoryApplicationID(int ApplyNocApplicationID)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocPaymentHistoryApplicationID(ApplyNocApplicationID);
        }

        public List<CommonDataModel_DataTable> GetApplicationPaymentHistoryApplicationID(int ApplyNocApplicationID)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetApplicationPaymentHistoryApplicationID(ApplyNocApplicationID);
        }





    }
}
