using Localization;
using Localization.Utility;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using Services.Repository;
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
            builder.Services.AddLocalization();
            
            builder.Services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(opt =>
                {
                    //var type = typeof(SharedResources);
                    //var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    // var factory = builder.Services.BuildServiceProvider().GetService<CustomStringLocalizerFactory>();
                    //var localizer = factory.Create("SharedResource", assemblyName.Name);
                    // opt.DataAnnotationLocalizerProvider = (t, f) => localizer;
                     opt.DataAnnotationLocalizerProvider = (t, f) => f.Create(typeof(CustomStringLocalizer));
                });
            builder.Services.AddSingleton<IStringLocalizerFactory, CustomStringLocalizerFactory>();
            //End Localization 
            builder.Services.AddSingleton<ILocalizationServices,LocalizationServices>();

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