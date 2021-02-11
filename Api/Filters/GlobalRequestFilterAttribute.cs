using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Api.Filters
{
    public class GlobalRequestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);

                return;
            }

            if (actionContext.ActionArguments.ContainsKey("request"))
            {
                var request = actionContext.ActionArguments.FirstOrDefault(i => i.Key.Equals("request", StringComparison.OrdinalIgnoreCase));
                if (request.Value == null)
                {
                    actionContext.Response = actionContext.Request
                        .CreateErrorResponse(HttpStatusCode.BadRequest, "Request cannot be null or empty");
                }
            }
        }

    }
}