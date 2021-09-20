using Microsoft.AspNetCore.Mvc.Filters;  
using System;

namespace TechnicalRadiation.Models.Attributes {
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private const string secretKey = "root beer";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (secretKey != context.HttpContext.Request.Headers["Authorization"]) {
                throw new UnauthorizedAccessException();
            }
        }
    }
}