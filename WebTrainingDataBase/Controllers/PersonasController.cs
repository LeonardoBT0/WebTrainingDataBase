using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Filter;
using WebTrainingDataBase.Models;
using WebTrainingDataBase.Service;
using WebTrainingDataBase.Services;
using WebTrainingDataBase.ViewModels;

namespace WebTrainingDataBase.Controllers
{
    public class PersonasController : Controller
    {
        private TestDbMensajeriaEntities db = new TestDbMensajeriaEntities();

        private readonly IPersonasServices services = null;
        private readonly IServicesProfesiones profesionesServices = null;

        public PersonasController()
        {
            services = new PersonasServices();
            profesionesServices = new ProfesionesServices();
        }

        [HttpGet]
        public ActionResult Creates()
        {
            ViewBag.Profesiones = new SelectList(profesionesServices.GetAllOrderByName(),
                "Id", "strValor");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionFilterAttribute]
        public ActionResult Creates([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,Edad,TelefonoVM,DireccionVM,Profesiones  ")]PersonaVM personaVM,int Profesiones)
        {
            if (ModelState.IsValid)
            {
                List<ProfesionesPersonasVM> profesionesPersonas = new List<ProfesionesPersonasVM>();
                profesionesPersonas.Add(new ProfesionesPersonasVM()
                {
                    IdProfesiones=Profesiones,
                    PersonaVM = personaVM 
                });

                personaVM.ProfesionesPersonaVM = profesionesPersonas;

                Personas persona = new Personas();
                Mapper.Map<PersonaVM, Personas>(personaVM);
                services.Crear(persona);

                #region Add To session
                Session.Add("UserRegister", personaVM);
                #endregion

                return RedirectToAction("Perfil");
            }
            return View(personaVM);
        }

        [HttpGet]
        public ActionResult Perfil()
        {
            if(Session.Count > 0)
            {
                var personasVMSesion = (WebTrainingDataBase.ViewModels.PersonaVM)Session["UserRegister"];
                ViewBag.NombreCompleto = personasVMSesion.Nombre.ToLower() + "" +
                    personasVMSesion.ApellidoPaterno.ToLower() + "" + personasVMSesion.ApellidoMaterno.ToLower();

                Session.Remove("UserRegister");
                return View(personasVMSesion);
            }
            return RedirectToAction("Creates","Personas");
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