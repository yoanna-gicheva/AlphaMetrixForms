using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using AlphaMetrixForms.Web.Middlewares;
using AlphaMetrixForms.Web.Utils.Contracts;
using AlphaMetrixForms.Web.Utils;
using AlphaMetrixForms.Services.Providers.Contracts;
using AlphaMetrixForms.Services.Providers;

namespace AlphaMetrixForms.Web
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
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<ITextQuestionService, TextQuestionService>();
            services.AddScoped<IOptionQuestionService, OptionQuestionService>();
            services.AddScoped<IDocumentQuestionService, DocumentQuestionService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IModelGenerator, ModelGenerator>();
            services.AddScoped<IFactory, Factory>();
            services.AddScoped<IBlobProvider, BlobProvider>();

            services.AddDbContext<FormsContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>().AddEntityFrameworkStores<FormsContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddControllersWithViews();
            services.AddRazorPages()
                 .AddMvcOptions(options =>
                 {
                     options.MaxModelValidationErrors = 50;
                     options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                         _ => "The field is required.");
                 });
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<PageNotFoundMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
