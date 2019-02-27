using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        // GET: Common/BaseCommon
        protected CommonBs objBs;
        public BaseCommonController()
        {
            objBs = new CommonBs();
        }
    }
}