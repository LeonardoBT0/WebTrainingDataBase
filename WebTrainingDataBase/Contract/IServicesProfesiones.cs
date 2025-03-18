using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Contract
{
    public interface IServicesProfesiones
    {
        bool Create(Profesiones profesiones);
        Profesiones Get(int? id);
        List<Profesiones> GetAll();
        List<Profesiones> GetAllOrderByName();
    }
}
