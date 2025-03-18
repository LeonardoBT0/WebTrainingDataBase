using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Contract
{
    public interface IServiceAccount
    {
        string Validate(Login login);
    }
}
