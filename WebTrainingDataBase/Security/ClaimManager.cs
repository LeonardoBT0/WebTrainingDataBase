using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Infrestructura;
using WebTrainingDataBase.Models;
using WebTrainingDataBase.Services;
using WebTrainingDataBase.ViewModels;

namespace WebTrainingDataBase.Security
{
    public class ClaimManager : IClaimManager
    {
        private readonly IAuthServices authServices;

        public ClaimManager()
        {
            authServices = new AuthServices();
        }

        public ClaimsIdentity CreateIdentity(AuthVM authVM, bool rememberMe)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, authVM.Id.ToString()),
                new Claim(ClaimTypes.Email, authVM.Email),
                new Claim(ClaimTypes.Name, authVM.NombreDeUsuario),
            };

            if (authVM.UsuarioRolVMs != null && authVM.UsuarioRolVMs.Any())
            {
                claims.AddRange(authVM.UsuarioRolVMs.Select(r => new Claim(ClaimTypes.Role, r.RolVM.Nombre)));
            }

            return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public void SignOut()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public bool SignIn(AuthVM authVM, bool rememberMe, string _returnUrl)
        {
            Usuarios usuario = authServices.Login(authVM.Email, authVM.Password);
            if (usuario != null)
            {
                var userRol = usuario.UsuarioRol.Select(r => new UsuarioRolVM
                {
                    IdRol = r.IdRol ?? 0, // Manejo de valores nulos
                    IdUsuario = r.IdUsuario ?? 0, // Manejo de valores nulos
                    RolVM = new RolVM
                    {
                        Nombre = r.Roles.Nombre,
                        Id = r.Roles.Id
                    }
                }).ToList();

                if (userRol.Any())
                {
                    authVM.Email = usuario.Email.Trim();
                    authVM.Password = usuario.Password.Trim();
                    authVM.UsuarioRolVMs = userRol;

                    var identity = CreateIdentity(authVM, rememberMe);
                    var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;

                    authenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = rememberMe
                    }, identity);

                    return true;
                }
            }

            return false;
        }
    }
}
