using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreWebUI.Areas.Admin.Controllers
{
    public class ListUserController : BaseAdminController
    {




        // GET: Admin/ListUser
        public ActionResult Index(string sortOrder,string sortBy,string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var users = objBs.userBs.GetAll();
           
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    

               
               


            
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 5.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            users = users.Skip((page - 1) * 10).Take(10);//logic for showing pagely
            return View(users);
        }
    }
}