using Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Reflection;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //For Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(opt =>
                {
                    var type = typeof(SharedResources);
                    var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    var factory = builder.Services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create("SharedResource", assemblyName.Name);
                    opt.DataAnnotationLocalizerProvider = (t, f) => localizer;
                });
            //End Localization 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //For Localization 
            var supportedCultures = new[] 
            { 
                new CultureInfo("en-US"),
                new CultureInfo("bn-BD"),
                new CultureInfo("es-ES")
            };
 
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                //Date, number format so on will change
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            //End Localization 
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}