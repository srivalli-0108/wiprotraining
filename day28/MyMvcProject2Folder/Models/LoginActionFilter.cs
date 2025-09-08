using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
public class LogActionFilter : IActionFilter
{
 public void OnActionExecuting(ActionExecutingContext context)
 {
    Debug.WriteLine($"[Log] Executing: {context.ActionDescriptor.DisplayName}");
 }
  public void OnActionExecuted(ActionExecutedContext context)
  {
     Debug.WriteLine($"[Log] Executed: {context.ActionDescriptor.DisplayName}");
  }
}