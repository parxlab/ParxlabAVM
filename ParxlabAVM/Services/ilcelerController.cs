﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ParxlabAVM.Models;

namespace ParxlabAVM.Services
{
    public class ilcelerController : ApiController
    {
        private Model db = new Model();

        [HttpGet]
        // GET: api/ilceler
        public IQueryable<ilce> ilceler()
        {
            return db.ilce;
        }

        [HttpGet]
        // GET: api/ilceler/5
        [ResponseType(typeof(IQueryable<ilce>))]
        public IHttpActionResult ilceler(int id)
        {
            IQueryable<ilce> ilceler = from ilce in db.ilce where ilce.ilid == id select ilce;
            if (ilceler == null)
            {
                return NotFound();
            }

            return Ok(ilceler);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ilceExists(int id)
        {
            return db.ilce.Count(e => e.ilceid == id) > 0;
        }
    }
}