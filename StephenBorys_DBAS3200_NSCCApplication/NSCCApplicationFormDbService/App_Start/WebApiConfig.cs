using NSCCApplicationFormDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace NSCCApplicationFormDbService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filter()
                 .Expand()
                 .Select()
                 .OrderBy()
                 .MaxTop(null)
                 .Count();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Applicant>("Applicants");
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<Application>("Applications");
            builder.EntitySet<Campus>("Campuses");
            builder.EntitySet<Citizenship>("Citizenships");
            builder.EntitySet<Gender>("Genders");
            builder.EntitySet<Program>("Programs");
            builder.EntitySet<ProvinceState>("ProvinceStates");
            builder.EntitySet<ProgramChoice>("ProgramChoices");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
