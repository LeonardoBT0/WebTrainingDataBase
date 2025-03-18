using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
    public class TelefonoVM
    {
        public int Id { get; set; }
        [MaxLength(10,ErrorMessage ="Verifica el  numero telecfonico")]
        [Required(ErrorMessage ="El campo del telefono celular es requerido")]
        public string NumeroCelular { get; set; }
        public string NumeroCasa { get; set; }

        public List<PersonaVM> Personas { get; set; }
    }
}