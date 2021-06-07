using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YEB.Data;
using YEB.Repository;
using YEB.Repository.Impl;
using YEB.Service;
using YEB.Service.Impl;

namespace YEB.WebApi
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

            services.AddControllers();
            #region SwaggerGen
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SPM.WebApi", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);
                // 添加Jwt认证部分
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "直接在下框中输入Bearer {token}(注意两者之间有一个空格)",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            #endregion

            #region Jwt认证
            var SecrtKey = Configuration["JwtConfig:SecrtKey"];
            var ISS = Configuration["JwtConfig:ISS"];
            var Audience = Configuration["JwtConfig:Audience"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = Audience,//Audience
                        ValidIssuer = ISS,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecrtKey))//拿到SecurityKey
                    };
                });
            #endregion

            #region 注入DbContext
            services.AddDbContext<Context>(options =>
            {
                var connectionString = "Server=localhost;Port=3306;Database=YEB;User=root;Password=root;pooling=true;sslmode=none;CharSet=utf8;";
                var serverVersion = new MySqlServerVersion(new Version(5, 7, 32));
                options
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging() // 在日志中显示参数值
                    .EnableDetailedErrors();      // with debugging (remove for production).
            });
            #endregion

            #region 注入Service Repository
            services.AddCustomIOC();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YEB.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    /// <summary>
    /// 注入Service Repository
    /// </summary>
    public static class DIService
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IFunctionRepository, FunctionRepositoryImpl>();
            services.AddScoped<IFunctionService, FunctionServiceImpl>();
            services.AddScoped<IMenuRepository, MenuRepositoryImpl>();
            services.AddScoped<IMenuService, MenuServiceImpl>();
            services.AddScoped<IRoleRepository, RoleRepositoryImpl>();
            services.AddScoped<IRoleService, RoleServiceImpl>();
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<IUserService, UserServiceImpl>();
            return services;
        }
    }
}
