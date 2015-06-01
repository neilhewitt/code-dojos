using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BowlingScores.Site.Models;

namespace BowlingScores.Site.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlayers(AddPlayersViewModel model)
        {
            return View();
        }
    }
}