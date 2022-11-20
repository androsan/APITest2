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
    public class ExternalController : Controller
    {
        private readonly ILogger<ExternalController> _logger;
        private readonly ApplicationDbContext _db;

        public ExternalController(ILogger<ExternalController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        #region//**************************************** External API method: getAllUsers ********************************************************
        
        // POST - API_CALL
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        [HttpPost]
        public List<VhodniPodatki> getAllUsers([FromBody] VhodniPodatki filter)
        {
            var response = new List<VhodniPodatki>();
            List<SeznamUporabnikov> vsiUporabniki = _db.SeznamUporabnikov.ToList();


            
            if (ModelState.IsValid && vsiUporabniki.Count > 0)
            {
                // API klic vrne seznam VSEH uporabnikov, vendar samo izbrano polje (Ime, Priimek,..)
                foreach (SeznamUporabnikov i in vsiUporabniki)
                {
                    var uporabnik = new VhodniPodatki
                    {
                        Ime = i.Ime,
                        Priimek = i.Priimek,
                        Email = i.Email,
                    };
                    response.Add(uporabnik);
                }
            }
            var res = Ok();  // Status API klica (200=OK,..)
            return response;
        }

        #endregion


    }
}


