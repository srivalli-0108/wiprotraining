using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
namespace MyMvcProject
{
    public class EvenNumbersConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
                     RouteValueDictionary values, RouteDirection routeDirection)
   {
       if (values.TryGetValue(routeKey, out var value) && value != null)
       {
           if (int.TryParse(value.ToString(), out int number))
           {
               return number % 2 == 0;
           }
       }
       return false;
   }
    }
}