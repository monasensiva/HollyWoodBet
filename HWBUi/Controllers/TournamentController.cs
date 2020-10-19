using HWBUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HWBUi.Controllers
{
    public class TournamentController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            IEnumerable<UiTournament> tournamentsList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Tournament").Result;
            tournamentsList = response.Content.ReadAsAsync<IEnumerable<UiTournament>>().Result;
            return View(tournamentsList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new UiTournament());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Tournament/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<UiTournament>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddorEdit(UiTournament uiTournament)
        {
            if (uiTournament.TournamentId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Tournament", uiTournament).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Tournament/" + uiTournament.TournamentId
                    , uiTournament).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Tournament/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}