using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
	public class UsuarioRolVM
	{
		public int Id { get; set; }
		public int IdUsuario { get; set; }
		public int IdRol { get; set; }
		public RolVM RolVM { get; set; }
		public AuthVM AuthVM { get; set; }
	}
}