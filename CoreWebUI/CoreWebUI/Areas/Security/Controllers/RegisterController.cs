using BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Security.Controllers
{
    [AllowAnonymous]

    public class RegisterController : BaseSecurityController
    {
        private static string randomCodeToLogin = null;
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            TempData["info"] = "Please verfy your account to Register: "+user.UserEmail;


            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(user.UserEmail);
            mail.From = new MailAddress("webcore.comp313@gmail.com", "Sent From WebCore", System.Text.Encoding.UTF8);
            mail.Subject = "Your Verfication Code";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            randomCodeToLogin = GetRandomString();
            Session["verifyCode"] = randomCodeToLogin;
            Session["user"] = user;
            mail.Body = "Your verfification code is:" + randomCodeToLogin;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("webcore.comp313@gmail.com", "Comp313w2019");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                return RedirectToAction("Index","Verify");

            }
            catch (Exception ex2)
            {
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;

                }
                return RedirectToAction("Index");

            }


            //two factor authenacsinfo


            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        user.Role = "U";





            //        objBs.userBs.Insert(user);

            //        TempData["Msg"] = "Created Successfully";
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return View("Index");
            //    }
            //}
            //catch(Exception e1)
            //{
            //    TempData["Msg"] = "Register Filed:" + e1.Message;
            //    return RedirectToAction("Index");
            //}
        }



        

    }
}