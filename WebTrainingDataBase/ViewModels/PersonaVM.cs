using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
    public class PersonaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$", ErrorMessage = "El campo solo permite letras, no números o caracteres especiales")] public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        public string ApellidoMaterno { get; set; }
        [Range(10, 100, ErrorMessage = "La edad debe ser valida")]
        public int Edad { get; set; }
        public int IdDireccion { get; set; }
        public int IdTelefono { get; set; }


        public DireccionVM DireccionVM { get; set; }
        public TelefonoVM TelefonoVM { get; set; }
        public List<ProfesionesPersonasVM> ProfesionesPersonaVM { get; set; }
    }
}