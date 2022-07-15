﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATteslaa.Models;

namespace ATteslaa.Controllers
{
    public class ModeloController : Controller
    {
        private carrosTeslaEntities db = new carrosTeslaEntities();

        // GET: Modelo
        public ActionResult Index()
        {
            var modelo = db.Modelo.Include(m => m.Veiculo);
            return View(modelo.ToList());
        }

        // GET: Modelo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modelo/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO = new SelectList(db.Veiculo, "CODIGO", "DESCRICAO");
            return View();
        }

        // POST: Modelo/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ANO,DESCRICAO,CODIGO")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Modelo.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO = new SelectList(db.Veiculo, "CODIGO", "DESCRICAO", modelo.CODIGO);
            return View(modelo);
        }

        // GET: Modelo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO = new SelectList(db.Veiculo, "CODIGO", "DESCRICAO", modelo.CODIGO);
            return View(modelo);
        }

        // POST: Modelo/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ANO,DESCRICAO,CODIGO")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(modelo).State = EntityState.Modified;//////////////////////////////
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO = new SelectList(db.Veiculo, "CODIGO", "DESCRICAO", modelo.CODIGO);
            return View(modelo);
        }

        // GET: Modelo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelo.Find(id);
            db.Modelo.Remove(modelo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
