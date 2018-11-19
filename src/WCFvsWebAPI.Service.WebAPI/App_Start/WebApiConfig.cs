using FluentValidation.WebApi;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using WCFvsWebAPI.Service.WebAPI.Filter;

namespace WCFvsWebAPI.Service.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ValidateModelStateFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            MediaTypeHeaderValue appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            SwaggerConfig.Register();
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
