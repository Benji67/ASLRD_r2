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

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        //Ajouter au panier un produit
        [HttpGet]
        [HandleError(View = "ErrorAdresse")]
        public ActionResult AddToPanier(int ProduitID)
        {
            // Add it to the shopping cart
            string cart = GetCartId(this.HttpContext);

            var commandeItem = db.commande.SingleOrDefault(c => c.clientID == cart);


            // Produit information
            var Produit = (from p in db.produit
                           where p.produitID == ProduitID
                           select p);

            // Create a new cart item if no cart item exists
            commandeItem = new commande
            {
                commandeID = 2,
                prixtotal = 2,
                datecommande = DateTime.Now,
                etatcommande = "current",
                clientID = cart,
                restaurantID = 1
            };

            db.commande.Add(commandeItem);
            db.SaveChanges();

            //cart.AddToCart(addedProduit);

            // Go back to the main store page for more shopping
            //ViewBag.Message = "Contact message.";
            return View("Adresse");
        }

    }
}
