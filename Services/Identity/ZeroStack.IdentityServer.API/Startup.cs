using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;
using ZeroStack.IdentityServer.API.Infrastructure.Aliyun;
using ZeroStack.IdentityServer.API.Infrastructure.Authentication.Microsoft;
using ZeroStack.IdentityServer.API.Infrastructure.Tenants;
using ZeroStack.IdentityServer.API.Models;
using ZeroStack.IdentityServer.API.Services;

namespace ZeroStack.IdentityServer.API
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddViewLocalization().AddDataAnnotationsLocalization();

            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders().AddClaimsPrincipalFactory<CustomUserClaimsPrincipalFactory>();

            services.AddIdentityServer().AddAspNetIdentity<ApplicationUser>()
               .AddSigningCredential(Certificates.Certificate.Get())
               .AddConfigurationStore(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("Default"), sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                       sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                   });
               })
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("Default"), sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                       sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                   });
               }).AddProfileService<IdentityProfileService>();

            services.Configure<AlibabaCloudOptions>(Configuration.GetSection("AlibabaCloud"));

            services.AddTransient<AliyunAuthHandler>();
            services.AddHttpClient("aliyun").AddHttpMessageHandler<AliyunAuthHandler>();

            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                microsoftOptions.RemoteAuthenticationTimeout = TimeSpan.FromDays(15);
                microsoftOptions.CorrelationCookie.SameSite = SameSiteMode.Lax;
            }).AddQQ(qqOptions =>
            {
                qqOptions.ClientId = Configuration["Authentication:TencentQQ:AppID"];
                qqOptions.ClientSecret = Configuration["Authentication:TencentQQ:AppKey"];
                qqOptions.RemoteAuthenticationTimeout = TimeSpan.FromDays(15);
                qqOptions.CorrelationCookie.SameSite = SameSiteMode.Lax;
            }).AddGitHub(gitHubOptions =>
            {
                gitHubOptions.ClientId = Configuration["Authentication:GitHub:ClientID"];
                gitHubOptions.ClientSecret = Configuration["Authentication:GitHub:ClientSecret"];
                gitHubOptions.RemoteAuthenticationTimeout = TimeSpan.FromDays(15);
                gitHubOptions.CorrelationCookie.SameSite = SameSiteMode.Lax;
            }).AddWeibo("Weibo", "Î¢²©", weiboOptions =>
            {
                weiboOptions.ClientId = Configuration["Authentication:Weibo:AppKey"];
                weiboOptions.ClientSecret = Configuration["Authentication:Weibo:AppSecret"];
                weiboOptions.UserEmailsEndpoint = string.Empty;
                weiboOptions.RemoteAuthenticationTimeout = TimeSpan.FromDays(15);
                weiboOptions.CorrelationCookie.SameSite = SameSiteMode.Lax;
            }).AddWeixin("WeChat", "Î¢ÐÅ", weChatOptions =>
            {
                weChatOptions.ClientId = Configuration["Authentication:WeChat:AppID"];
                weChatOptions.ClientSecret = Configuration["Authentication:WeChat:AppSecret"];
                weChatOptions.RemoteAuthenticationTimeout = TimeSpan.FromDays(15);
                weChatOptions.CorrelationCookie.SameSite = SameSiteMode.Lax;
            });

            services.AddCors(options =>
            {
                string[] allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<string[]>();
                options.AddDefaultPolicy(builder => builder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddTransient<IEmailSender, AuthMessageSender>().AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string[] supportedCultures = new[] { "zh-CN", "en-US" };
            RequestLocalizationOptions localizationOptions = new()
            {
                ApplyCurrentCultureToResponseHeaders = false
            };
            localizationOptions.SetDefaultCulture(supportedCultures.First()).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);

            SampleDataSeed.SeedAsync(app).Wait();

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

            app.UseCors();

            app.UseIdentityServer();

            app.UseRouting();

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
