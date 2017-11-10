using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace selfdestructedMess.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View();   
        }

        [HttpGet]
        public ActionResult ReadMessage(string link)
        {
            //Create BLL instance           
            BLL.MessageService mesServ = new BLL.MessageService();

            //Check for user agent
            if(mesServ.IsItMessengerUserAgent(Request.UserAgent))
            {
                return View("Index");
            }

            try
            {
                //Read message by hash link with password
                ViewBag.Message = mesServ.ReadMessage(link,
                    System.Web.Configuration.WebConfigurationManager.AppSettings["password"]);
                return View("ReadMessage");
            }

            catch
            {
                return View("ErrorPAge");
            }
        }
                
        //Write Message
        [HttpPost]
        public ActionResult WriteMessage(Models.Message message)
        {

            //Validation
            if (TryValidateModel(message))
            {
                try
                {
                    //Create BLL instance
                    BLL.MessageService mesServ = new BLL.MessageService();

                    //Add message and return its hash link
                    string hashLink = mesServ.AddNewMessage(
                        message.Text,
                        message.TimesToShow,
                        DateTime.Now.AddMinutes(message.Minutes),
                         System.Web.Configuration.WebConfigurationManager.AppSettings["password"]);                    

                    //Debug LOCALHOST with port link
#if DEBUG
                    ViewBag.Link = Request.Url.Host + ":" + Request.Url.Port + "/" + hashLink;

                    //Release link version
#else
                    ViewBag.Link = Request.Url.Host + "/" + hashLink;
#endif
                    return View();
                }
                catch(Exception ex)
                {

                    ViewBag.Error = ex.InnerException.InnerException.Message != null ?
                        ex.InnerException.InnerException.Message
                        : "Ошибка";
                    return View("ErrorPage");
                }
            }
            else
            {
                return View("Index", message);
            }
        }

        //Page Not Found View
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}