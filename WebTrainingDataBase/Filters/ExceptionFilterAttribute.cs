using NLog;
using System;
using System.Web.Mvc;

namespace WebTrainingDataBase.Filter
{
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            Logger.Error(filterContext.Exception,
                $"Ocurrió una excepción en el controlador: {filterContext.RouteData.Values["controller"]} " +
                $"Acción: {filterContext.RouteData.Values["action"]}");

            filterContext.Result = new ViewResult
            {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}
