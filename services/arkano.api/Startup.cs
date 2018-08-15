namespace arkano.api
{
    using arkano.api.Infrastructure.Extensions;
    using arkano.api.Models.Implementations;
    using arkano.common.domain;
    using arkano.data.daccess.Context;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OData.Edm;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.TenantConfiguration = Infrastructure.Extensions.Configuration.LoadTenantConfiguration();
        }

        public IConfiguration Configuration { get; }

        public IConfiguration TenantConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors();
            services.AddOptions();
            services.Configure<TenantsConfiguration>(this.TenantConfiguration);

            // https://blogs.msdn.microsoft.com/odatateam/2018/07/03/asp-net-core-odata-now-available/
            services.AddDbContext<ArkanoEfContext>();
            services.AddOData();
            services.AddMvc()
                .AddJsonOptions(                    
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); // To avoid reference loops in api responses serealization 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMultiTenantMiddleware();
            app.UseArkanoLoggerMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(config =>
            {
                config.MapODataServiceRoute("odata", "odata", GetEdmModel());
                config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); // Enable odata globally
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            
            builder.EntitySet<Course>("Courses");
            builder.EntitySet<Student>("Students");
            return builder.GetEdmModel();
        }
    }
}
