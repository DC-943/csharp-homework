using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text;

namespace michael_3038_WebApiHomework.Filters
{
    public class ActionFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Before Action executed...");
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor != null)
            {
                var actionName = context.ActionDescriptor.RouteValues["action"];
                var parameters = context.ActionArguments;
                foreach (var param in parameters)
                {
                    Console.WriteLine($"Action : {actionName} ----- parameters: {param.Key} = {param.Value} ");
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
             Console.WriteLine("After action has executed.");
        }
          

    }
}
