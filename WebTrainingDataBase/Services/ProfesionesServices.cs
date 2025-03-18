using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Service
{
    public class ProfesionesServices : IServicesProfesiones
    {
        private readonly TestDbMensajeriaEntities db = null;
        public ProfesionesServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }

        public List<Profesiones> GetAll()
        {
            return this.db.Profesiones.ToList();
        }

        public List<Profesiones> GetAllOrderByName()
        {
            return this.db.Profesiones.OrderBy(o => o.strValor).ToList();
        }

        public Profesiones Get(int? id)
        {
            return this.db.Profesiones
                .SingleOrDefault(s => s.Id == id);
        }

        public bool Create(Profesiones profesiones)
        {
            var transacciones = this.db.Database.BeginTransaction();
            this.db.Profesiones.Add(profesiones);
            this.db.SaveChanges();
            transacciones.Commit();
            return true;
        }
    }
}