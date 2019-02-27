using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {
        private CommonBs objBs;
        public BrowseURLController()
        {
            objBs = new CommonBs();
        }
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
    }
}