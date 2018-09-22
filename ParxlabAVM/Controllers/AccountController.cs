﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ParxlabAVM.Identity;
using ParxlabAVM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParxlabAVM.Services;
using System.Net.Http;
using System.Web.Http.Results;

namespace ParxlabAVM.Controllers
{   
    [Authorize]
    public class AccountController : Controller
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        // GET: Account - Kullanıcı kayıt kullanıcı giriş/çıkış işlemlerinin yapılacağı controller


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(KayitKalibi model)
        {           
            HttpResponseMessage result = WebApiCagirici.postFonksiyonuCagir("kullanicilar/kullaniciekle", serializer.Serialize(model));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Erişim hakkınız yok" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(GirisKalibi model, string returnUrl)
        {
            /*
            if (ModelState.IsValid)
            {


                var user = userManager.Find(model.kullaniciadi, model.sifre);

                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış kullanıcı adı veya parola");

                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication; //Login işlemini veya logout işlemini yapan nesne

                    var identity = userManager.CreateIdentity(user, "ApplicationCookie"); // Cookie - Cookie yi authManager aracılığıyla gönderiyoruzz

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true

                    };

                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);

                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);

                }
            }*/
            ViewBag.returnUrl = returnUrl;
            return View(model);

        }





        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }

    }
}