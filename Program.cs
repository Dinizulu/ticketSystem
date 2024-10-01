
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ticketSystem.Data;
using ticketSystem.DTOs.User;
using ticketSystem.Interfaces;
using ticketSystem.Models;
using ticketSystem.Profiles;
using ticketSystem.Repository;

namespace ticketSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ticketDb")));
            //Configuring Authentication
            builder.Services.AddIdentity<AppUser, IdentityRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            }).AddEntityFrameworkStores<AppDbContext>();
            //Adding schemas
            builder.Services.AddAuthentication(options =>
            options.DefaultAuthenticateScheme =
            options.DefaultScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme
            ).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"]))
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Adding auto Mapper 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Adding dependancy injection
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IbugRepository,BugRepository>();
            builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.UseAuthorization();

            app.Run();
        }
    }
}
