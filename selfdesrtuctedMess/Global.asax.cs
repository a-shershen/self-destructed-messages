using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace selfdestructedMess
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(selfdestructedMess.Models.Message), new selfdestructedMess.Models.ModelBinder());

            StartRemoveTimer();
        }

        private void StartRemoveTimer()
        {
            BLL.MessageService mesServ = new BLL.MessageService();

            mesServ.RemoverTimer();
        }
    }
}
