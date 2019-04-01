using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BOL;
using CoreWebUI.Utilities;
using PayPal.Api;


namespace CoreWebUI.Areas.User.Controllers
{
    public class MylinkController : BaseUserController
    {
        [Authorize(Roles = "U")]

        // GET: User/Mylink
        public ActionResult Index()
        {
            string un = User.Identity.Name;

            //int currentUserId = Convert.ToInt32(Membership.GetUser().ProviderUserKey);

            //int UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            //int userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            //var id = HttpContext.
            var users = objBs.userBs.GetAll().Where(x => x.UserEmail == un).ToList().First();

            var urls = objBs.urlBs.GetAll().Where(x => x.UserId == users.UserId).ToList();
            return View(urls);
        }
        public ActionResult Pay(int id)
        {
            tbl_Url myUrl = objBs.urlBs.GetByID(id);
            Session["url"] = myUrl.UrlId;
            return RedirectToAction("Index","PaymentSelection");



        }





    }
}