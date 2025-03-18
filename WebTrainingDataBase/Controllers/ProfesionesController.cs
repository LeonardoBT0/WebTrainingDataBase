using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Models;
using WebTrainingDataBase.Service;
using WebTrainingDataBase.ViewModels;

namespace WebTrainingDataBase.Controllers
{
    public class ProfesionesController : Controller
    {
        private TestDbMensajeriaEntities db = new TestDbMensajeriaEntities();
        private IServicesProfesiones services;
        // GET: Profesiones
        [AllowAnonymous]
        public ActionResult Index()
        {
            services = new ProfesionesServices();
            return View(services.GetAll());
        }

        // GET: Profesiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesiones profesiones = services.Get(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // GET: Profesiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,strValor,strDescripcion")] Profesiones profesiones)
        {
            if (ModelState.IsValid)
            {
                db.Profesiones.Add(profesiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesiones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "strValor,strDescripcion")] WebTrainingDataBase.ViewModels.ProfesionesVM profesionesVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Profesiones profesiones = new Profesiones();
                    AutoMapper.Mapper.Map(profesionesVM, profesiones);
                    this.services.Create(profesiones);
                    return Json(new { success = true });
                }catch(Exception ex)
                {
                    return Json(new { succes = true, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Datos invalidos" });
        }
        [Authorize(Users = "admin@plataforma.com", Roles = "Admin")]
        // GET: Profesiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            services = new ProfesionesServices();
            Profesiones profesiones = services.Get(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // POST: Profesiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,strValor,strDescripcion")] Profesiones profesiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesiones);
        }
        [Authorize]
        // GET: Profesiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesiones profesiones = services.Get(id);
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        // POST: Profesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesiones profesiones = services.Get(id);
            db.Profesiones.Remove(profesiones);
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
