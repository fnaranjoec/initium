using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BalconyTickets
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages().AddRazorRuntimeCompilation();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment() || env.IsStaging())
            {
                // app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions() { SourceCodeLineCount = 10 });
                app.UseExceptionHandler("/Error-local-development");

                // app.UseExceptionHandler(
                //               options =>
                //               {
                //                   options.Run(
                //                       async context =>
                //                       {
                //                           context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //                           context.Response.ContentType = "text/html";
                //                           var ex = context.Features.Get<IExceptionHandlerFeature>();
                //                           await context.Response.WriteAsync("\r\n");
                //                           await context.Response.WriteAsync("ERROR!\r\n");

                //                           // await context.Response.WriteAsync(ex.Error.InnerException.Message);


                //                           await context.Response.WriteAsync("\r\n");

                //                           //var message = "";

                //                           //if (ex.Error.InnerException.ToString().Contains("UNIQUE KEY"))
                //                           //{
                //                           //    message = "Some date are duplicate";
                //                           //}

                //                           //if (ex != null)
                //                           //{

                //                           //    //var err = $"<h2>Error: {ex.Error.Message}</h2><p>{ex.Error.InnerException}</p>";
                //                           //    var err = $"<h2>Error: {message}</h2><p>Review data and try again.</p>";
                //                           //    await context.Response.WriteAsync(err).ConfigureAwait(false);
                //                           //}

                //                       });

                //               }
                //           );
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseExceptionHandler(options => {
                //    options.Run(async context =>
                //    {
                //        await context.Response.WriteAsync(JsonConvert.SerializeObject("{ Status: Error, Description: Oops something went wrong}"));
                //    });
                //});
            }
            
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });


        }


    }
}
