using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VidlyAppy.Controllers
{
    [AllowAnonymous]
    public class RentalController : Controller
    {
        //Get new form to rent movies
        public ActionResult NewForm()
        {
            return View();
        }
    }
}