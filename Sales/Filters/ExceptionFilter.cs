using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using Sales.CrossCutting.Resources;
using Sales.Service.ViewModels;
using System.Collections.Generic;
using System.Net;

namespace Sales.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var stackTrace = $@"{exception.Message} 
                                \nStackTrace: {exception.StackTrace} 
                                \nInnerException: {(exception.InnerException != null ? exception.InnerException.StackTrace
                                                                                     : string.Empty)}";

                _logger.Error(exception);

                var notifications = JsonConvert.SerializeObject(new
                {
                    code = HttpStatusCode.InternalServerError,
                    errors = new List<NotificationViewModel>() {
                    new NotificationViewModel{
                        Subject = "Error",
                        Message = GlobalMessages.UnexpectedException,
                        Details = stackTrace
                    }
                }
                }, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                context.Result = new ContentResult
                {
                    Content = notifications,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    ContentType = "application/json"
                };
        }
    }
}