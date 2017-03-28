using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using RichardMCano.Website.Models.Home;

namespace RichardMCano.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;

        public HomeController()
        {
            _connectionString = Settings.GetConnectionString();
        }

        public ActionResult Index()
        {
            try
            {
                var viewModel = new HomeViewModel();

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}