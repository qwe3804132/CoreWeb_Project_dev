using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Common.Controllers
{
    [AllowAnonymous]

    public class BrowseURLController : BaseCommonController
    {
        // GET: Common/BrowseURL
        public ActionResult Index(string sortOrder,string sortBy,string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy; 
            var urls = objBs.urlBs.GetAll().Where(x=>x.IsApproved=="A");  //the filter for only approved url will show up here

            switch (sortOrder)
            {
                case "ASC":
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
                case "DESC":
                    urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                    break;
                default:
                    break;

                    
            }
            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page; 
            urls = urls.Skip((page - 1) * 10).Take(10);//logic for showing pagely
            return View(urls);
        }

        public ActionResult updateClickCount(int urlId)
        {
            //try
           // {
                tbl_Url myUrl = objBs.urlBs.GetByID(urlId); 
            //TempData["Msg"] = myUrl;
                 myUrl.ClickCount = myUrl.ClickCount+1;
                objBs.urlBs.Update(myUrl);
            string retailerWebsite = myUrl.Url;
                return Redirect(retailerWebsite);
           // }
           // catch (Exception e1)
           // {
               // TempData["Msg"] = "Approval Filed:" + e1.Message;
               // return RedirectToAction("Index");
           // }
        }

    }
}