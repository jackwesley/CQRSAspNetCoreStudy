using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.IO.Site.Helpers.Extensions
{
    public static class CultureExtension
    {
        /// <summary>
        /// Configura a cultura da aplicação para pt-br.
        /// </summary>
        /// <param name="app">o builder da aplicação.</param>
        /// <returns>o builder da aplicação de forma fluente.</returns>
        public static IApplicationBuilder UsePtBrCultureInfo(this IApplicationBuilder app)
        {
            // referência: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.requestlocalizationoptions?view=aspnetcore-2.0
            var ptbrCultures = new CultureInfo[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(
                new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("pt-br"),
                    SupportedCultures = ptbrCultures,
                    FallBackToParentCultures = true,
                    SupportedUICultures = ptbrCultures,
                    FallBackToParentUICultures = true,
                }
            );
            return app;
        }
    }
}
