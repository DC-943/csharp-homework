using michael_3038_WebApiHomework.Models;
using michael_3038_WebApiHomework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace michael_3038_WebApiHomework.Filters
{
    public class ResultFilter:IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("before results excuted");
            if (context.Result is JsonResult jsonResult)
            {
                User newUser = new User() { UserId = 3, UserName = "Jim", Address = "Australia", Email = "Jim@gmail.com", Gender = GenderEnum.Male, Password = "789", Phone = "0923455" };
                jsonResult.Value = new CommonResult<User>() { IsSucess = true, Message = "successfully modified user info in the result filter", Result = newUser, Timestamp = DateTime.UtcNow };
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("after results excuted");
        }

    }
}
