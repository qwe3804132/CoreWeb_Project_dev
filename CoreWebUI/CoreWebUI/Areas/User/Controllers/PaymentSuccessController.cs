using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.User.Controllers
{
    public class PaymentSuccessController : BaseUserController
    {
        // GET: User/PaymentSuccess
        public ActionResult Index()
        {
            int urlId = Convert.ToInt32( Session["url"].ToString());
         tbl_Url url = objBs.urlBs.GetByID(urlId);
            url.Payment = "Gold";
            objBs.urlBs.Update(url);


            return View();
        }
    }
}