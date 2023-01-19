using AutoMapper;
using DeliveryServiceApp.Services.Implementation;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceData.UnitOfWork.Implementation;
using DeliveryServiceDomain;
using DeliveryServiceServices.Implementation;
using DeliveryServiceServices.Interfaces;
using DeliveryServiceServices.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp
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
            services.AddScoped<IServiceAdditonalService, ServiceAdditionalService>();
            services.AddScoped<IServiceAddionalServiceShipment, ServiceAdditionalServiceShipment>();
            services.AddScoped<IServiceCustomer, ServiceCustomer>();
            services.AddScoped<IServiceDeliverer, ServiceDeliverer>();
            services.AddScoped<IServicePerson, ServicePerson>();
            services.AddScoped<IServiceShipment, ServiceShipment>();
            services.AddScoped<IServiceShipmentStatusStatistic, ServiceShipmentStatusStatistic>();
            services.AddScoped<IServiceShipmentWeight, ServiceShipmentWeight>();
            services.AddScoped<IServiceStatus, ServiceStatus>();
            services.AddScoped<IServiceStatusShipment, ServiceStatusShipment>();

            services.AddControllersWithViews(
            ).AddJsonOptions(x => x.JsonSerializerOptions.MaxDepth = Int32.MaxValue);

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(10));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonUnitOfWork, PersonUnitOfWork>();
            services.AddDbContext<DeliveryServiceContext>();
            services.AddDbContext<PersonContext>();
            services.AddScoped<IPasswordHasher<Person>, PasswordHasher<Person>>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AdditionalServiceProfile());
                mc.AddProfile(new AdditionalServiceShipmentProfile());
                mc.AddProfile(new AddressProfile());
                mc.AddProfile(new CustomerProfile());
                mc.AddProfile(new DelivererProfile());
                mc.AddProfile(new PersonProfile());
                mc.AddProfile(new ShipmentProfile());
                mc.AddProfile(new ShipmentWeightProfile());
                mc.AddProfile(new StatusProfile());
                mc.AddProfile(new StatusShipmentProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddIdentity<Person, IdentityRole<int>>().AddEntityFrameworkStores<PersonContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Authentication/Login";
                options.AccessDeniedPath = "/Home/AccesDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.SlidingExpiration = true;
            });

  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
