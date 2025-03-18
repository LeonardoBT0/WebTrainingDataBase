using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
    public class AccountVM
    {
        [MaxLength(120, ErrorMessage ="Ingresa un email valido")]
        [MinLength(12,ErrorMessage ="Ingresa el email de forma valida")]
        [Required(ErrorMessage ="Este (Email) campo es requerido")]
        public string Email { get; set; }

        [MinLength(6,ErrorMessage ="El password debe contener 6 caracteres")]
        [Required(ErrorMessage ="Este (Password) campo es requerido")]
        public string Password { get; set; }
    }
}