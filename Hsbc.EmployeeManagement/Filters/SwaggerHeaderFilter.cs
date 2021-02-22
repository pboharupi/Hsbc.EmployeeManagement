using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Hsbc.EmployeeManagement.Filters
{
    public class SwaggerHeaderFilter:IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
           var parameter=new Parameter
            {
                name="Authorization",
                @in="header",
                type="string",
                description="JWT Token",
                required=true
            };
            if (apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                parameter.required = false;
            }
            operation.parameters.Add(parameter);
        }
    }
}