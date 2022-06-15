using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuanLyNhaXe.DTOS;
using QuanLyNhaXe.Models;
using QuanLyNhaXe.Security.Requirement;
using QuanLyNhaXe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe
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
            services.AddDbContext<MyDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("QuanLyNhaXe"));
            });         
            // add cors
            services.AddCors();

            //services.AddControllers().AddNewtonsoftJson(x => 
            //x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddIdentity<UserIdentity, IdentityRole>(options =>
            {
                //Mat Khau
                options.Password.RequireDigit = false;  // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequiredLength = 3; // Không bắt ký tự đặc biệt
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lần thì khóa
                options.Lockout.AllowedForNewUsers = true;

                //User
                options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Mức 1", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.Requirements.Add(new UserAuthorize1()); // Mức độ 1- Có Mức Độ = 0
                });
                options.AddPolicy("Mức 2", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.Requirements.Add(new UserAuthorize2());// Mức độ 1- Có Mức Độ = 1
                });
                options.AddPolicy("Mức 3", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.Requirements.Add(new UserAuthorize3());// Mức độ 1- Có Mức Độ = 2
                });
            });
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("V1", new OpenApiInfo { Title = "Swagger QuanLyNhaXe Solution", Version = "V1" });
            });
            services.AddTransient<IAuthorizationHandler, UserAuthorizationHandler>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IAuthoServicecs, AuthoService>();
            services.AddScoped<ILoaiXeService, LoaiXeService>();
            services.AddScoped<IStorageService, FileStorageService>();
            services.AddScoped<IImageUserService, ImageUserService>();
            services.AddScoped<IXeService, XeService>();
            services.AddScoped<ITuyenDuongService, TuyenDuongService>();
            services.AddScoped<IChuyenXeService, ChuyenXeService>();
            services.AddScoped<IVeXeSerVice, VeXeSerVice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/V1/swagger.json", "Swageer QuanLyNhaXe V1");
                });
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            //app.UseSwagger();

            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/V1/swagger.json","Swageer QuanLyNhaXe V1");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
