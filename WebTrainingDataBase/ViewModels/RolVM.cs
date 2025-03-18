using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrainingDataBase.ViewModels
{
	public class RolVM
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public List<AuthVM> AuthVMs { get; set; }
	}
}