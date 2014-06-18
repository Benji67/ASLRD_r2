using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASLRD_r2.DataBaseAccess;

namespace ASLRD_r2.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/
        private DataBaseASLRDEntities db = new DataBaseASLRDEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HandleError(View = "Error")]
        [HttpGet]
        public ActionResult _Commentaire()
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

    }
}
