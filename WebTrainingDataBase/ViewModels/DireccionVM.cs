using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
    public class DireccionVM
    {
        public int Id { get; set; }
        [MaxLength(200,ErrorMessage ="Verificca el nombre de la calle")]
        [MinLength(5,ErrorMessage ="Verifica el nombre de la calle")]
        [Required(ErrorMessage ="El campo calle es obligatorio")]
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }

        public List<PersonaVM> Personas { get; set; }  
    }
}