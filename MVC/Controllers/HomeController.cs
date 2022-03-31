using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ReturnIfNotLoggedIn();
        }

        //---- GET ----
        public ActionResult ShowKupacData(int id)
        {
            ViewBag.id = id;
            ViewBag.kupci = Repo.GetKupci();
            ViewBag.racuni = Repo.GetRacuni(id);

            return View();
        }
        public ActionResult ShowRacunDetails(int id)
        {
            ViewBag.racunID = id.ToString();
            Session["currentkupac"] = id;
            return View(Repo.GetStavkeVM(id));
        }
        public ActionResult ShowProizvodDetails(int id)
        {
            return View(Repo.GetProizvod(id));
        }
        public ActionResult ShowKategorijaDetails(int id)
        {
            return View(Repo.GetKategorija(id));
        }
        public ActionResult ShowPotkategorijaDetails(int id)
        {
            return View(Repo.GetPotkategorija(id));
        }


        //---- UPDATE ----
        [HttpGet]
        public ActionResult EditProizvod(int id)
        {
            return View(Repo.GetProizvod(id));
        }
        [HttpPost]
        public ActionResult EditProizvod(Proizvod p)
        {
            Repo.UpdateProizvod(p);
            return RedirectToAction(actionName: "ShowProizvodDetails", routeValues: new { id = p.IDProizvod });
        }
        [HttpGet]
        public ActionResult EditPotkategorija(int id)
        {
            return View(Repo.GetPotkategorija(id));
        }
        [HttpPost]
        public ActionResult EditPotkategorija(Potkategorija p)
        {
            Repo.UpdatePotkategorija(p);
            return RedirectToAction(actionName: "ShowPotkategorijaDetails", routeValues: new { id = p.IDPotkategorija });
        }
        [HttpGet]
        public ActionResult EditKategorija(int id)
        {
            return View(Repo.GetKategorija(id));
        }
        [HttpPost]
        public ActionResult EditKategorija(Kategorija k)
        {
            Repo.UpdateKategorija(k);
            return RedirectToAction(actionName: "ShowKategorijaDetails", routeValues: new { id = k.IDKategorija });
        }


        //---- INSERT ----
        [HttpGet]
        public ActionResult CreateProizvod()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProizvod(Proizvod p)
        {
            Repo.InsertProizvod(p);
            return View("Success", model: "Proizvod je uspješno dodan u bazu");
        }

        [HttpGet]
        public ActionResult CreatePotkategorija()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePotkategorija(Potkategorija p)
        {
            Repo.InsertPotkategorija(p);
            return View("Success", model: "Potkategorija je uspješno dodana u bazu");
        }

        [HttpGet]
        public ActionResult CreateKategorija()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateKategorija(Kategorija k)
        {
            Repo.InsertKategorija(k);
            return View("Success", model: "Kategorija je uspješno dodana u bazu");
        }


        //---- DELETE ----
        public ActionResult DeleteProizvod(int id)
        {
            Repo.DeleteProizvod(id);
            return View("Success", model: "Proizvod je uspješno obrisan");
        }
        public ActionResult DeleteKategorija(int id)
        {
            Repo.DeleteKategorija(id);
            return View("Success", model: "Kategorija je uspješno obrisana");
        }
        public ActionResult DeletePotkategorija(int id)
        {
            Repo.DeletePotkategorija(id);
            return View("Success", model: "Potkategorija je uspješno obrisana");
        }



        //---- CHILD ACTIONS ONLY ----
        public ActionResult GetKomercijalistName(int id)
        {
            return Content(Repo.GetKomercijalist(id).ToString());
        }
        public ActionResult GetKreditnaKarticaType(int id)
        {
            return Content(Repo.GetKreditnaKartica(id).Tip);
        }
        public ActionResult GetProizvodName(int id)
        {
            return Content(Repo.GetProizvod(id).Naziv);
        }
        public ActionResult GetPotkategorijaName(int id)
        {
            return Content(Repo.GetPotkategorija(id).Naziv);
        }

        //---- OTHER ----
        public ActionResult Error(string errorTitle, string errorMessage)
        {
            ViewBag.errorTitle = errorTitle;
            ViewBag.errorMessage = errorMessage;
            return View();
        }
        public ActionResult Logout()
        {
            Response.Cookies[Constants.loggedIn].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Constants.HomePage);
            return View();
        }
        public ActionResult RedirectToHome()
        {
            Response.Redirect(Constants.HomePage);
            return View();
        }
        public void ReturnIfNotLoggedIn()
        {
            if (Request.Cookies[Constants.loggedIn] == null || Request.Cookies[Constants.loggedIn].Value != Constants.yes)
            {
                Response.Redirect(Constants.HomePage);
            }
        }


    }
}