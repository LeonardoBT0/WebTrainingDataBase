using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Models;

namespace WebTrainingDataBase.Services
{
    public class AccountServices  : IServiceAccount
    {
        private readonly TestDbMensajeriaEntities db = null;
        public AccountServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }

        public string Validate(Login login)
        {
           var result = this.db.Login.SingleOrDefault(l => l.Email.Equals(login.Email.ToLower()) && l.Password.Equals(login.Password));

            if (result != null)
            {
                return result.Email;
            }
            return string.Empty;
        }
    }
}