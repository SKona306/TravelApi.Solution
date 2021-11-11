namespace TravelApi.Solutions
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
      readonly IApiVersionDescriptionProvider provider;

      public ConfigureSwaggerOptions( IApiVersionDescriptionProvider provider) => this.provider = provider;

      public void Configure( SwaggerGenOptions options)
      {
        foreach(var description in provider.ApiVersionDescriptions)
        {
          options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
      }

      static OpenApiInfo CreateInfoForApiVersion( ApiVersionDescription description)
      {
        var info = new OpenApiInfo()
        {
          Title = "Travel Api",
          Version = description.ApiVersion.ToString(),
          Description = "An Api that allows users to search reviews on vacation destinations",
          Contact = new OpenApiContact() { Name = "James", Email = "sampleEmail@gmail.com"},
          License = new OpenApiLicense() { Name = "MIT", Url = new Uri( "https://opensource.org/licenses/MIT" )}
        };

        if(description.IsDeprecated)
        {
          info.Description += " This API version has been deprecated";
        }

        return info;
      }
    }
}