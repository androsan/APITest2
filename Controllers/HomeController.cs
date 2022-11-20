using System;
using CS_webapp.Models;
using CS_webapp.Models.API;
using CS_webapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;


namespace CS_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        #region//**************************************** Seznam uporabnikov **********************************************
        // GET - INDEX
        public IActionResult Index()
        {
            List<SeznamUporabnikov> objList = _db.SeznamUporabnikov.ToList();
            return View(objList);

        }
        #endregion

        #region//**************************************** Registrirani uporabniki *****************************************
        // GET - CREATE
        public IActionResult RegisteredUsers()
        {
            List<SeznamUporabnikov> registriraniUporabniki = _db.SeznamUporabnikov.Where(x => x.OnMailingList == true).ToList();
            return View(registriraniUporabniki);
        }
        #endregion

        #region//**************************************** Dodaj novega uporabnika *****************************************

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeznamUporabnikov uporabnik)
        {
            if (ModelState.IsValid)
            {
                var novVnos = new SeznamUporabnikov
                {
                    ID_SeznamUporabnikov = new Guid(),
                    Ime = uporabnik.Ime,
                    Priimek = uporabnik.Priimek,
                    Email = uporabnik.Email,
                    OnMailingList = false
                };

             _db.SeznamUporabnikov.Add(novVnos);   
             _db.SaveChanges();
             return RedirectToAction("Index");
            }
            else
            {
                return View(uporabnik);
            }
        }

        #endregion

        #region//**************************************** Briši uporabnika ************************************************

        // GET - DELETE
        public IActionResult Delete(Guid id)
        {
            var deleteUser = _db.SeznamUporabnikov.Where(x => x.ID_SeznamUporabnikov == id).FirstOrDefault();
            _db.SeznamUporabnikov.Remove(deleteUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region//**************************************** Prijavi uporabnika **********************************************

        // GET - PRIJAVI
        public IActionResult Prijavi(Guid id)
        {
            var findCandiate = _db.SeznamUporabnikov.Where(x => x.ID_SeznamUporabnikov == id).FirstOrDefault();
            findCandiate.OnMailingList = true;
            _db.SeznamUporabnikov.Update(findCandiate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*
        // POST - PRIJAVI
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrijaviPost(Guid id)
        {
            Debug.WriteLine("Kliknili st gumb 'Dodaj', ki doda novega uporabnika v mailing listo. ");
            var findCandiate = _db.SeznamUporabnikov.Where(x => x.ID_SeznamUporabnikov == id).FirstOrDefault();
            findCandiate.OnMailingList = true;
            _db.SeznamUporabnikov.Update(findCandiate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        #endregion

        #region//**************************************** Odjavi uporabnika ***********************************************

        // POST - ODJAVI
        public IActionResult Odjavi(Guid id)
        {
            var findRegistered = _db.SeznamUporabnikov.Where(x => x.ID_SeznamUporabnikov == id).FirstOrDefault();
            findRegistered.OnMailingList = false;
            _db.SeznamUporabnikov.Update(findRegistered);
            _db.SaveChanges();
            //List<SeznamUporabnikov> registriraniUporabniki = _db.SeznamUporabnikov.Where(x => x.OnMailingList == true).ToList();
            //return View(registriraniUporabniki);
            return RedirectToAction("RegisteredUsers");
        }

        #endregion

        #region//**************************************** API klic ********************************************************
        
        // POST - API_CALL
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        [HttpPost]
        public List<IzhodniPodatki> APICall([FromBody] VhodniPodatki headers)
        {
            var response = new List<IzhodniPodatki>();
            List<SeznamUporabnikov> registriraniUporabniki = _db.SeznamUporabnikov.Where(x => x.OnMailingList == true && x.Ime == headers.Ime).ToList();
            
            if (ModelState.IsValid && registriraniUporabniki.Count > 0)
            {
                // API klic vrne seznam imen, priimkov in e-naslovov uporabnikov na mailing listi
                foreach (SeznamUporabnikov i in registriraniUporabniki)
                {
                    var registeredUser = new IzhodniPodatki
                    {
                        Ime = i.Ime,
                        Priimek = i.Priimek,
                        Email = i.Email,
                    };
                    response.Add(registeredUser);
                }
            }
            var res = Ok();
            return response;
        }

        #endregion


    }
}


