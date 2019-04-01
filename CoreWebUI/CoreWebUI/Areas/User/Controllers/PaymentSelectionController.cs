using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.User.Controllers
{
    public class PaymentSelectionController : BaseUserController
    {
        // GET: User/PaymentSelection
        public ActionResult Index()
        {
            return View();
        }
    }
}