using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.User.Controllers
{
    public class URLController : BaseUserController
    {
        [Authorize(Roles = "A,U")]

        // GET: User/URL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
            return View();
        }
         
        public ActionResult Create(tbl_Url myUrl)
        {
            try
            {
                myUrl.IsApproved = "P";
                myUrl.UserId = objBs.userBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if (ModelState.IsValid)
                {
                    objBs.urlBs.Insert(myUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
                    return View("Index");

                }
            }
            catch(Exception e1)
            {
                TempData["Msg"] = "Create Failed:" + e1.Message;
                return RedirectToAction("Index");
            }
            //CoreWebDbEntities db = new CoreWebDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");
        }
    }
}