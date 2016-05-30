using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeuroNet.Web.Models;

namespace NeuroNet.Web.Controllers
{
    public class HomeController : Controller
    {
        public static bool LoadingIntiated = false;

        public HomeController()
        {
            if (!LoadingIntiated)
            {
                NeuronetCollection.Load();
                LoadingIntiated = true;
            }
        }

        public ActionResult Browse()
        {
            if (NeuronetCollection.IsLoading)
                ViewBag.LoadMessage = "Neural networks are loading";

            return View(NeuronetCollection.Neuronets);
        }

        public ActionResult Recognize(Guid neuronetGuid)
        {
            var neuronetWithInfo = NeuronetCollection.Neuronets[neuronetGuid];
            
            ViewBag.Information = neuronetWithInfo.ToString();

            return View(neuronetWithInfo);
        }

        [HttpPost]
        public ActionResult Recognize()
        {
            var neuronetGuid = Guid.Parse(Request.QueryString["neuronetGuid"]);

            var vector = Request.Form["intensityField"]
                .Split(new[] {','})
                .Select(s => s.Where(c => char.IsDigit(c) || c == '.'))
                .Select(ac => new string(ac.ToArray()))
                .Select(double.Parse).ToArray();

            NeuronetCollection.Neuronets[neuronetGuid].Neuronet.SetInput(vector);

            return Json(NeuronetCollection.Neuronets[neuronetGuid].Neuronet.GetAnswer());
        }
    }
}
