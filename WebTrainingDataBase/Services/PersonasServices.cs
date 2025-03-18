using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Services
{
    public class PersonasServices : IPersonasServices
    {
        private readonly TestDbMensajeriaEntities db = null;
        public PersonasServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }

        public bool Crear(Personas personas)
        {
            bool respuesta = false;
            //1 - Crear una transaccion
            var transaccion = this.db.Database.BeginTransaction();
            try
            {
                //2 - Crear la instancia de attach para la basse de datos 
                this.db.Personas.Add(personas);
                this.db.SaveChanges();
                transaccion.Commit();
                respuesta = true;
            }catch (Exception ex)
            {
                transaccion.Rollback();
                return respuesta;
            }
            return respuesta;

        }
    }
}