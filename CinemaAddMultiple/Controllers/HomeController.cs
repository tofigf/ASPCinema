using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaAddMultiple.Models;

namespace CinemaAddMultiple.Controllers
{
    public class HomeController : Controller
    {
        kinoEntities db = new kinoEntities();
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            ViewBag.Countries = db.Countries.ToList();
            ViewBag.Genres = db.Genres.ToList();
            if (StartDate != null && EndDate != null)
            {
                ViewBag.Films = db.Films.Where(f => f.YayimTarixi >= StartDate && f.YayimTarixi < EndDate).ToList();
            }
            else
            {
                ViewBag.Films = db.Films.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(Film film, int [] Contr,int[] Gen)
        {
            if (film.Name == null || film.YayimTarixi == null || film.Duration == null)
            {
                return RedirectToAction("index", "home");
            }
            db.Films.Add(film);
            db.SaveChanges();
            foreach (int item in Contr)
            {
                FilmCountry filmCon = new FilmCountry()
                {
                    FilmId =film.Id,
                    CountryId =item
                };
                db.FilmCountries.Add(filmCon);
                db.SaveChanges();
            }
            foreach (int item in Gen)
            {
                FillmGenre filmGenre = new FillmGenre()
                {
                    FilmId =film.Id,
                    GenreId =item
                };
                db.FillmGenres.Add(filmGenre);
                db.SaveChanges();
            }

            return RedirectToAction("index", "home");
           
        }

        public ActionResult More (int id)
        {
            Film film = db.Films.Find(id);
            if(film == null)
            {
                return View("~/Views/Error/Erro404.cshtml");
            }
            return View(film);
        }

        public ActionResult Search(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate != null && EndDate != null)
            {
                ViewBag.Films = db.Films.Where(f => f.YayimTarixi >= StartDate && f.YayimTarixi < EndDate).ToList();
            }
            else
            {
                ViewBag.Films = db.Films.ToList();
            }

            return View();
        }












        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }
    }
}