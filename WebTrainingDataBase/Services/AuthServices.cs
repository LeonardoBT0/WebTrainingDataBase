using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTrainingDataBase.Infrestructura;
using WebTrainingDataBase.Models;
using WebTrainingDataBase.Security;
using WebTrainingDataBase.ViewModels;

namespace WebTrainingDataBase.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly TestDbMensajeriaEntities db = null;

        public AuthServices()
        {
            db = new TestDbMensajeriaEntities();
        }

        public Usuarios Login(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return null;

            }

            Usuarios usuario = db.Usuarios
                .Include("UsuarioRolVM")
                .FirstOrDefault(u => u.Email == userName);
            if (usuario == null)
            {
                return null;
            }
            usuario.UsuarioRol = db.UsuarioRol
                .Where(u => u.IdUsuario == usuario.Id).ToList();

            return usuario;
        }

        public bool UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            bool respuesta = false;

            var transaccion = this.db.Database.BeginTransaction();

            Usuarios usuario = this.db.Usuarios.SingleOrDefault(p => p.Email.Equals(userName) && p.Password.Equals(oldPassword));
            if (usuario != null)
            {


                usuario.Password = newPassword;
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                this.db.SaveChanges();
                respuesta = true;
                transaccion.Commit();
            }
            else
            {
                transaccion.Rollback();
            }


            return respuesta;
        }
    }
}