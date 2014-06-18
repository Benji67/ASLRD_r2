using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASLRD_r2.DataBaseAccess;

namespace ASLRD_r2.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseASLRDEntities db = new DataBaseASLRDEntities();
        public const string CartSessionKey = "CartId";
        int UserCartId;

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HandleError(View = "ErrorAdresse")]
        public ActionResult Adresse()
        {
            ViewBag.Message = "Adresse message.";
            return View();
        }

        [HandleError(View = "ErrorAdresse")]
        public ActionResult Restaurant()
        {
            ViewBag.Message = "Restaurant message.";
            return View();
        }

        [HandleError(View = "ErrorAdresse")]
        public ActionResult Produit()
        {
            ViewBag.Message = "Produit message.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError(View = "Error")]
        [HttpGet]
        public ActionResult Commentaire()
        {
            var listecommentaire = (from c in db.commentaire
                                    select c).ToList();
            if (listecommentaire.FirstOrDefault() == null)
            {
                return PartialView();
            }
            else
            {
                return PartialView(listecommentaire);
            }
        }

        //liste des restaurants en fonction de la ville
        [HttpGet]
        [HandleError(View = "ErrorAdresse")]
        public ActionResult GetRestaurant(string cityname)
        {
            if (string.IsNullOrEmpty(cityname))
            {
                ViewBag.Resut = "Erreur, entrer une ville (exemple: Strasbourg)";
                return View("Adresse", null);
            }
            else
            {
                var listerestaurant = (from r in db.restaurant
                                       from a in db.adresse
                                       where a.restaurantID == r.restaurantID
                                       where a.ville.ToUpper() == cityname.ToUpper()
                                       select r).ToList();
                if (listerestaurant.FirstOrDefault() == null)
                {
                    ViewBag.Resut = "Erreur, entrer une ville existante ou cette ville est non référencé (exemple: Strasbourg)";
                    return View("Adresse", null);
                }
                else
                {
                    return View("Restaurant", listerestaurant);
                }
            }
        }

        //liste des produit pour un restaurant
        [HttpGet]
        [HandleError(View = "ErrorAdresse")]
        public ActionResult GetProduit(int? restaurantID)
        {
            var listeproduit = (from p in db.produit
                                from r in db.restaurant
                                where r.restaurantID == restaurantID
                                where p.restaurantID == r.restaurantID
                                select p).ToList();
            if (listeproduit.FirstOrDefault() == null)
            {
                ViewBag.Resut = "Erreur, la liste des produits est vide pour le restaurant";
                return View("Restaurant");
            }
            else
            {
                return View("Produit", listeproduit);
            }
        }

    }
}
