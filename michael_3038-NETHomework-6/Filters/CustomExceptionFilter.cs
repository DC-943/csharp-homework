using Microsoft.AspNetCore.Mvc.Filters;
using michael_3038_WebApiHomework.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace michael_3038_WebApiHomework.Filters
{
    public class CustomExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = new CommonResult<string>() { IsSucess = false, Message = "An error occurred while processing your request.", Result = context.Exception.Message };
            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
