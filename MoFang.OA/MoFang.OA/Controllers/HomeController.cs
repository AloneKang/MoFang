using MoFang.OA.Entitys;
using MoFang.OA.IRepository;
using MoFang.OA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoFang.OA.Controllers
{
    public class HomeController : Controller
    {
        private IUser_ListRepository _UserList; 
        public HomeController(IUser_ListRepository UserList)
        {
            this._UserList = UserList;
        }
        public ActionResult Index()
        {
            List<User_List> UList = _UserList.Query().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}