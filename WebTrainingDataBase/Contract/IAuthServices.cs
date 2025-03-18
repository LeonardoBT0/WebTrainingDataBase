using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Infrestructura
{
    interface IAuthServices
    {
        Usuarios Login(string userName, string password);
        bool UpdatePassword(string userName, string oldPassword, string newPassword);
    }
}
