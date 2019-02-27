using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.User.Controllers
{
    public class BaseUserController : Controller
    {
        public UserAreaBs objBs;
        //private UserAreaBs objCatBs;
        //private UserAreaBs objUserBs;
        public BaseUserController()
        {
            objBs = new UserAreaBs();
            //objCatBs = new UserAreaBs();
            // objUserBs = new UserAreaBs();
        }

    }
}