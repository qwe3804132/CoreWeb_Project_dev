using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Common.Controllers
{
    [AllowAnonymous]

    public class HomeController : BaseCommonController
    {
        // GET: Common/Home
        public ActionResult Index()
        {

            var urls = objBs.urlBs.GetAll().Where(x => x.Payment == "Gold").ToList();
            return View(urls);
        }
    }
}