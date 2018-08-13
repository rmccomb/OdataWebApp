using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using OdataWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdataWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            config.AddODataQueryFilter();

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Employee>("Employees");

            // http://odata.github.io/WebApi/#13-01-modelbound-attribute
            // the default setting for WebAPI OData is : 
            // client can’t apply $count, $orderby, $select, $top, $expand, $filter in the query, 
            // query like localhost\odata\Customers ?$orderby = Name will failed as BadRequest, 
            // because all properties are not sortable by default, 
            // this is a breaking change in 6.0.0
            builder.EntityType<Employee>()
                .OrderBy().Filter().Count().Select().Expand();

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });

        }
    }
}
