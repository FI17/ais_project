﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;
using System.IO;

namespace AIS_FI15.Controllers
{
    public class SuchenController : Controller
    {
        // GET: Suchen
        public ActionResult Index(string Suchwort)
        {
            string json = SuchenModel.Auslesen(Server.MapPath("~/App_Data/SearchStrings.json"));

        
            JavaScriptSerializer js = new JavaScriptSerializer();
                SuchenModel.Navigation[] Navi = js.Deserialize<SuchenModel.Navigation[]>(json);

                for(int l = 0; l < Navi.Length; l++ )
                {
                    try
                    {
                        if (Navi[l].word == Suchwort.ToLower())
                            return RedirectToAction("index", Navi[l].site);
                    }
                    catch (Exception)
                     {
                        return RedirectToAction("index", "Home/Index");
                        throw;
                     }
                       
                }
            
            AIS_FI15.Models.SuchwortModel sw = new AIS_FI15.Models.SuchwortModel { SuchwortSend = Suchwort };             
            return View(sw);
        }

    }
}