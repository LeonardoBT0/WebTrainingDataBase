using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
	public class ProfesionesPersonasVM
	{
		public int Id { get; set; }
		public int Id_Personas { get; set; }
		public int IdProfesiones { get; set; }
		public DateTime fechaRegistro { get; set; }
		public PersonaVM PersonaVM { get; set; }
		public ProfesionesVM ProfesionesVM { get; set; }
	}
}