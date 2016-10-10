using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCNI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using GCNI_DAL;
using System.Web.Security;
using System.Globalization;

namespace GCNI.Controllers
{
    public class AdminController : Controller
    {
        #region used Variables
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string Logo1;
        string Logo2;
        string MainBanner1;
        string MainBanner2;
        string MainBanner3;
        string MainBanner4;
        string MainBanner5;
        string SubBanner;
        string Logo1URL;
        string Logo2URL;
        string MainBannerURL;
        string SubBannerURL;
        string pubthumbImage;
        string AboutUsImage;
        string pubFile;
        string imgURL;
        string imgURL2;
        string fileURL;
        string fileURL2;
        string VideoURL;
        string PDFfileURL;
        #endregion
        //
        // GET: /Admin/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userId, string password)
        {

            string userIdConfig = ConfigurationManager.AppSettings["UserId"];
            string passwordConfig = ConfigurationManager.AppSettings["pwd"];

            if (userId == userIdConfig && password == passwordConfig)
            {
                FormsAuthentication.SetAuthCookie(userId, false);
                return RedirectToAction("EventManagement");
            }
            else
                return RedirectToAction("Login");
        }

        #region Home Master Controller
        [HttpGet]
        public ActionResult HomePageManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HomePageManagement(GCNI.Models.GCNIModel obj, string hdd, string Log1,string Log2,string MBanner1, string MBanner2, string MBanner3, string MBanner4, string MBanner5, string SBanner,string btntype, string id)
        {
            try
            {
                if (btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    Logo1 = Guid.NewGuid().ToString() + fileName;
                                    Logo1URL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), Logo1);
                                    upload1.SaveAs(Logo1URL);
                                }

                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    Logo2 = Guid.NewGuid().ToString() + fileName;
                                    Logo2URL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), Logo2);
                                    upload1.SaveAs(Logo2URL);
                                }
                            }
                            else if (i == 2)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner1 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), MainBanner1);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 3)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner2 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), MainBanner2);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 4)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner3 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), MainBanner3);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 5)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner4 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), MainBanner4);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 6)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner5 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), MainBanner5);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 7)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    SubBanner = Guid.NewGuid().ToString() + fileName;
                                    SubBannerURL = Path.Combine(Server.MapPath("~/Uploads/HomeMaster"), SubBanner);
                                    upload1.SaveAs(SubBannerURL);
                                }
                            }
                        }
                    }
                    //if (Logo1URL != null && Logo2URL != null && MainBannerURL != null && SubBannerURL != null)
                    //{
                        int res = HomeMasterDAL.UpdateHomeMasterDAL(Logo1 != null ? Logo1 : Log1, Logo2 != null ? Logo2 : Log2, MainBanner1 != null ? MainBanner1 : MBanner1, MainBanner2 != null ? MainBanner2 : MBanner2, MainBanner3 != null ? MainBanner3 : MBanner3, MainBanner4 != null ? MainBanner4 : MBanner4, MainBanner5 != null ? MainBanner5 : MBanner5, SubBanner != null ? SubBanner : SBanner, obj.objHomeMaster.FBLink, obj.objHomeMaster.TWLink, obj.objHomeMaster.YouTubeLink, obj.objHomeMaster.INLink, obj.objHomeMaster.MsgIconLink, obj.objHomeMaster.SubscribEmailLink,"update","1");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Updated...!";
                        }
                    //}
                }
                
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Event Conroller
        [Authorize]
        [HttpGet]
        public ActionResult EventManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objEventM = new Models.EventMaster();
            objGCNI.objEventML = new Models.EventMaster().GetEventData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventManagement(GCNI.Models.GCNIModel obj, List<HttpPostedFileBase> fileUpload, string hdd, string btntype, string id, string Video, string Image)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                string ImagePath="";
                int count = 0;
                foreach (var file in fileUpload)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {

                                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.Ticks + Path.GetExtension(file.FileName);          //Path.GetFileName(file.FileName);
                                ImagePath = ImagePath + "," + fileName;
                                var path = Path.Combine(Server.MapPath("~/Uploads/EventImages"), fileName);
                                file.SaveAs(path);
                                count++;
                                
                            }
                        }
                        if (count == fileUpload.Count - 1)
                        {
                            break;
                        }
                    }
                if (ImagePath != null)
                    {
                        //List<Models.EventMaster> objem = new List<Models.EventMaster>();
                        //objem = new Models.EventMaster().GetEventData();
                        //if (objem.Count < 3)
                        //{
                        //    obj.objEventM.IsDisplayOnHome = true;
                        //}
                        //else
                        //{
                        //    obj.objEventM.IsDisplayOnHome = false;
                        //}
                        int res = EventDAL.InserEventDAL(obj.objEventM.Title, obj.objEventM.Description, obj.objEventM.venue, obj.objEventM.Lat, obj.objEventM.Lng, obj.objEventM.VideoURL, ImagePath, obj.objEventM.EventDate, obj.objEventM.IsDisplayOnHome, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spEvent", id,"delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    string ImagePath = "";
                    int count = 0;
                    foreach (var file in fileUpload)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.Ticks + Path.GetExtension(file.FileName);          //Path.GetFileName(file.FileName);
                                ImagePath = ImagePath + "," + fileName;
                                var path = Path.Combine(Server.MapPath("~/Uploads/EventImages"), fileName);
                                file.SaveAs(path);
                                count++;
                            }
                        }
                        if (count == fileUpload.Count - 1)
                        {
                            break;
                        }
                    }
                    int res = EventDAL.UploadEventDAL(obj.objEventM.Title, obj.objEventM.Description, obj.objEventM.venue, obj.objEventM.Lat, obj.objEventM.Lng, obj.objEventM.VideoURL != null ? obj.objEventM.VideoURL : Video, ImagePath != "" ? ImagePath : Image, obj.objEventM.EventDate, obj.objEventM.IsDisplayOnHome, "update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objEventML = new Models.EventMaster().GetEventData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objEventML = new Models.EventMaster().GetEventData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        [HttpPost]
        public ActionResult EventDelete(string id)
        {
            try
            {
                int res = CommanDeleteDAL.DeleteDAL("spEvent", id, "delete");
                if (res > 0)
                {
                    ViewBag.Message = "Data is Successfully Deleted.....!";
                }
                return this.RedirectToAction("Admin", "EventManagement");
            }
            catch
            {
                return View("PublicationManagement");
            }
        }
        #endregion

        #region Article Conroller
        [Authorize]
        [HttpGet]
        public ActionResult ArticleManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objArticleM = new Models.Article();
            objGCNI.objArticleML = new Models.Article().GetArticleData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ArticleManagement(GCNI.Models.GCNIModel obj, string hdd, string btntype, string file, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    fileURL = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/ArticlePDF"), fileURL);
                                    upload1.SaveAs(imgURL);
                                }
                        }
                    List<Models.Article> objem = new List<Models.Article>();
                    objem = new Models.Article().GetArticleData();
                    if (objem.Count < 3)
                    {
                        obj.objArticleM.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objArticleM.IsDisplayOnHome = false;
                    }
                    int res=GCNI_DAL.ArticleDAL.InserArticleDAL(obj.objArticleM.Title, obj.objArticleM.Description, obj.objArticleM.IsDisplayOnHome, fileURL, "Insert");
                    //cmd = new SqlCommand("spArticle", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Title", obj.objArticleM.Title);
                    //cmd.Parameters.AddWithValue("@Description", obj.objArticleM.Description);
                    //cmd.Parameters.AddWithValue("@IsDisplayOnHome", obj.objArticleM.IsDisplayOnHome);
                    //cmd.Parameters.AddWithValue("@Qtype", "Insert");
                    //con.Open();
                    //int res = cmd.ExecuteNonQuery();
                    //con.Close();

                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spArticle", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var upload1 = Request.Files[i];
                        if (upload1 != null && upload1.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(upload1.FileName);
                            fileName = fileName.Replace(" ", "_");
                            fileURL = Guid.NewGuid().ToString() + fileName;
                            imgURL = Path.Combine(Server.MapPath("~/Uploads/ArticlePDF"), fileURL);
                            upload1.SaveAs(imgURL);
                        }
                    }
                    List<Models.Article> objem = new List<Models.Article>();
                    objem = new Models.Article().GetArticleData();
                    if (objem.Count < 3)
                    {
                        obj.objArticleM.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objArticleM.IsDisplayOnHome = false;
                    }
                    int res = GCNI_DAL.ArticleDAL.UpdateArticleDAL(obj.objArticleM.Title, obj.objArticleM.Description, obj.objArticleM.IsDisplayOnHome, fileURL!= null?fileURL: file, "update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objArticleM = new Models.Article();
                objGCNI.objArticleML = new Models.Article().GetArticleData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objArticleM = new Models.Article();
                objGCNI.objArticleML = new Models.Article().GetArticleData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        [HttpPost]
        public ActionResult ArticleDelete(string id)
        {
            try
            {
                int res = CommanDeleteDAL.DeleteDAL("spArticle", id, "delete");
                if (res > 0)
                {
                    ViewBag.Message = "Data is Successfully Deleted.....!";
                }
                return this.RedirectToAction("Admin", "ArticleManagement");
                //return View("PublicationManagement");
            }
            catch
            {
                return View("PublicationManagement");
            }
        }
        #endregion

        #region News Conroller
        [Authorize]
        [HttpGet]
        public ActionResult NewsManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objNewM = new Models.News();
            objGCNI.objNewML = new Models.News().GetNewsData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewsManagement(GCNI.Models.GCNIModel obj, string hdd, string btntype, string id,string img)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/NewsImages"), pubthumbImage);
                                    upload1.SaveAs(imgURL);
                                }
                        }
                    }
                    //int res= SaveData(obj, "Insert");
                    List<Models.News> objem = new List<Models.News>();
                    objem = new Models.News().GetNewsData();
                    if (objem.Count < 3)
                    {
                        obj.objNewM.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objNewM.IsDisplayOnHome = false;
                    }

                    obj.objNewM.Description = obj.objNewM.Description.Replace("<p>", "");
                    obj.objNewM.Description = obj.objNewM.Description.Replace("</p>", "");
                    int res = NewsDAL.InserNewsDAL(obj.objNewM.Title, obj.objNewM.Description, obj.objNewM.NewsFullDetails, obj.objNewM.City, obj.objNewM.NewsDate, pubthumbImage, obj.objNewM.IsDisplayOnHome, "Insert");
                    //cmd = new SqlCommand("spNews", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Title", obj.objNewM.Title);
                    //cmd.Parameters.AddWithValue("@Description", obj.objNewM.Description);
                    //cmd.Parameters.AddWithValue("@City", obj.objNewM.City);
                    //cmd.Parameters.AddWithValue("@IsDisplayOnHome", obj.objNewM.IsDisplayOnHome);
                    //cmd.Parameters.AddWithValue("@Qtype", "Insert");
                    //con.Open();
                    //int res = cmd.ExecuteNonQuery();
                    //con.Close();

                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spNews", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/NewsImages"), pubthumbImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    List<Models.News> objem = new List<Models.News>();
                    objem = new Models.News().GetNewsData();
                    if (objem.Count < 3)
                    {
                        obj.objNewM.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objNewM.IsDisplayOnHome = false;
                    }
                    int res = NewsDAL.UpdateNewsDAL(obj.objNewM.Title, obj.objNewM.Description, obj.objNewM.NewsFullDetails, obj.objNewM.City,obj.objNewM.NewsDate, pubthumbImage!=null?pubthumbImage:img, obj.objNewM.IsDisplayOnHome, "update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objNewM = new Models.News();
                objGCNI.objNewML = new Models.News().GetNewsData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                //string msg = e.Message;
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objNewML = new Models.News().GetNewsData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        [HttpGet]
        public ActionResult ShowError(String sErrorMessage)
        {
            //All we want to do is redirect to the class selection page
            ViewBag.sErrMssg = sErrorMessage;
            return View("Error");
        }

        [HttpPost]
        public ActionResult NewsDelete(string id)
        {
            try
            {
                int res = CommanDeleteDAL.DeleteDAL("spNews", id, "delete");
                if (res > 0)
                {
                    ViewBag.Message = "Data is Successfully Deleted.....!";
                }
                return this.RedirectToAction("Admin", "NewsManagement");
                //return View("PublicationManagement");
            }
            catch
            {
                return View("PublicationManagement");
            }
        }
        #endregion

        #region Publication Conroller
        [Authorize]
        [HttpGet]
        public ActionResult PublicationManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objPublicationtML = new Models.Publication().GetPublicationData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PublicationManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype=="Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Publication_Thumbnail_Images"), pubthumbImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    pubFile = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Publication_Files"), pubFile);
                                    fileURL = fileURL.Trim();
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                    if (imgURL != null && fileURL != null)
                    {
                        List<Models.Publication> objem = new List<Models.Publication>();
                        objem = new Models.Publication().GetPublicationData();
                        if (objem.Count < 3)
                        {
                            obj.objPublicationtM.IsDisplayOnHome = true;
                        }
                        else
                        {
                            obj.objPublicationtM.IsDisplayOnHome = false;
                        }
                        int res=PublicationDAL.InserPublicationDAL(obj.objPublicationtM.Title,obj.objPublicationtM.Auther, obj.objPublicationtM.Description, pubthumbImage, pubFile, obj.objPublicationtM.IsDisplayOnHome, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spPublication", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Publication_Thumbnail_Images"), pubthumbImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    pubFile = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Publication_Files"), pubFile);
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                    List<Models.Publication> objem = new List<Models.Publication>();
                    objem = new Models.Publication().GetPublicationData();
                    if (objem.Count < 3)
                    {
                        obj.objPublicationtM.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objPublicationtM.IsDisplayOnHome = false;
                    }
                    int res = PublicationDAL.UpdatePublicationDAL(obj.objPublicationtM.Title,obj.objPublicationtM.Auther, obj.objPublicationtM.Description, pubthumbImage != null ? pubthumbImage : img, pubFile != null ? pubFile : file, obj.objPublicationtM.IsDisplayOnHome, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objPublicationtML = new Models.Publication().GetPublicationData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objPublicationtML = new Models.Publication().GetPublicationData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        //[HttpPost]
        //public ActionResult PublicationDelete(string id)
        //{
        //    try
        //    {
        //        int res = CommanDeleteDAL.DeleteDAL("spPublication", id);
        //        if(res>0)
        //        {
        //            ViewBag.Message="Data is Successfully Deleted.....!";
        //        }
        //        return this.RedirectToAction("Admin", "PublicationManagement");
        //        //return View("PublicationManagement");
        //    }
        //    catch
        //    {
        //        return View("PublicationManagement");
        //    }
        //}

        #endregion

        #region About_Us Conroller
        [Authorize]
        [HttpGet]
        public ActionResult About_UsManagement1()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_UsML = new Models.About_Us().GetAbout_UsData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult About_UsManagement1(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    if (imgURL != null)
                    {
                        //List<Models.About_Us> objem = new List<Models.About_Us>();
                        //objem = new Models.About_Us().GetAbout_UsData();
                        //if (objem.Count < 3)
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = true;
                        //}
                        //else
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = false;
                        //}
                        int res = About_UsDAL.InserAbout_UsDAL(obj.objAbout_UsM.Designation, obj.objAbout_UsM.Name, obj.objAbout_UsM.Description,obj.objAbout_UsM.AboutUS_Category, AboutUsImage, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spAboutUS", id,"delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    //List<Models.Publication> objem = new List<Models.Publication>();
                    //objem = new Models.Publication().GetPublicationData();
                    //if (objem.Count < 3)
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = true;
                    //}
                    //else
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = false;
                    //}
                    int res = About_UsDAL.UpdateAbout_UsDAL(obj.objAbout_UsM.Designation, obj.objAbout_UsM.Name, obj.objAbout_UsM.Description,obj.objAbout_UsM.AboutUS_Category, AboutUsImage!=null?AboutUsImage:img, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objAbout_UsML = new Models.About_Us().GetAbout_UsData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objAbout_UsML = new Models.About_Us().GetAbout_UsData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult About_US_JourneyOfCOE()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_Us_JCOE_ML = new Models.About_Us_JourneyOfCOE().GetAbout_Us_JCOE_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult About_US_JourneyOfCOE(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US_JCOE"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    if (imgURL != null)
                    {
                        //List<Models.About_Us> objem = new List<Models.About_Us>();
                        //objem = new Models.About_Us().GetAbout_UsData();
                        //if (objem.Count < 3)
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = true;
                        //}
                        //else
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = false;
                        //}
                        int res = About_UsDAL.InserAbout_UsJCOEDAL(obj.objAbout_Us_JCOE_M.Description1, obj.objAbout_Us_JCOE_M.Description2, AboutUsImage, "InsertJCOE");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spAboutUS", id, "deleteJCOE");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US_JCOE"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    //List<Models.Publication> objem = new List<Models.Publication>();
                    //objem = new Models.Publication().GetPublicationData();
                    //if (objem.Count < 3)
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = true;
                    //}
                    //else
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = false;
                    //}
                    int res = About_UsDAL.UpdateAbout_UsJCOEDAL(obj.objAbout_Us_JCOE_M.Description1, obj.objAbout_Us_JCOE_M.Description2,AboutUsImage != null ? AboutUsImage : img, "UpdateJCOE", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objAbout_Us_JCOE_ML = new Models.About_Us_JourneyOfCOE().GetAbout_Us_JCOE_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objAbout_Us_JCOE_ML = new Models.About_Us_JourneyOfCOE().GetAbout_Us_JCOE_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("OurPartners");
        }
        [Authorize]
        [HttpGet]
        public ActionResult About_US_RoleCOE()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objAbout_Us_RCOE_ML = new Models.About_US_RoleCOE().GetAbout_Us_RCOE_Data();
            objGCNI.objTabMenu_ML = new Models.TabMenu().GetTabMenu_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult About_US_RoleCOE(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id, string tabitem)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "NewTab")
                {
                    int res = About_UsDAL.InserTabMenu(tabitem, "addTabitem");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    string ImagePath = "";
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count-1; i++)
                        {
                            var upload1 = Request.Files[i];
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    ImagePath = ImagePath + "," + AboutUsImage;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US_RCOE"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                        }
                    }
                        int res = About_UsDAL.InserAbout_UsRCOEDAL(obj.objAbout_Us_RCOE_M.Description,obj.objAbout_Us_RCOE_M.TabType, ImagePath, "InsertRCOE");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spAboutUS", id, "deleteRCOE");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    string ImagePath = "";
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count - 1; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                ImagePath = ImagePath + "," + AboutUsImage;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/About_US_RCOE"), AboutUsImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    int res = About_UsDAL.UpdateAbout_UsRCOEDAL(obj.objAbout_Us_RCOE_M.Description,obj.objAbout_Us_RCOE_M.TabType, ImagePath != "" ? ImagePath : img, "UpdateRCOE", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objAbout_Us_RCOE_ML = new Models.About_US_RoleCOE().GetAbout_Us_RCOE_Data();
                objGCNI.objTabMenu_ML = new Models.TabMenu().GetTabMenu_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objAbout_Us_RCOE_ML = new Models.About_US_RoleCOE().GetAbout_Us_RCOE_Data();
                objGCNI.objTabMenu_ML = new Models.TabMenu().GetTabMenu_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Activities Controller
        [Authorize]
        [HttpGet]
        public ActionResult ActivitiesInitiative()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objActivitiesIni_ML = new Models.ActivitiesInitiative().GetActivityIniData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ActivitiesInitiative(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                     if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    imgURL = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Initiatives"), imgURL);
                                    upload1.SaveAs(fileURL);
                                }
                        }
                    }
                     if (imgURL != null)
                     {
                         int res = ActivitiesDAL.InserActivityDAL(imgURL,obj.objActivitiesIni_M.Title, obj.objActivitiesIni_M.Description, "Insert");
                         if (res > 0)
                         {
                             ViewBag.Message = "Data is Successfully Saved...!";
                         }
                     }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spActivities", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    imgURL = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Initiatives"), imgURL);
                                    upload1.SaveAs(fileURL);
                                }
                        }
                    }

                    int res = ActivitiesDAL.UpdateActivityDAL(imgURL != null ? imgURL : img, obj.objActivitiesIni_M.Title, obj.objActivitiesIni_M.Description, "update", hdd);
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Updated...!";
                        }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objActivitiesIni_ML = new Models.ActivitiesInitiative().GetActivityIniData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objActivitiesIni_ML = new Models.ActivitiesInitiative().GetActivityIniData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Issues Controller
        [Authorize]
        [HttpGet]
        public ActionResult ActivitiesIssues()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objIssues_ML = new Models.Issues().GetIssuesData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ActivitiesIssues(GCNI.Models.GCNIModel obj, string hdd, string MImg1, string MImg2, string MImg3, string MImg4, string file, string PDF, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                   
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner1 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner1);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner2 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner2);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 2)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner3 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner3);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 3)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner4 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner4);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i==4)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    PDFfileURL = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), PDFfileURL);
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                    
                        int res = IssuesDAL.InsertIssuesDAL(MainBanner1!=null?MainBanner1:MImg1, MainBanner2 != null ? MainBanner2 : MImg2, MainBanner3 != null ? MainBanner3 : MImg3, MainBanner4 != null ? MainBanner4 : MImg4, obj.objIssues_M.Category, obj.objIssues_M.Heading, obj.objIssues_M.Description, PDFfileURL, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spIssues", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner1 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner1);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner2 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner2);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 2)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner3 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner3);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 3)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    MainBanner4 = Guid.NewGuid().ToString() + fileName;
                                    MainBannerURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), MainBanner4);
                                    upload1.SaveAs(MainBannerURL);
                                }
                            }
                            else if (i == 4)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    PDFfileURL = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Activities/Issues"), PDFfileURL);
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                    int res = IssuesDAL.UpdateIssuesDAL(MainBanner1 != null ? MainBanner1 : MImg1, MainBanner2 != null ? MainBanner2 : MImg2, MainBanner3 != null ? MainBanner3 : MImg3, MainBanner4 != null ? MainBanner4 : MImg4, obj.objIssues_M.Category, obj.objIssues_M.Heading, obj.objIssues_M.Description, PDFfileURL!=null?PDFfileURL:PDF, "update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objIssues_ML = new Models.Issues().GetIssuesData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objIssues_ML = new Models.Issues().GetIssuesData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Resources Controller
        [Authorize]
        [HttpGet]
        public ActionResult ResourcesCOE()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesCOE_ML = new Models.ResourcesCOE().GetResourcesCOEData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ResourcesCOE(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                     if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceCOE"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }
                                
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    pubFile = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceCOE"), pubFile);
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                     if (imgURL != null && fileURL != null)
                     {
                         int res = ResourcesDAL.InserResoucesCOEDAL(AboutUsImage,obj.objResourcesCOE_M.Title, obj.objResourcesCOE_M.Author, pubFile, "Insert");
                         if (res > 0)
                         {
                             ViewBag.Message = "Data is Successfully Saved...!";
                         }
                     }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spResources", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceCOE"), AboutUsImage);
                                    upload1.SaveAs(imgURL);
                                }

                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    pubFile = Guid.NewGuid().ToString() + fileName;
                                    fileURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceCOE"), pubFile);
                                    upload1.SaveAs(fileURL);
                                }
                            }
                        }
                    }
                   
                    int res = ResourcesDAL.UpdateResoucesCOEDAL(AboutUsImage!=null?AboutUsImage:img,obj.objResourcesCOE_M.Title, obj.objResourcesCOE_M.Author, pubFile!=null?pubFile:file, "update", hdd);
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Updated...!";
                        }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objResourcesCOE_ML = new Models.ResourcesCOE().GetResourcesCOEData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objResourcesCOE_ML = new Models.ResourcesCOE().GetResourcesCOEData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ResourcesWebinars()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebDataAll();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ResourcesWebinars(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                //    if (Request.Files.Count > 0)
                //    {
                //        for (int i = 0; i < Request.Files.Count; i++)
                //        {
                //            var upload1 = Request.Files[i];
                //            if (upload1 != null && upload1.ContentLength > 0)
                //            {
                //                var fileName = Path.GetFileName(upload1.FileName);
                //                pubFile = Guid.NewGuid().ToString() + fileName;
                //                fileURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceWebinars"), pubFile);
                //                upload1.SaveAs(fileURL);
                //            }
                //        }
                //    }
                //    if (fileURL != null)
                //    {
                        int res = ResourcesDAL.InserResoucesWebDAL(obj.objResourcesWebinars_M.TradeTitle, obj.objResourcesWebinars_M.TradeDate, obj.objResourcesWebinars_M.Time, obj.objResourcesWebinars_M.Description,obj.objResourcesWebinars_M.VideoLink, "InsertRW");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                   // }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spResources", id, "deleteRW");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    //if (Request.Files.Count > 0)
                    //{
                    //    for (int i = 0; i < Request.Files.Count; i++)
                    //    {
                    //        var upload1 = Request.Files[i];
                    //        if (upload1 != null && upload1.ContentLength > 0)
                    //        {
                    //            var fileName = Path.GetFileName(upload1.FileName);
                    //            pubFile = Guid.NewGuid().ToString() + fileName;
                    //            fileURL = Path.Combine(Server.MapPath("~/Uploads/Resources/ResourceWebinars"), pubFile);
                    //            upload1.SaveAs(fileURL);
                    //        }
                    //    }
                    //}
                    int res = ResourcesDAL.UpdateResoucesWebDAL(obj.objResourcesWebinars_M.TradeTitle, obj.objResourcesWebinars_M.TradeDate, obj.objResourcesWebinars_M.Time, obj.objResourcesWebinars_M.Description,obj.objResourcesWebinars_M.VideoLink, "updateRW", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebDataAll();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesWebDataAll();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        public ActionResult WebinarRegistrations()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objRegistration_ML = new Models.Registration().GetRegistrationData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WebinarRegistrations(GCNI.Models.GCNIModel obj, string hdd, string btntype, string id)
        {
            try
            {
                if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spRegistration", id, "DeleteRegistration");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                        ViewBag.Message = "Data is Successfully Updated...!";
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objRegistration_ML = new Models.Registration().GetRegistrationData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objRegistration_ML = new Models.Registration().GetRegistrationData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ResourcesDiscussion()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesDiscussionDataL();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ResourcesDiscussion(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    int res = ResourcesDAL.InserResoucesDisDAL(obj.objResourcesWebinars_M.Description, obj.objResourcesWebinars_M.TradeDate, obj.objResourcesWebinars_M.Time, "InsertRD");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spResources", id, "deleteRD");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    int res = ResourcesDAL.UpdateResoucesDisDAL(obj.objResourcesWebinars_M.Description, obj.objResourcesWebinars_M.TradeDate, obj.objResourcesWebinars_M.Time, "updateRD", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesDiscussionDataL();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objResourcesWebinars_ML = new Models.ResourcesWebinars().GetoResourcesDiscussionDataL();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        [Authorize]
        [HttpGet]
        public ActionResult GCNIManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GCNIManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {

                    int res = GovCounAndSec.InserGovCounAndSecDAL(obj.objGovCounAndSec_M.Cat, obj.objGovCounAndSec_M.Link, obj.objGovCounAndSec_M.Description, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spGovCouncilAndSecret", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    int res = GovCounAndSec.UpdateGovCounAndSecDAL(obj.objGovCounAndSec_M.Cat, obj.objGovCounAndSec_M.Link, obj.objGovCounAndSec_M.Description, "update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGovCounAndSec_ML = new Models.GovCouncilingANDSecretariat().GetGovConANDSecData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }


        #region OurPartner
        [Authorize]
        [HttpGet]
        public ActionResult OurPartners()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objOurPartners_ML = new Models.OurPartners().GetOurPartners_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult OurPartners(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    string ImagePath = "";
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count - 1; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                ImagePath = ImagePath + "," + AboutUsImage;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/OurPartners"), AboutUsImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    if (imgURL != null)
                    {
                        //List<Models.About_Us> objem = new List<Models.About_Us>();
                        //objem = new Models.About_Us().GetAbout_UsData();
                        //if (objem.Count < 3)
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = true;
                        //}
                        //else
                        //{
                        //    obj.objPublicationtM.IsDisplayOnHome = false;
                        //}
                        int res = OurPartnerDAL.InserOurPartnersDAL(obj.objOurPartners_M.Title, ImagePath, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spOurPartners", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    string ImagePath = "";
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count - 1; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                AboutUsImage = Guid.NewGuid().ToString() + fileName;
                                ImagePath = ImagePath + "," + AboutUsImage;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/OurPartners"), AboutUsImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    //List<Models.Publication> objem = new List<Models.Publication>();
                    //objem = new Models.Publication().GetPublicationData();
                    //if (objem.Count < 3)
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = true;
                    //}
                    //else
                    //{
                    //    obj.objPublicationtM.IsDisplayOnHome = false;
                    //}
                    int res = OurPartnerDAL.UpdateOurPartnersDAL(obj.objOurPartners_M.Title, ImagePath != "" ? ImagePath : img, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objOurPartners_ML = new Models.OurPartners().GetOurPartners_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objOurPartners_ML = new Models.OurPartners().GetOurPartners_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Training
        [Authorize]
        [HttpGet]
        public ActionResult Training()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objTraining_ML = new Models.Training().GetTraining_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Training(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                        int res = TrainingDAL.InserspTrainingDAL(obj.objTraining_M.Title, obj.objTraining_M.Description, "Insert");
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Saved...!";
                        }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spTraining", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    int res = TrainingDAL.UpdatespTrainingDAL(obj.objTraining_M.Title, obj.objTraining_M.Description, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objTraining_ML = new Models.Training().GetTraining_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objTraining_ML = new Models.Training().GetTraining_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Knowledge
        [Authorize]
        [HttpGet]
        public ActionResult KnowledgeManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult KnowledgeManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    fileURL = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Knowledge"), fileURL);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    int res = KnowledgeDAL.InsertKnowledgeDAL(obj.objKnowledge_M.Title, obj.objKnowledge_M.Description,obj.objKnowledge_M.BillLinkUrl, fileURL, obj.objKnowledge_M.CountryCat, obj.objKnowledge_M.TabCat, obj.objKnowledge_M.Status, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spKnowledge", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    fileURL = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Knowledge"), fileURL);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    int res = KnowledgeDAL.UpdateKnowledgeDAL(obj.objKnowledge_M.Title, obj.objKnowledge_M.Description,obj.objKnowledge_M.BillLinkUrl, fileURL!=null?fileURL:file, obj.objKnowledge_M.CountryCat, obj.objKnowledge_M.TabCat, obj.objKnowledge_M.Status, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objKnowledge_ML = new Models.Knowledge().GetKnowledge_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region FAQs
        [Authorize]
        [HttpGet]
        public ActionResult FAQsManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objFAQS_ML = new Models.FAQS().GetFAQS_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FAQsManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    int res = FAQsDAL.InsertFAQsDAL(obj.objFAQS_M.Ques,obj.objFAQS_M.Head, obj.objFAQS_M.Description, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spFAQs", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    int res = FAQsDAL.UpdateFAQsDAL(obj.objFAQS_M.Ques, obj.objFAQS_M.Head, obj.objFAQS_M.Description, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objFAQS_ML = new Models.FAQS().GetFAQS_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objFAQS_ML = new Models.FAQS().GetFAQS_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Careers Controller
        [Authorize]
        [HttpGet]
        public ActionResult CareersManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objCarrers_ML = new Models.Carrers().GetCarrers_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CareersManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    int res = CarrersDAL.InsertCarrersDAL(obj.objCarrers_M.Heading,obj.objCarrers_M.SubHead,obj.objCarrers_M.JobTitle,obj.objCarrers_M.Duration,obj.objCarrers_M.JobDescription,obj.objCarrers_M.ApplyEmail,obj.objCarrers_M.LastHead,obj.objCarrers_M.LinkEmail,obj.objCarrers_M.Category,"Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spCarrers", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    int res = CarrersDAL.UpdateCarrersDAL(obj.objCarrers_M.Heading, obj.objCarrers_M.SubHead, obj.objCarrers_M.JobTitle, obj.objCarrers_M.Duration, obj.objCarrers_M.JobDescription, obj.objCarrers_M.ApplyEmail, obj.objCarrers_M.LastHead, obj.objCarrers_M.LinkEmail, obj.objCarrers_M.Category, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objCarrers_ML = new Models.Carrers().GetCarrers_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objCarrers_ML = new Models.Carrers().GetCarrers_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region OpinionPoll Controller
        [Authorize]
        [HttpGet]
        public ActionResult OpinionPollManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult OpinionPollManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    List<Models.OpinionPoll> objem = new List<Models.OpinionPoll>();
                    objem = new Models.OpinionPoll().GetOpinionPoll_Data();
                    if (objem.Count < 3)
                    {
                        obj.objOpinionPoll_M.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objOpinionPoll_M.IsDisplayOnHome = false;
                    }
                    int res = OpinionPollDAL.InsertOpinionPollDAL(obj.objOpinionPoll_M.Question,obj.objOpinionPoll_M.IsDisplayOnHome, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spOpinionPoll", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    List<Models.OpinionPoll> objem = new List<Models.OpinionPoll>();
                    objem = new Models.OpinionPoll().GetOpinionPoll_Data();
                    if (objem.Count < 3)
                    {
                        obj.objOpinionPoll_M.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objOpinionPoll_M.IsDisplayOnHome = false;
                    }
                    int res = OpinionPollDAL.UpdateOpinionPollDAL(obj.objOpinionPoll_M.Question,obj.objOpinionPoll_M.IsDisplayOnHome, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objOpinionPoll_ML = new Models.OpinionPoll().GetOpinionPoll_Data2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Blog Controller
        [Authorize]
        [HttpGet]
        public ActionResult BlogManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objBlog_ML = new Models.Blog().GetBlogData2();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    List<Models.Blog> objem = new List<Models.Blog>();
                    objem = new Models.Blog().GetBlogData();
                    if (objem.Count < 2)
                    {
                        obj.objBlog_M.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objBlog_M.IsDisplayOnHome = false;
                    }
                    int res = BlogDAL.InsertBlogDAL(obj.objBlog_M.Title, obj.objBlog_M.Description, obj.objBlog_M.IsDisplayOnHome, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spBlog", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    List<Models.Blog> objem = new List<Models.Blog>();
                    objem = new Models.Blog().GetBlogData();
                    if (objem.Count < 2)
                    {
                        obj.objBlog_M.IsDisplayOnHome = true;
                    }
                    else
                    {
                        obj.objBlog_M.IsDisplayOnHome = false;
                    }
                    int res = BlogDAL.UpdateBlogDAL(obj.objBlog_M.Title, obj.objBlog_M.Description, obj.objBlog_M.IsDisplayOnHome, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objBlog_ML = new Models.Blog().GetBlogData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                //objGCNI.objPublicationtM = new Models.Publication();
                objGCNI.objBlog_ML = new Models.Blog().GetBlogData2();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region GetInvolved Controller
        [Authorize]
        [HttpGet]
        public ActionResult GetInvolvedManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
            objGCNI.objGetInvolvedFeedback_ML = new Models.GetInvoleved_Feedback().GetInvoleved_FeedbackData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GetInvolvedManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/GetInvolved"), pubthumbImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    int res = GetInvolvedDAL.InsertGetInvolvedDAL(obj.objGetInvolved_M.Catagory, obj.objGetInvolved_M.ImageTitle, pubthumbImage,obj.objGetInvolved_M.Question, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spGetInvolved", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                pubthumbImage = Guid.NewGuid().ToString() + fileName;
                                imgURL = Path.Combine(Server.MapPath("~/Uploads/GetInvolved"), pubthumbImage);
                                upload1.SaveAs(imgURL);
                            }
                        }
                    }
                    int res = GetInvolvedDAL.UpdateGetInvolvedDAL(obj.objGetInvolved_M.Catagory, obj.objGetInvolved_M.ImageTitle, pubthumbImage!=null?pubthumbImage:img, obj.objGetInvolved_M.Question, "Update", hdd);
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Updated...!";
                    }

                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolved_ML = new Models.GetInvolved().GetInvolved_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetInvolvedFeedbackManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            objGCNI.objGetInvolvedFeedback_ML = new Models.GetInvoleved_Feedback().GetInvoleved_FeedbackData();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GetInvolvedFeedbackManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if (btntype == "Save")
                {
                    cmd = new SqlCommand("spGetInvolved", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeedBack",obj.objGetInvolvedFeedback_M.Feedback);
                    cmd.Parameters.AddWithValue("@Commint", obj.objGetInvolvedFeedback_M.Commint);
                    cmd.Parameters.AddWithValue("@ID", hdd);
                    cmd.Parameters.AddWithValue("@Qtype", "Updatefeedback");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    con.Close();
                    if (res > 0)
                    {
                        ViewBag.Message = "Comment is Successfully Inserted...!";
                    }
                }
                else if (btntype == "Delete")
                {
                    int res = CommanDeleteDAL.DeleteDAL("spGetInvolved", id, "deletefeedback");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolvedFeedback_ML = new Models.GetInvoleved_Feedback().GetInvoleved_FeedbackData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objGetInvolvedFeedback_ML = new Models.GetInvoleved_Feedback().GetInvoleved_FeedbackData();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region MediaManagement Controller
        [Authorize]
        [HttpGet]
        public ActionResult MediaManagement()
        {
            GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
            //objGCNI.objPublicationtM = new Models.Publication();
            objGCNI.objMedia_ML = new Models.Media().GetMedia_Data();
            objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
            return View(objGCNI);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MediaManagement(GCNI.Models.GCNIModel obj, string hdd, string img, string file, string btntype, string id)
        {
            try
            {
                if ((hdd == "0" || hdd == null) && btntype == "Save")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    fileName = fileName.Replace(" ", "_");
                                    fileURL = Guid.NewGuid().ToString() + fileName;
                                    imgURL = Path.Combine(Server.MapPath("~/Uploads/Media"), fileURL);
                                    upload1.SaveAs(imgURL);
                                }
                            }
                        }
                    }
                    int res = MediaDAL.InsertMediaDAL(obj.objMedia_M.Heading, obj.objMedia_M.Description, fileURL, "Insert");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Saved...!";
                    }
                }
                else if (((hdd == "0" || hdd == null) && btntype == "Delete") || ((hdd != "0" || hdd != null) && btntype == "Delete"))
                {
                    int res = CommanDeleteDAL.DeleteDAL("spMedia", id, "delete");
                    if (res > 0)
                    {
                        ViewBag.Message = "Data is Successfully Deleted.....!";
                    }
                }
                else
                {
                        if (Request.Files.Count > 0)
                        {
                            for (int i = 0; i < Request.Files.Count; i++)
                            {
                                var upload1 = Request.Files[i];
                                if (i == 0)
                                {
                                    if (upload1 != null && upload1.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(upload1.FileName);
                                        fileName = fileName.Replace(" ", "_");
                                        fileURL = Guid.NewGuid().ToString() + fileName;
                                        imgURL = Path.Combine(Server.MapPath("~/Uploads/Media"), fileURL);
                                        upload1.SaveAs(imgURL);
                                    }
                                }
                            }
                        }
                        int res = MediaDAL.UpdateMediaDAL(obj.objMedia_M.Heading, obj.objMedia_M.Description, fileURL != null ? fileURL : file, "Update", hdd);
                        if (res > 0)
                        {
                            ViewBag.Message = "Data is Successfully Updated...!";
                        }

                    }
                    GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                    objGCNI.objMedia_ML = new Models.Media().GetMedia_Data();
                    objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                    return View(objGCNI);
               
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                GCNI.Models.GCNIModel objGCNI = new Models.GCNIModel();
                objGCNI.objMedia_ML = new Models.Media().GetMedia_Data();
                objGCNI.objHomeMaster = new Models.HomeMaster().GetHomeMaster_Data();
                return View(objGCNI);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        









































    }
}
