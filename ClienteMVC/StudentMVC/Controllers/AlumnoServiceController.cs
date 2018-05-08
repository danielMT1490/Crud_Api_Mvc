using StudentService.ServiceLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMVC.Controllers
{
    public class AlumnoServiceController : Controller
    {
        private readonly IService apiservice;

        public AlumnoServiceController(IService api)
        {
            this.apiservice = api;
        }
        // GET: AlumnoService
        public ActionResult Index()
        {
            return View();
        }
    }
}