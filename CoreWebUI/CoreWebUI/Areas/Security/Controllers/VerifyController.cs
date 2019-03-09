using BOL;
using CoreWebUI.Areas.Security.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CoreWebUI.Areas.Security.Controllers
{
    [AllowAnonymous]

    public class VerifyController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        private HttpContextBase Context { get; set; }



        [HttpPost]
        public ActionResult Verify(tbl_User user)
        {
            tbl_User user1 = (tbl_User)Session["user"];

            if (user.VerifyCode != Convert.ToString(Session["verifyCode"]))
            {
                TempData["Msg"] = "Invalid Verification Code";

                return RedirectToAction("Index", "Verify");
            }
            else
            {
                try
                {
                   
                        user1.Role = "U";

                        objBs.userBs.Insert(user1);

                        TempData["Msg"] = "Verify Successfully";

                   return RedirectToAction("Index");


                }
                catch (Exception e1)
                {
                    TempData["Msg"] = "Register Filed:" + e1.Message;
                    return RedirectToAction("Index");
                }
            }
        }
    }
}