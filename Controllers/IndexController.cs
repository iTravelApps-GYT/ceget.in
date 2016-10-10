using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCNI_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Net.Mail;

namespace GCNI.Controllers
{
    public class IndexController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //
        // GET: /Index/
        [HttpGet]
        public ActionResult Index()
        {

            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objEventM = new Models.EventMaster();
            objGCNI.objEventML = new Models.EventMaster().GetEventData2();
            objGCNI.objPublicationtML = new Models.Publication().GetPublicationData();
            objGCNI.objArticleML = new Models.Article().GetArticleData();
            objGCNI.objNewML = new Models.News().GetNewsData();
            objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);

            //System.Text.StringBuilder sbmarkers = new System.Text.StringBuilder();
            //List<Models.EventMaster> objem = new List<Models.EventMaster>();
            //objem = new Models.EventMaster().GetEventData();
            //foreach (GCNI.Models.EventMaster obj in objem)
            //{
            //    sbmarkers.Append(obj.Lat);
            //    sbmarkers.Append(obj.Lng);
            //    sbmarkers.Append(obj.Title);
            //}

            //return Json(sbmarkers.ToString());
            
        }

        [HttpPost]
        public ActionResult Index(string id,string Ans)
        {
            int Yes=0;
            int No=0;
            cmd = new SqlCommand("spOpinionPoll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype","getVote");
            cmd.Parameters.AddWithValue("@ID",id);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Yes = Convert.ToInt32(dt.Rows[0]["Option_Yes"]);
                No = Convert.ToInt32(dt.Rows[0]["Option_No"]);
            }
            if (Ans == "Yes")
            {
                Yes++;
            }
            else
            {
                No++;
            }
            int res = OpinionPollDAL.VoteOpinionPollDAL(id,Yes,No, "vote");
            if (res > 0)
            {
                ViewBag.Message = "Vote is Successfully Saved...!";
            }
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objEventM = new Models.EventMaster();
            objGCNI.objEventML = new Models.EventMaster().GetEventData2();
            objGCNI.objPublicationtML = new Models.Publication().GetPublicationData();
            objGCNI.objArticleML = new Models.Article().GetArticleData();
            objGCNI.objNewML = new Models.News().GetNewsData();
            objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }


        [HttpGet]
        public ActionResult SearchG()
        {
            return View();
        }


        public JsonResult GetEventLatLng()
        {
            //  string strLatLng =  [{ "lat": "18.964700", "lng": "72.825800", "title": "pune", "description": "hello 1" }, { "lat": "18.641400", "lng": "72.872200", "title": "pune2", "description": "hello 2" }];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[");
            foreach (Models.EventMaster obj in new Models.EventMaster().GetEventData())
            {
                sb.Append("{\"lat\":\"" + obj.Lat + "\", \"lng\":\"" + obj.Lng + "\", \"title\":\"" + "Title &nbsp: " + obj.Title + "<br/>" + "Venue : " + obj.venue + "<br/>" + "Date &nbsp: " + obj.EventDate + "\",\"Date\":\"" + obj.EventDate + "\", \"description\":\"" + obj.venue + "\"},");
            }
            string strLatLng = sb.ToString();
            strLatLng = strLatLng.Substring(0, strLatLng.Length - 1) + "]";
            // strLatLng = strLatLng.Substring(strLatLng.PadRight(1, ',')); 
            return Json(strLatLng);
        }

        [HttpGet]
        public ActionResult About_UsCommittee()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_UsML = new Models.About_Us().GetAbout_UsData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult About_UsTeam()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_UsML = new Models.About_Us().GetAbout_UsData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult ContactUS()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult AboutUS_RCOE()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_Us_RCOE_ML = new Models.About_US_RoleCOE().GetAbout_Us_RCOE_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult AboutUs_JCOE()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_Us_JCOE_M = new Models.About_Us_JourneyOfCOE().GetAbout_Us_JCOE_DataS();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult ResourcesPastViewWebinars()
        {
            if (Request.QueryString["value"] == "R")
            {
                ViewBag.RegValue = "Done";
            }
            if (Request.QueryString["value"] == "NR")
            {
                ViewBag.RegValue = "Not Done";
            }
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpPost]
        public ActionResult ResourcesPastViewWebinars(string obj)
        {
            try
            {
                if (obj == "P")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebDataP();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else if (obj == "U")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebData();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebData();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
            }
            catch {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
        }

        [HttpPost]
        public ActionResult Registration(GCNI.Models.GCNIModel obj, string regbtn)
        {
            try
            {
                cmd = new SqlCommand("spRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", obj.objRegistration_M.FullName);
                cmd.Parameters.AddWithValue("@EmailID", obj.objRegistration_M.EmailID);
                cmd.Parameters.AddWithValue("@WebinarID", regbtn);
                cmd.Parameters.AddWithValue("@Qtype", "Registration");
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res > 0)
                {
                    ViewBag.Save = "Your Registration Is Successfully Done...!";
                    return RedirectToAction("ResourcesPastViewWebinars", "Index", new { value = "R" });
                }
                else
                {
                    return RedirectToAction("ResourcesPastViewWebinars", "Index", new { value = "NR" });
                }
                
            }
            catch
            {
                return RedirectToAction("ResourcesPastViewWebinars", "Index", new { value = "NR" });
            }
        }

        [HttpGet]
        public ActionResult Issues()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objIssues_ML = new Models.Issues().GetIssuesData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult GCNI_Secretariat()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult GCNI_Governing()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult GCNI_10Principles()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult GCNI_UNGC()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult Initiatives()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objActivitiesIni_ML = new Models.ActivitiesInitiative().GetActivityIniData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);   
        }
        //[HttpGet]
        //public ActionResult Issues()
        //{
           
        //    return View();
        //}
        [HttpGet]
        public ActionResult media()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objMedia_ML = new Models.Media().GetMedia_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult COEReports()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesCOE_ML = new Models.ResourcesCOE().GetResourcesCOEData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult Discussion()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesDiscussionDataL();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult OurPartners()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objOurPartners_ML = new Models.OurPartners().GetOurPartners_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult Tranings()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objTraining_ML = new Models.Training().GetTraining_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }

        [HttpGet]
        public ActionResult Knowledge(string sort, string hdd)
        {
            try
            {
                if (sort == "ATOZ")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeATOZ_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else if (sort == "ZTOA")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeZTOA_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
            }
            catch
            {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
        }
        [HttpPost]
        public ActionResult Knowledge(string sort)
        {
            try
            {
                if (sort == "ATOZ")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeATOZ_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else if (sort == "ZTOA")
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeZTOA_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
                else
                {
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    //objGCNI.objPublicationtM = new Models.Publication();
                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
                }
            }
            catch
            {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
        }
        //        [HttpPost]
        //        public JsonResult Knowledge(string sort)
        //        {
        //            try
        //            {
        //                if (sort == "ATOZ")
        //                {
        //                    System.Text.StringBuilder sbSubscrib = new System.Text.StringBuilder();
        //                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
        //                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeATOZ_Data();
        //                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
        //                        sbSubscrib.Append("< table class='table lawTable '>");

        //                        sbSubscrib.Append("< tbody><tr><td class='red - txt col - lg - 2'>International</td><td class='col-lg-9'></td><td style ='border:none;' class='col-lg-1'>");
        //                        sbSubscrib.Append("< a href = 'javascript:void(0);' onclick='javascript:$('#knUprDiv').hide();  $('#LawUprMinus').hide();$('#LawUprPlus').show();'><img src = '../images/minus_sign.png' id='LawUprMinus' class='minusSign' /></a>");
        //                        sbSubscrib.Append("< a href = 'javascript:void(0);' onclick='javascript:$('#knUprDiv').show();  $('#LawUprMinus').show();$('#LawUprPlus').hide();'><img style = 'display:none;' src='../images/plus_sign.png'  class='minusSign ' id='LawUprPlus' /></a>");
        //                        sbSubscrib.Append("</td></tr></tbody></table><div class='row kn WebCnt' id='knUprDiv'><div class='pull-right'>");
        //                        sbSubscrib.Append("< select class='form-control' id='mySelect1' onchange='myFunction('mySelect1');'><option>Sort By</option><option value = 'ATOZ' > Title(A - Z) </ option ><option value='ZTOA' > Title(Z - A) </ option ></ select >");
        //                        sbSubscrib.Append("</ div >< div style='margin-top:4%'><ul style='list-style-type:none;' id='DDDigital'>");

        //                foreach(GCNI.Models.Knowledge obj in objGCNI.objKnowledge_ML)
        //                {
        //                            if (obj.TabCat == "LAWS" && obj.CountryCat == "International")
        //                            {
        //                            sbSubscrib.Append("< li style ='width:80%' >< p > @Html.Raw(obj.Title) </ p ></ li >< li style = 'width:80%' >< p > @Html.Raw(obj.Description) </ p ></ li >");
        //                            sbSubscrib.Append("< li class='red -txt' style='margin-left:80%; '><a href = '#' data-id='@Html.Raw('popup' + " + obj.id + ")' data-think1='@Html.Raw('Digital' + " + obj.id + ")'>Read More...<img src= '../images/adobe_icon.jpg' class='adobeIcon'/></a></li><li class='bline_know'></li>");
        //                            }
        //                }
        //                    sbSubscrib.Append("</ul></div></div><div class='ndiv' ><span class='red-txt' >National</span>");
        //                    sbSubscrib.Append("<a href = 'javascript:void(0);' onclick='javascript:$('#LawNation').hide();  $('#lawDwnMinus').hide();$('#lawDwnPlus').show();'><img src ='../images/minus_sign.png' class='pull-right plusSign' id='lawDwnMinus'  /></a>");
        //                    sbSubscrib.Append("<a href = 'javascript:void(0);' onclick='javascript:$('#LawNation').show();  $('#lawDwnPlus').hide();$('#lawDwnMinus').show();'> <img style = 'display:none;' src='../images/plus_sign.png'  class='pull-right plusSign' id='lawDwnPlus' /></a>");
        //                    sbSubscrib.Append("</div>< div class='row knBottomDiv WebCnt' id='LawNation'><div style = 'margin-top:3%' >< ul style='list-style-type:none;' id='DDDigital'>");
        //                foreach(GCNI.Models.Knowledge obj in objGCNI.objKnowledge_ML)
        //{
        //    if (obj.TabCat == "LAWS" && obj.CountryCat == "National")
        //    {


        //                            sbSubscrib.Append("< li style = 'width:80%' >< p > @Html.Raw(obj.Title) </ p ></ li >< li style = 'width:80%' >< p > @Html.Raw(obj.Description) </ p ></ li >");
        //                            sbSubscrib.Append("< li class='red -txt' style='margin-left:80%;margin-top:-15px;'><a href = '#' data-id='@Html.Raw('popup' + " + obj.id + ")' data-think1='@Html.Raw('Digital' + " + obj.id + ")' >Read More...</a><img src = '../images/adobe_icon.jpg' class='adobeIcon' /></li><li class='bline_know'></li>");
        //                    }
        //                }

        //                    sbSubscrib.Append("</ul></div></div>");
        //                        return Json(objGCNI);
        //                }
        //                else if (sort == "ZTOA")
        //                {
        //                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
        //                    //objGCNI.objPublicationtM = new Models.Publication();
        //                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledgeZTOA_Data();
        //                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
        //                    return Json(objGCNI);
        //                }
        //                else
        //                {
        //                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
        //                    //objGCNI.objPublicationtM = new Models.Publication();
        //                    objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
        //                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
        //                    return Json(objGCNI);
        //                }
        //            }
        //            catch
        //            {
        //                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
        //                //objGCNI.objPublicationtM = new Models.Publication();
        //                objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
        //                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
        //                return Json(objGCNI);
        //            }
        //        }
        [HttpGet]
        public ActionResult Careers()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objCarrers_ML = new Models.Carrers().GetCarrers_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult FAQS()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objFAQS_ML = new Models.FAQS().GetFAQS_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult News()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objNewML = new Models.News().GetNewsData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult Articles()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objArticleML = new Models.Article().GetArticleData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult Publications()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objPublicationtML = new Models.Publication().GetPublicationData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [HttpGet]
        public ActionResult OpinionPoll()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        public ActionResult Events(DateTime id)
        {
            // I am also ignoring the fact that more than one event can occur on one day, this is beyond 
            // the scope of the article.
            ViewBag.Title = string.Format("event on day {0}", id.ToShortDateString());
            ViewBag.Date = id;
            ViewBag.Content = "This is an event generated by a stub";
            return View();
        }

        [HttpPost]
        public ActionResult GetEventsForMonth(int month, int year)
        {
            //Need to return string as key (representing the day of the month) as:
            // 1. Cannot serialize a dictionary with an int key, only object or string.
            // 2. Javascript (the intended recipient) uses strings for "associative" arrays.
            Dictionary<string, string> events = new Dictionary<string, string>();
            // Foo'd to give only even event dates on even numbered months.
            for (int i = 1; i < 31; i += 2)
            {
                events.Add((month % 2 == 0 ? i + 1 : i).ToString(), string.Format("event on day {0}/{1}/{2}", i, month, year));
            }
            Thread.Sleep(500); //Simulate a database delay.
            return Json(events);
        }

        [HttpGet]
        public ActionResult GetInvolved()
        {
            try
            {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch
            {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
        }
        [HttpPost]
        public ActionResult GetInvolved(string feedback, string val)
        {
            try
            {
                cmd = new SqlCommand("spGetInvolved", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedBack", val);
                cmd.Parameters.AddWithValue("@Qtype", "Insertfeedback");
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res > 0)
                {
                    ViewBag.Save = "Your Query/Feedback Is Successfully Submited...!";
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch
            {
                ViewBag.Save = "Your Query/Feedback Is Not Submited...!";
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
        }

        [HttpPost]
        public JsonResult Mailer(string id)
        {
            try
            {
                sandcodeToOwner("Hi", "For Subscription");
                CommanMail(id, "You Are Subscribed Successfully....!","Hi Subscriber");
                return Json("Subscription is Done");
            }
            catch (Exception ex)
            {
                return Json("Invalid Email Id...!");
            }
        }

        public void CommanMail(string id, string bodymsg, string Subject)
        {

            string strMsg = "";
            try
            {
                MailMessage message = new MailMessage();
                MailAddress Sender = new MailAddress(ConfigurationManager.AppSettings["smtpUser"]);
                MailAddress receiver = new MailAddress(id);
                SmtpClient smtp = new SmtpClient()
                {
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"])

                };
                message.From = Sender;
                message.To.Add(receiver);
                message.Subject = Subject;
                message.Body = bodymsg;
                message.IsBodyHtml = true;
                smtp.Send(message);

                //MailMessage Loginfo = new MailMessage();
                //Loginfo.To.Add(id);
                //Loginfo.From = new MailAddress("Bhupeekr.77777@gmail.com");
                //Loginfo.Subject = "Voucher Code";
                //Loginfo.Body = "line" + "And Your Vouchar Code is :- '" + Vouchercode + "'";
                //Loginfo.IsBodyHtml = true;
                //smtp.Send(Loginfo);

                strMsg = "Mail  sent";
            }

            catch (Exception e)
            {
                strMsg = e.Message;
            }

        }

        public void sandcodeToOwner(string bodymsg, string Subject)
        {

            try
            {
                MailMessage message = new MailMessage();
                MailAddress Sender = new MailAddress(ConfigurationManager.AppSettings["smtpUser"]);
                MailAddress receiver = new MailAddress("Bhupendrakr.77777@rediffmail.com");
                SmtpClient smtp = new SmtpClient()
                {
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"])

                };
                message.From = Sender;
                message.To.Add(receiver);
                message.Subject = Subject;
                message.Body = bodymsg;
                message.IsBodyHtml = true;
                smtp.Send(message);
            }

            catch (Exception e)
            {

            }
        }
    }
}
