using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;
using System.Web.UI;
using System.Runtime.Serialization.Json;


namespace GCNI.Models
{
    public class GCNIModel
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public HomeMaster objHomeMaster { get; set; }
        public List<EventMaster> objEventML { get; set; }
        public EventMaster objEventM { get; set; }
        public List<Publication> objPublicationtML { get; set; }
        public Publication objPublicationtM { get; set; }
        public List<News> objNewML { get; set; }
        public News objNewM { get; set; }
        public List<Article> objArticleML { get; set; }
        public Article objArticleM { get; set; }
        public List<About_Us> objAbout_UsML { get; set; }
        public About_Us objAbout_UsM { get; set; }
        public List<About_Us_JourneyOfCOE> objAbout_Us_JCOE_ML { get; set; }
        public About_Us_JourneyOfCOE objAbout_Us_JCOE_M { get; set; }
        public List<About_US_RoleCOE> objAbout_Us_RCOE_ML { get; set; }
        public About_US_RoleCOE objAbout_Us_RCOE_M { get; set; }
        public List<ActivitiesInitiative> objActivitiesIni_ML { get; set; }
        public ActivitiesInitiative objActivitiesIni_M { get; set; }
        public List<Issues> objIssues_ML { get; set; }
        public Issues objIssues_M { get; set; }
        public List<ResourcesCOE> objResourcesCOE_ML { get; set; }
        public ResourcesCOE objResourcesCOE_M { get; set; }
        public List<ResourcesWebinars> objResourcesWebinars_ML { get; set; }
        public ResourcesWebinars objResourcesWebinars_M { get; set; }
        public List<GovCouncilingANDSecretariat> objGovCounAndSec_ML { get; set; }
        public GovCouncilingANDSecretariat objGovCounAndSec_M { get; set; }

        public List<OurPartners> objOurPartners_ML { get; set; }
        public OurPartners objOurPartners_M { get; set; }
        public List<Training> objTraining_ML { get; set; }
        public Training objTraining_M { get; set; }

        public List<TabMenu> objTabMenu_ML { get; set; }
        public TabMenu objTabMenu_M { get; set; }
        public List<Knowledge> objKnowledge_ML { get; set; }
        public Knowledge objKnowledge_M { get; set; }
        public List<Carrers> objCarrers_ML { get; set; }
        public Carrers objCarrers_M { get; set; }

        public List<Media> objMedia_ML { get; set; }
        public Media objMedia_M { get; set; }

        public List<FAQS> objFAQS_ML { get; set; }
        public FAQS objFAQS_M { get; set; }
        public List<OpinionPoll> objOpinionPoll_ML { get; set; }
        public OpinionPoll objOpinionPoll_M { get; set; }
        public List<Blog> objBlog_ML { get; set; }
        public Blog objBlog_M { get; set; }
        public List<GetInvolved> objGetInvolved_ML { get; set; }
        public GetInvolved objGetInvolved_M { get; set; }
        public List<GetInvoleved_Feedback> objGetInvolvedFeedback_ML { get; set; }
        public GetInvoleved_Feedback objGetInvolvedFeedback_M { get; set; }
        public List<Registration> objRegistration_ML { get; set; }
        public Registration objRegistration_M { get; set; }
        //public List<Blog> objBlogML { get; set; }
        //public Blog objBlogM { get; set; }

        public DataTable getData(string procName, string Qtype)
        {
                cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Qtype", Qtype);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
        }
    }
    public class HomeMaster
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Logo1 { get; set; }
        public string Logo2 { get; set; }
        public string MainBannerImage1 { get; set; }
        public string MainBannerImage2 { get; set; }
        public string MainBannerImage3 { get; set; }
        public string MainBannerImage4{ get; set; }
        public string MainBannerImage5 { get; set; }
        public string SubBannerImage { get; set; }
        public string FBLink { get; set; }
        public string TWLink { get; set; }
        public string YouTubeLink { get; set; }
        public string INLink { get; set; }
        public string MsgIconLink { get; set; }
        public string SubscribEmailLink { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public HomeMaster GetHomeMaster_Data()
        {
            dt = obj.getData("spHomeMaster", "Select");
            HomeMaster objHomeMaster = new HomeMaster();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    objHomeMaster.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objHomeMaster.Logo1 = dt.Rows[i]["Logo1"].ToString();
                    objHomeMaster.Logo2 = dt.Rows[i]["Logo2"].ToString();
                    objHomeMaster.MainBannerImage1 = dt.Rows[i]["MainBannerImage1"].ToString();
                    objHomeMaster.MainBannerImage2 = dt.Rows[i]["MainBannerImage2"].ToString();
                    objHomeMaster.MainBannerImage3 = dt.Rows[i]["MainBannerImage3"].ToString();
                    objHomeMaster.MainBannerImage4 = dt.Rows[i]["MainBannerImage4"].ToString();
                    objHomeMaster.MainBannerImage5 = dt.Rows[i]["MainBannerImage5"].ToString();
                    objHomeMaster.SubBannerImage = dt.Rows[i]["SubBannerImage"].ToString();
                    objHomeMaster.FBLink = dt.Rows[i]["FBLink"].ToString();
                    objHomeMaster.TWLink = dt.Rows[i]["TWLink"].ToString();
                    objHomeMaster.YouTubeLink = dt.Rows[i]["YouTubeLink"].ToString();
                    objHomeMaster.INLink = dt.Rows[i]["INLink"].ToString();
                    objHomeMaster.MsgIconLink = dt.Rows[i]["MsgIconLink"].ToString();
                    objHomeMaster.SubscribEmailLink = dt.Rows[i]["SubscribEmailLink"].ToString();
                    objHomeMaster.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objHomeMaster.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                }
            }
            return objHomeMaster;
        }

    }
    public class EventMaster
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string venue { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public string EventDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        public int MyProperty { get; set; }

        public string FilesToBeUploaded { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<EventMaster> GetEventData()
        {
            dt=obj.getData("spEvent","Select");
            List<EventMaster> objEventMaster = new List<EventMaster>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EventMaster objEventM = new EventMaster();
                    objEventM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objEventM.Title = dt.Rows[i]["Title"].ToString();
                    objEventM.Description = dt.Rows[i]["Description"].ToString();
                    objEventM.venue = dt.Rows[i]["venue"].ToString();
                    objEventM.Lat = dt.Rows[i]["Lat"].ToString();
                    objEventM.Lng = dt.Rows[i]["Lng"].ToString();
                    objEventM.VideoURL = dt.Rows[i]["VideoURL"].ToString();
                    objEventM.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objEventM.EventDate = dt.Rows[i]["EventDate"].ToString();
                    objEventM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objEventMaster.Add(objEventM);
                }
            }
            return objEventMaster;
        }
        public List<EventMaster> GetEventData2()
        {
            dt = obj.getData("spEvent", "Select2");
            List<EventMaster> objEventMaster = new List<EventMaster>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EventMaster objEventM = new EventMaster();
                    objEventM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objEventM.Title = dt.Rows[i]["Title"].ToString();
                    objEventM.Description = dt.Rows[i]["Description"].ToString();
                    objEventM.venue = dt.Rows[i]["venue"].ToString();
                    objEventM.Lat = dt.Rows[i]["Lat"].ToString();
                    objEventM.Lng = dt.Rows[i]["Lng"].ToString();
                    objEventM.VideoURL = dt.Rows[i]["VideoURL"].ToString();
                    objEventM.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objEventM.EventDate = dt.Rows[i]["EventDate"].ToString();
                    objEventM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objEventMaster.Add(objEventM);
                }
            }
            return objEventMaster;
        }
        //public static EventMaster[] GetEventobj()
        //{
        //    GCNIModel obj = new GCNIModel();
        //    DataTable dt = new DataTable();
        //    dt = obj.getData("spEvent", "Select");
        //    List<EventMaster> objEventMaster = new List<EventMaster>();

        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            EventMaster objEventM = new EventMaster();
        //            objEventM.id = Convert.ToInt32(dt.Rows[i]["id"]);
        //            objEventM.Title = dt.Rows[i]["Title"].ToString();
        //            objEventM.Description = dt.Rows[i]["Description"].ToString();
        //            objEventM.venue = dt.Rows[i]["venue"].ToString();
        //            objEventM.Lat = dt.Rows[i]["Lat"].ToString();
        //            objEventM.Lng = dt.Rows[i]["Lng"].ToString();
        //            objEventM.VideoURL = dt.Rows[i]["VideoURL"].ToString();
        //            objEventM.ImageURL = dt.Rows[i]["ImageURL"].ToString();
        //            objEventM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
        //            objEventMaster.Add(objEventM);
        //        }
        //    }
        //    return objEventMaster.ToArray();
        //}

        //private string BindGMap()
        //{
        //    try
        //    {
        //        List<EventMaster> AddressList = new List<EventMaster>();
        //        dt = obj.getData("spEvent", "Select");
        //        if (dt.Rows.Count > 0)
        //        {

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string FullAddress = dt.Rows[i]["Lat"].ToString() + " " + dt.Rows[i]["Lng"].ToString() + ", " + dt.Rows[i]["Title"].ToString();
        //                EventMaster MapAddress = new EventMaster();
        //                MapAddress.Description = FullAddress;
        //                var locationService = new GoogleLocationService();
        //                var point = locationService.GetLatLongFromAddress(FullAddress);
        //                MapAddress.Lat = point.Latitude;
        //                MapAddress.Lng = point.Longitude;
        //                AddressList.Add(MapAddress);
        //            }
        //            string jsonString = JsonSerializer<List<EventMaster>>(AddressList);
        //            ScriptManager.RegisterArrayDeclaration(Page, "markers", jsonString);
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "GoogleMap();", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        //public string GetEventjsonData()
        //{
        //    dt = obj.getData("spEvent", "Select");
        //    if (dt.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            markers.Append(dt.Rows[i]["Lat"].ToString());
        //            markers.Append(dt.Rows[i]["Lng"].ToString());
        //            markers.Append(dt.Rows[i]["Title"].ToString());
        //        }
        //    }
        //    return Json(markers.ToString());
        //}
    }
    public class Publication
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
        public string FileURL { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Publication> GetPublicationData()
        {
            dt = obj.getData("spPublication", "Select");
            List<Publication> objPublicationMaster = new List<Publication>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Publication objPublicationM = new Publication();
                    objPublicationM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objPublicationM.Title = dt.Rows[i]["Title"].ToString();
                    objPublicationM.Auther = dt.Rows[i]["Auther"].ToString();
                    objPublicationM.Description = dt.Rows[i]["Description"].ToString();
                    objPublicationM.ThumbnailURL = dt.Rows[i]["ThumbnailURL"].ToString();
                    objPublicationM.FileURL = dt.Rows[i]["FileURL"].ToString();
                    objPublicationM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objPublicationMaster.Add(objPublicationM);
                }
            }
            return objPublicationMaster;
        }
        public List<Publication> GetPublicationData2()
        {
            dt = obj.getData("spPublication", "Select2");
            List<Publication> objPublicationMaster = new List<Publication>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Publication objPublicationM = new Publication();
                    objPublicationM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objPublicationM.Title = dt.Rows[i]["Title"].ToString();
                    objPublicationM.Auther = dt.Rows[i]["Auther"].ToString();
                    objPublicationM.Description = dt.Rows[i]["Description"].ToString();
                    objPublicationM.ThumbnailURL = dt.Rows[i]["ThumbnailURL"].ToString();
                    objPublicationM.FileURL = dt.Rows[i]["FileURL"].ToString();
                    objPublicationM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objPublicationMaster.Add(objPublicationM);
                }
            }
            return objPublicationMaster;
        }
    }
    public class News
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NewsFullDetails { get; set; }
        public string City { get; set; }
        public string NewsDate { get; set; }
        public string NewsImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<News> GetNewsData()
        {
            dt = obj.getData("spNews", "Select");
            List<News> objNewsMaster = new List<News>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News objNewsM = new News();
                    objNewsM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objNewsM.Title = dt.Rows[i]["Title"].ToString();
                    objNewsM.Description = dt.Rows[i]["Description"].ToString();
                    objNewsM.NewsFullDetails = dt.Rows[i]["NewsFullDetails"].ToString();
                    objNewsM.City = dt.Rows[i]["City"].ToString();
                    objNewsM.NewsDate = dt.Rows[i]["NewsDate"].ToString();
                    objNewsM.NewsImage = dt.Rows[i]["NewsImage"].ToString();
                    objNewsM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objNewsMaster.Add(objNewsM);
                }
            }
            return objNewsMaster;
        }
        public List<News> GetNewsData2()
        {
            dt = obj.getData("spNews", "Select2");
            List<News> objNewsMaster = new List<News>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News objNewsM = new News();
                    objNewsM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objNewsM.Title = dt.Rows[i]["Title"].ToString();
                    objNewsM.Description = dt.Rows[i]["Description"].ToString();
                    objNewsM.NewsFullDetails = dt.Rows[i]["NewsFullDetails"].ToString();
                    objNewsM.City = dt.Rows[i]["City"].ToString();
                    objNewsM.NewsDate = dt.Rows[i]["NewsDate"].ToString();
                    objNewsM.NewsImage = dt.Rows[i]["NewsImage"].ToString();
                    objNewsM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objNewsMaster.Add(objNewsM);
                }
            }
            return objNewsMaster;
        }
    }
    public class Article
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PDF { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }
        GCNIModel obj = new GCNIModel();
        public List<Article> GetArticleData()
        {
            dt = obj.getData("spArticle", "Select");
            List<Article> objArticleMaster = new List<Article>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article objArticle = new Article();
                    objArticle.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objArticle.Title = dt.Rows[i]["Title"].ToString();
                    objArticle.Description = dt.Rows[i]["Description"].ToString();
                    objArticle.PDF = dt.Rows[i]["PdfURL"].ToString();
                    objArticle.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objArticleMaster.Add(objArticle);
                }
            }
            return objArticleMaster;
        }
        public List<Article> GetArticleData2()
        {
            dt = obj.getData("spArticle", "Select2");
            List<Article> objArticleMaster = new List<Article>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article objArticle = new Article();
                    objArticle.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objArticle.Title = dt.Rows[i]["Title"].ToString();
                    objArticle.Description = dt.Rows[i]["Description"].ToString();
                    objArticle.PDF = dt.Rows[i]["PdfURL"].ToString();
                    objArticle.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objArticleMaster.Add(objArticle);
                }
            }
            return objArticleMaster;
        }
    }
    public class About_Us
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string ImageURL { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AboutUS_Category { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<About_Us> GetAbout_UsData()
        {
            dt = obj.getData("spAboutUS", "Select");
            List<About_Us> objAbout_UsSL = new List<About_Us>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    About_Us objAbout_UsS = new About_Us();
                    objAbout_UsS.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objAbout_UsS.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objAbout_UsS.Designation = dt.Rows[i]["Designation"].ToString();
                    objAbout_UsS.Name = dt.Rows[i]["Name"].ToString();
                    objAbout_UsS.Description = dt.Rows[i]["Description"].ToString();
                    objAbout_UsS.AboutUS_Category = dt.Rows[i]["AboutUS_Category"].ToString();
                    objAbout_UsS.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objAbout_UsS.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objAbout_UsSL.Add(objAbout_UsS);
                }
            }
            return objAbout_UsSL;
        }
    }
    public class About_Us_JourneyOfCOE
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string ImageURL { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<About_Us_JourneyOfCOE> GetAbout_Us_JCOE_Data()
        {
            dt = obj.getData("spAboutUS", "SelectJCOE");
            List<About_Us_JourneyOfCOE> objAbout_Us_JCOE_SL = new List<About_Us_JourneyOfCOE>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    About_Us_JourneyOfCOE objAbout_Us_JCOE_S = new About_Us_JourneyOfCOE();
                    objAbout_Us_JCOE_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objAbout_Us_JCOE_S.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objAbout_Us_JCOE_S.Description1 = dt.Rows[i]["Description1"].ToString();
                    objAbout_Us_JCOE_S.Description2 = dt.Rows[i]["Description2"].ToString();
                    objAbout_Us_JCOE_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objAbout_Us_JCOE_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objAbout_Us_JCOE_SL.Add(objAbout_Us_JCOE_S);
                }
            }
            return objAbout_Us_JCOE_SL;
        }
        public About_Us_JourneyOfCOE GetAbout_Us_JCOE_DataS()
        {
            dt = obj.getData("spAboutUS", "SelectJCOE");
            About_Us_JourneyOfCOE objAbout_Us_JCOE_S = new About_Us_JourneyOfCOE();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    objAbout_Us_JCOE_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objAbout_Us_JCOE_S.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objAbout_Us_JCOE_S.Description1 = dt.Rows[i]["Description1"].ToString();
                    objAbout_Us_JCOE_S.Description2 = dt.Rows[i]["Description2"].ToString();
                    objAbout_Us_JCOE_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objAbout_Us_JCOE_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    
                }
            }
            return objAbout_Us_JCOE_S;
        }
    }
    public class About_US_RoleCOE
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string TabType { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<About_US_RoleCOE> GetAbout_Us_RCOE_Data()
        {
            dt = obj.getData("spAboutUS", "SelectRCOE");
            List<About_US_RoleCOE> objAbout_Us_RCOE_SL = new List<About_US_RoleCOE>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    About_US_RoleCOE objAbout_Us_RCOE_S = new About_US_RoleCOE();
                    objAbout_Us_RCOE_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objAbout_Us_RCOE_S.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objAbout_Us_RCOE_S.Description = dt.Rows[i]["Description"].ToString();
                    objAbout_Us_RCOE_S.TabType = dt.Rows[i]["TabType"].ToString();
                    objAbout_Us_RCOE_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objAbout_Us_RCOE_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objAbout_Us_RCOE_SL.Add(objAbout_Us_RCOE_S);
                }
            }
            return objAbout_Us_RCOE_SL;
        }
        public About_US_RoleCOE GetAbout_Us_RCOE_DataS()
        {
            dt = obj.getData("spAboutUS", "SelectRCOE");
            About_US_RoleCOE objAbout_Us_RCOE_S = new About_US_RoleCOE();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    objAbout_Us_RCOE_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objAbout_Us_RCOE_S.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objAbout_Us_RCOE_S.Description = dt.Rows[i]["Description"].ToString();
                    objAbout_Us_RCOE_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objAbout_Us_RCOE_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                }
            }
            return objAbout_Us_RCOE_S;
        }
    }
    public class ActivitiesInitiative
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<ActivitiesInitiative> GetActivityIniData()
        {
            dt = obj.getData("spActivities", "Select");
            List<ActivitiesInitiative> objActivityIniSL = new List<ActivitiesInitiative>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ActivitiesInitiative objActivityIniS = new ActivitiesInitiative();
                    objActivityIniS.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objActivityIniS.Title = dt.Rows[i]["Title"].ToString();
                    objActivityIniS.Image = dt.Rows[i]["Image"].ToString();
                    objActivityIniS.Description = dt.Rows[i]["Description"].ToString();
                    objActivityIniS.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objActivityIniS.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objActivityIniSL.Add(objActivityIniS);
                }
            }
            return objActivityIniSL;
        }
    }
    public class Issues
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Category { get; set; }
        public string Img1URL { get; set; }
        public string Img2URL { get; set; }
        public string Img3URL { get; set; }
        public string Img4URL { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string OutcumPdfURL { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Issues> GetIssuesData()
        {
            dt = obj.getData("spIssues", "Select");
            List<Issues> objIssuesSL = new List<Issues>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Issues objIssuesS = new Issues();
                    objIssuesS.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objIssuesS.Category = dt.Rows[i]["Category"].ToString();
                    objIssuesS.Img1URL = dt.Rows[i]["Img1URL"].ToString();
                    objIssuesS.Img2URL = dt.Rows[i]["Img2URL"].ToString();
                    objIssuesS.Img3URL = dt.Rows[i]["Img3URL"].ToString();
                    objIssuesS.Img4URL = dt.Rows[i]["Img4URL"].ToString();
                    objIssuesS.Heading = dt.Rows[i]["Heading"].ToString();
                    objIssuesS.Description = dt.Rows[i]["Description"].ToString();
                    objIssuesS.OutcumPdfURL = dt.Rows[i]["OutcumPdfURL"].ToString();
                    objIssuesS.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objIssuesS.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    objIssuesSL.Add(objIssuesS);
                }
            }
            return objIssuesSL;
        }
    }
    public class ResourcesCOE
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string pdfFileURL { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<ResourcesCOE> GetResourcesCOEData()
        {
            dt = obj.getData("spResources", "Select");
            List<ResourcesCOE> objResourcesCOE_SL = new List<ResourcesCOE>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResourcesCOE objResourcesCOE_S = new ResourcesCOE();
                    objResourcesCOE_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesCOE_S.Image = dt.Rows[i]["Image"].ToString();
                    objResourcesCOE_S.Title = dt.Rows[i]["Title"].ToString();
                    objResourcesCOE_S.Author = dt.Rows[i]["Author"].ToString();
                    objResourcesCOE_S.pdfFileURL = dt.Rows[i]["pdf_File_URL"].ToString();
                    objResourcesCOE_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesCOE_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objResourcesCOE_SL.Add(objResourcesCOE_S);
                }
            }
            return objResourcesCOE_SL;
        }
    }
    public class ResourcesWebinars
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string TradeTitle { get; set; }
        public string TradeDate { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<ResourcesWebinars> GetoResourcesWebData()
        {
            dt = obj.getData("spResources", "SelectRW");
            List<ResourcesWebinars> objResourcesWeb_SL = new List<ResourcesWebinars>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResourcesWebinars objResourcesWeb_S = new ResourcesWebinars();
                    objResourcesWeb_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesWeb_S.TradeTitle = dt.Rows[i]["TradeTitle"].ToString();
                    objResourcesWeb_S.TradeDate = Convert.ToString(dt.Rows[i]["TradeDate"]);
                    objResourcesWeb_S.Time = dt.Rows[i]["Time"].ToString();
                    objResourcesWeb_S.Description = dt.Rows[i]["Description"].ToString();
                    objResourcesWeb_S.VideoLink = dt.Rows[i]["VideoLink"].ToString();
                    objResourcesWeb_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesWeb_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objResourcesWeb_SL.Add(objResourcesWeb_S);
                }
            }
            return objResourcesWeb_SL;
        }
        public List<ResourcesWebinars> GetoResourcesWebDataAll()
        {
            dt = obj.getData("spResources", "SelectWebinar");
            List<ResourcesWebinars> objResourcesWeb_SL = new List<ResourcesWebinars>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResourcesWebinars objResourcesWeb_S = new ResourcesWebinars();
                    objResourcesWeb_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesWeb_S.TradeTitle = dt.Rows[i]["TradeTitle"].ToString();
                    objResourcesWeb_S.TradeDate = Convert.ToString(dt.Rows[i]["TradeDate"]);
                    objResourcesWeb_S.Time = dt.Rows[i]["Time"].ToString();
                    objResourcesWeb_S.Description = dt.Rows[i]["Description"].ToString();
                    objResourcesWeb_S.VideoLink = dt.Rows[i]["VideoLink"].ToString();
                    objResourcesWeb_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesWeb_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objResourcesWeb_SL.Add(objResourcesWeb_S);
                }
            }
            return objResourcesWeb_SL;
        }
        
        public List<ResourcesWebinars> GetoResourcesWebDataP()
        {
            dt = obj.getData("spResources", "SelectRWP");
            List<ResourcesWebinars> objResourcesWeb_SL = new List<ResourcesWebinars>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResourcesWebinars objResourcesWeb_S = new ResourcesWebinars();
                    objResourcesWeb_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesWeb_S.TradeTitle = dt.Rows[i]["TradeTitle"].ToString();
                    objResourcesWeb_S.TradeDate = Convert.ToString(dt.Rows[i]["TradeDate"]);
                    objResourcesWeb_S.Time = dt.Rows[i]["Time"].ToString();
                    objResourcesWeb_S.Description = dt.Rows[i]["Description"].ToString();
                    objResourcesWeb_S.VideoLink = dt.Rows[i]["VideoLink"].ToString();
                    objResourcesWeb_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesWeb_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objResourcesWeb_SL.Add(objResourcesWeb_S);
                }
            }
            return objResourcesWeb_SL;
        }

        public List<ResourcesWebinars> GetoResourcesDiscussionDataL()
        {
            dt = obj.getData("spResources", "SelectRD");
            List<ResourcesWebinars> objResourcesDis_SL = new List<ResourcesWebinars>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ResourcesWebinars objResourcesDis_S = new ResourcesWebinars();
                    objResourcesDis_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesDis_S.TradeDate = Convert.ToString(dt.Rows[i]["Date"]);
                    objResourcesDis_S.Time = dt.Rows[i]["Time"].ToString();
                    objResourcesDis_S.Description = dt.Rows[i]["ResouresDescription"].ToString();
                    objResourcesDis_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesDis_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objResourcesDis_SL.Add(objResourcesDis_S);
                }
            }
            return objResourcesDis_SL;
        }

        public ResourcesWebinars GetoResourcesDiscussionData()
        {
            dt = obj.getData("spResources", "SelectRD");
            ResourcesWebinars objResourcesDis_S = new ResourcesWebinars();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                 
                    objResourcesDis_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objResourcesDis_S.TradeDate = Convert.ToString(dt.Rows[i]["TradeDate"]);
                    objResourcesDis_S.Time = dt.Rows[i]["Time"].ToString();
                    objResourcesDis_S.Description = dt.Rows[i]["Description"].ToString();
                    objResourcesDis_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objResourcesDis_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                }
            }
            return objResourcesDis_S;
        }

    }
    public class GovCouncilingANDSecretariat
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Cat { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<GovCouncilingANDSecretariat> GetGovConANDSecData()
        {
            dt = obj.getData("spGovCouncilAndSecret", "Select");
            List<GovCouncilingANDSecretariat> objGovConANDSec_SL = new List<GovCouncilingANDSecretariat>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GovCouncilingANDSecretariat objGovConANDSec_S = new GovCouncilingANDSecretariat();
                    objGovConANDSec_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objGovConANDSec_S.Cat = dt.Rows[i]["Category"].ToString();
                    objGovConANDSec_S.Link = dt.Rows[i]["Link"].ToString();
                    objGovConANDSec_S.Description = dt.Rows[i]["Description"].ToString();
                    objGovConANDSec_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objGovConANDSec_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objGovConANDSec_SL.Add(objGovConANDSec_S);
                }
            }
            return objGovConANDSec_SL;
        }
    }
    public class OurPartners
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<OurPartners> GetOurPartners_Data()
        {
            dt = obj.getData("spOurPartners", "Select");
            List<OurPartners> objOurPartners_SL = new List<OurPartners>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OurPartners objOurPartners_S = new OurPartners();
                    objOurPartners_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objOurPartners_S.Title = dt.Rows[i]["Title"].ToString();
                    objOurPartners_S.Image = dt.Rows[i]["Image"].ToString();
                    objOurPartners_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objOurPartners_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objOurPartners_SL.Add(objOurPartners_S);
                }
            }
            return objOurPartners_SL;
        }
        
    }
    public class Training
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Training> GetTraining_Data()
        {
            dt = obj.getData("spTraining", "Select");
            List<Training> objTraining_SL = new List<Training>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Training objTraining_S = new Training();
                    objTraining_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objTraining_S.Title = dt.Rows[i]["Title"].ToString();
                    objTraining_S.Description = dt.Rows[i]["Description"].ToString();
                    objTraining_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objTraining_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objTraining_SL.Add(objTraining_S);
                }
            }
            return objTraining_SL;
        }

    }
    public class TabMenu
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Value { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<TabMenu> GetTabMenu_Data()
        {
            dt = obj.getData("spAboutUS", "getTabitem");
            List<TabMenu> objTabMenu_SL = new List<TabMenu>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TabMenu objTabMenu_S = new TabMenu();
                    objTabMenu_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objTabMenu_S.Value = dt.Rows[i]["Value"].ToString();
                    objTabMenu_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objTabMenu_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objTabMenu_SL.Add(objTabMenu_S);
                }
            }
            return objTabMenu_SL;
        }

    }
    public class Knowledge
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Pdf_File_Link { get; set; }
        public string CountryCat { get; set; }
        public string TabCat { get; set; }
        public string Status { get; set; }
        public string BillLinkUrl { get; set; }
        public string IsActive { get; set; }
        //public bool IsDisplayOnHome { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Knowledge> GetKnowledge_Data()
        {
            dt = obj.getData("spKnowledge", "Select");
            List<Knowledge> objKnowledge_SL = new List<Knowledge>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Knowledge objKnowledge_S = new Knowledge();
                    objKnowledge_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objKnowledge_S.Title = dt.Rows[i]["Title"].ToString();
                    objKnowledge_S.Description = dt.Rows[i]["Description"].ToString();
                    objKnowledge_S.Pdf_File_Link = dt.Rows[i]["Pdf_File_Link"].ToString();
                    objKnowledge_S.CountryCat = dt.Rows[i]["CountryCat"].ToString();
                    objKnowledge_S.TabCat = dt.Rows[i]["TabCat"].ToString();
                    objKnowledge_S.Status = dt.Rows[i]["Status"].ToString();
                    objKnowledge_S.BillLinkUrl = dt.Rows[i]["BillLinkUrl"].ToString();
                    objKnowledge_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objKnowledge_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objKnowledge_SL.Add(objKnowledge_S);
                }
            }
            return objKnowledge_SL;
        }
        public List<Knowledge> GetKnowledgeATOZ_Data()
        {
            dt = obj.getData("spKnowledge", "SelectATOZ");
            List<Knowledge> objKnowledge_SL = new List<Knowledge>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Knowledge objKnowledge_S = new Knowledge();
                    objKnowledge_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objKnowledge_S.Title = dt.Rows[i]["Title"].ToString();
                    objKnowledge_S.Description = dt.Rows[i]["Description"].ToString();
                    objKnowledge_S.Pdf_File_Link = dt.Rows[i]["Pdf_File_Link"].ToString();
                    objKnowledge_S.CountryCat = dt.Rows[i]["CountryCat"].ToString();
                    objKnowledge_S.TabCat = dt.Rows[i]["TabCat"].ToString();
                    objKnowledge_S.Status = dt.Rows[i]["Status"].ToString();
                    objKnowledge_S.BillLinkUrl = dt.Rows[i]["BillLinkUrl"].ToString();
                    objKnowledge_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objKnowledge_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objKnowledge_SL.Add(objKnowledge_S);
                }
            }
            return objKnowledge_SL;
        }
        public List<Knowledge> GetKnowledgeZTOA_Data()
        {
            dt = obj.getData("spKnowledge", "SelectZTOA");
            List<Knowledge> objKnowledge_SL = new List<Knowledge>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Knowledge objKnowledge_S = new Knowledge();
                    objKnowledge_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objKnowledge_S.Title = dt.Rows[i]["Title"].ToString();
                    objKnowledge_S.Description = dt.Rows[i]["Description"].ToString();
                    objKnowledge_S.Pdf_File_Link = dt.Rows[i]["Pdf_File_Link"].ToString();
                    objKnowledge_S.CountryCat = dt.Rows[i]["CountryCat"].ToString();
                    objKnowledge_S.TabCat = dt.Rows[i]["TabCat"].ToString();
                    objKnowledge_S.Status = dt.Rows[i]["Status"].ToString();
                    objKnowledge_S.BillLinkUrl = dt.Rows[i]["BillLinkUrl"].ToString();
                    objKnowledge_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objKnowledge_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objKnowledge_SL.Add(objKnowledge_S);
                }
            }
            return objKnowledge_SL;
        }

    }
    public class Carrers
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Heading { get; set; }
        public string SubHead { get; set; }
        public string JobTitle { get; set; }
        public string Duration { get; set; }
        public string JobDescription { get; set; }
        public string ApplyEmail { get; set; }
        public string LastHead { get; set; }
        public string LinkEmail { get; set; }
        public string Category { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Carrers> GetCarrers_Data()
        {
            dt = obj.getData("spCarrers", "Select");
            List<Carrers> objCarrers_SL = new List<Carrers>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Carrers objCarrers_S = new Carrers();
                    objCarrers_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objCarrers_S.Heading = dt.Rows[i]["Heading"].ToString();
                    objCarrers_S.SubHead = dt.Rows[i]["SubHead"].ToString();
                    objCarrers_S.JobTitle = dt.Rows[i]["JobTitle"].ToString();
                    objCarrers_S.Duration = dt.Rows[i]["Duration"].ToString();
                    objCarrers_S.JobDescription = dt.Rows[i]["JobDescription"].ToString();
                    objCarrers_S.ApplyEmail = dt.Rows[i]["ApplyEmail"].ToString();
                    objCarrers_S.LastHead = dt.Rows[i]["LastHead"].ToString();
                    objCarrers_S.LinkEmail = dt.Rows[i]["LinkEmail"].ToString();
                    objCarrers_S.Category = dt.Rows[i]["Category"].ToString();
                    objCarrers_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objCarrers_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objCarrers_SL.Add(objCarrers_S);
                }
            }
            return objCarrers_SL;
        }

    }
    public class Media
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string FileURL { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Media> GetMedia_Data()
        {
            dt = obj.getData("spMedia", "Select");
            List<Media> objMedia_SL = new List<Media>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Media objMedia_S = new Media();
                    objMedia_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objMedia_S.Heading = dt.Rows[i]["Heading"].ToString();
                    objMedia_S.Description = dt.Rows[i]["Description"].ToString();
                    objMedia_S.FileURL = dt.Rows[i]["FileURL"].ToString();
                    objMedia_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objMedia_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objMedia_SL.Add(objMedia_S);
                }
            }
            return objMedia_SL;
        }

    }
    public class FAQS
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Ques { get; set; }
        public string Head { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<FAQS> GetFAQS_Data()
        {
            dt = obj.getData("spFAQs", "Select");
            List<FAQS> objFAQS_SL = new List<FAQS>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FAQS objFAQS_S = new FAQS();
                    objFAQS_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objFAQS_S.Ques = dt.Rows[i]["Ques"].ToString();
                    objFAQS_S.Head = dt.Rows[i]["Head"].ToString();
                    objFAQS_S.Description = dt.Rows[i]["Description"].ToString();
                    objFAQS_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objFAQS_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objFAQS_SL.Add(objFAQS_S);
                }
            }
            return objFAQS_SL;
        }

    }
    public class OpinionPoll
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Question { get; set; }
        public int OptionYes { get; set; }
        public int OptionNo { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<OpinionPoll> GetOpinionPoll_Data()
        {
            dt = obj.getData("spOpinionPoll", "Select");
            List<OpinionPoll> objOpinionPoll_SL = new List<OpinionPoll>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OpinionPoll objOpinionPoll_S = new OpinionPoll();
                    objOpinionPoll_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objOpinionPoll_S.Question = dt.Rows[i]["Question"].ToString();
                    objOpinionPoll_S.OptionYes = Convert.ToInt32(dt.Rows[i]["Option_Yes"]);
                    objOpinionPoll_S.OptionNo = Convert.ToInt32(dt.Rows[i]["Option_No"]);
                    objOpinionPoll_S.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["DisplayOnHome"]);
                    objOpinionPoll_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objOpinionPoll_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objOpinionPoll_SL.Add(objOpinionPoll_S);
                }
            }
            return objOpinionPoll_SL;
        }
        public List<OpinionPoll> GetOpinionPoll_Data2()
        {
            dt = obj.getData("spOpinionPoll", "Select2");
            List<OpinionPoll> objOpinionPoll_SL = new List<OpinionPoll>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OpinionPoll objOpinionPoll_S = new OpinionPoll();
                    objOpinionPoll_S.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objOpinionPoll_S.Question = dt.Rows[i]["Question"].ToString();
                    objOpinionPoll_S.OptionYes = Convert.ToInt32(dt.Rows[i]["Option_Yes"]);
                    objOpinionPoll_S.OptionNo = Convert.ToInt32(dt.Rows[i]["Option_No"]);
                    objOpinionPoll_S.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["DisplayOnHome"]);
                    objOpinionPoll_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objOpinionPoll_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    //objAbout_UsS.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplayOnHome"]);
                    objOpinionPoll_SL.Add(objOpinionPoll_S);
                }
            }
            return objOpinionPoll_SL;
        }

    }
    public class Blog
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDisplayOnHome { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Blog> GetBlogData()
        {
            dt = obj.getData("spBlog", "Select");
            List<Blog> objBlogMaster = new List<Blog>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Blog objBlogM = new Blog();
                    objBlogM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objBlogM.Title = dt.Rows[i]["Title"].ToString();
                    objBlogM.Description = dt.Rows[i]["Description"].ToString();
                    objBlogM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplay"]);
                    objBlogM.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objBlogM.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    objBlogMaster.Add(objBlogM);
                }
            }
            return objBlogMaster;
        }
        public List<Blog> GetBlogData2()
        {
            dt = obj.getData("spBlog", "Select2");
            List<Blog> objBlogMaster = new List<Blog>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Blog objBlogM = new Blog();
                    objBlogM.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objBlogM.Title = dt.Rows[i]["Title"].ToString();
                    objBlogM.Description = dt.Rows[i]["Description"].ToString();
                    objBlogM.IsDisplayOnHome = Convert.ToBoolean(dt.Rows[i]["IsDisplay"]);
                    objBlogM.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objBlogM.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    objBlogMaster.Add(objBlogM);
                }
            }
            return objBlogMaster;
        }
    }
    public class GetInvolved
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Catagory { get; set; }
        public string ImageTitle { get; set; }
        public string ImageURL { get; set; }
        public string Question { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<GetInvolved> GetInvolved_Data()
        {
            dt = obj.getData("spGetInvolved", "Select");
            List<GetInvolved> objGetInvolved_SL = new List<GetInvolved>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetInvolved objGetInvolved_S = new GetInvolved();
                    objGetInvolved_S.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    objGetInvolved_S.Catagory = dt.Rows[i]["Catagory"].ToString();
                    objGetInvolved_S.ImageTitle = dt.Rows[i]["ImageTitle"].ToString();
                    objGetInvolved_S.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objGetInvolved_S.Question = dt.Rows[i]["Question"].ToString();
                    objGetInvolved_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objGetInvolved_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    objGetInvolved_SL.Add(objGetInvolved_S);
                }
            }
            return objGetInvolved_SL;
        }
    }
    public class GetInvoleved_Feedback
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string Feedback { get; set; }
        public string Commint { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<GetInvoleved_Feedback> GetInvoleved_FeedbackData()
        {
            dt = obj.getData("spGetInvolved", "Selectfeedback");
            List<GetInvoleved_Feedback> objGetInvolvedFeedback_SL = new List<GetInvoleved_Feedback>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetInvoleved_Feedback objGetInvolvedFeedback_S = new GetInvoleved_Feedback();
                    objGetInvolvedFeedback_S.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    objGetInvolvedFeedback_S.Feedback = dt.Rows[i]["Feedback"].ToString();
                    objGetInvolvedFeedback_S.Commint = dt.Rows[i]["Comment"].ToString();
                    objGetInvolvedFeedback_S.IsActive = dt.Rows[i]["IsActive"].ToString();
                    objGetInvolvedFeedback_S.CreatedOn = dt.Rows[i]["CreatedOn"].ToString();
                    objGetInvolvedFeedback_SL.Add(objGetInvolvedFeedback_S);
                }
            }
            return objGetInvolvedFeedback_SL;
        }
    }
    public class Registration
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int id { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string WebinarTitle { get; set; }
        public string WebinarDate { get; set; }
        public string WebinarTime { get; set; }
        public string IsActive { get; set; }
        public string RegistrationDate { get; set; }

        GCNIModel obj = new GCNIModel();
        public List<Registration> GetRegistrationData()
        {
            dt = obj.getData("spRegistration", "Select");
            List<Registration> objRegistration_SL = new List<Registration>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration objRegistration_S = new Registration();
                    objRegistration_S.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    objRegistration_S.FullName = dt.Rows[i]["FullName"].ToString();
                    objRegistration_S.EmailID = dt.Rows[i]["EmailID"].ToString();
                    objRegistration_S.RegistrationDate = dt.Rows[i]["RegistrationDate"].ToString();
                    objRegistration_S.WebinarTitle = dt.Rows[i]["TradeTitle"].ToString();
                    objRegistration_S.WebinarDate = dt.Rows[i]["TradeDate"].ToString();
                    objRegistration_S.WebinarTime = dt.Rows[i]["Time"].ToString();
                    objRegistration_SL.Add(objRegistration_S);
                }
            }
            return objRegistration_SL;
        }
    }
}