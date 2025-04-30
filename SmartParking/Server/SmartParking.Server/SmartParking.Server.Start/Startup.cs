using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Configs;
using SmartParking.Server.Common.Entities.Response;
using SmartParking.Server.Service.Impl;

namespace SmartParking.Server.Start
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
            services.AddScoped<IDBConfig.IDBConfig, DBConfig.DBConfig>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IUpgradeFileService, UpgradeFileService>();
            services.AddScoped<IMenuService, MenuService>();
            services
                .AddAuthentication(a =>
                {
                    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                // 添加token验证方案
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfiguration.JwtSecret)),
                        ValidAudience = "SmartParkingServer",
                        ValidIssuer = "SmartParkingServer",
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        // 认证失败时触发（如 Token 无效、过期等）
                        OnAuthenticationFailed = context =>
                        {
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var errorMessage = context.Exception switch
                            {
                                SecurityTokenExpiredException => "token已过期",
                                SecurityTokenInvalidSignatureException => "无效签名",
                                _ => "请登录"
                            };
                            return context.Response.WriteAsJsonAsync(ResponseEntity.Failed(401, errorMessage));
                        },
                        // 未携带token
                        OnChallenge = context =>
                        {
                            //禁用默认质询逻辑，允许完全自定义响应。
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsJsonAsync(ResponseEntity.Failed(401, "请登录"));
                        }
                    };
                });
            services.AddAuthorization(options =>
            {
                // 当 Controller 或 Action 未明确指定授权要求时生效。
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartParking.Server.Start", Version = "v1" });

                // jwt认证支持
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",            // HTTP 头的名称
                    Type = SecuritySchemeType.Http,   // 认证类型为 HTTP 头
                    Scheme = "bearer",                // 认证方案为 bearer (即 JWT 的 "Bearer" 前缀)
                    BearerFormat = "JWT",             // Token 格式说明（仅文档显示，不影响实际验证）
                    In = ParameterLocation.Header,    // Token 位置（HTTP 头）
                    Description = "JWT 授权头，格式：Bearer {token}" // 文档中的提示信息
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" // 引用上面定义的 "Bearer" 方案
                            }
                        },
                        new string[] { }  // 空数组表示该安全方案适用于所有 API 端点
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartParking.Server.Start v1"));
            }

            app.UseRouting();
            // 认证和授权中间件（顺序重要！）
            app.UseAuthentication(); // 认证中间件（解析 Token）
            app.UseAuthorization(); // 授权中间件（验证权限）
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}