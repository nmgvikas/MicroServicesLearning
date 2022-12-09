using Employees.App.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Employees.App.CrossCuts
{
    public class ActionLogFilterAttribute : ActionFilterAttribute, IActionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LogAnalyticsDbContext ctx = new LogAnalyticsDbContext();
            ActionLog log = new ActionLog
            {
                TimeStamp = DateTime.Now,
                Controller = context.ActionDescriptor.RouteValues["controller"].ToString(),
                Action = context.ActionDescriptor.RouteValues["action"].ToString(),
                SourceIp = context.HttpContext.Connection.RemoteIpAddress.ToString()

            };
            ctx.ActionLogs.Add(log);
            ctx.SaveChanges();

            //base.OnActionExecuting(context);
        }
    }
}
