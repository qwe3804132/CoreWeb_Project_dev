﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        // GET: Security/BaseSecurity
        protected SecurityBs objBs;
        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}