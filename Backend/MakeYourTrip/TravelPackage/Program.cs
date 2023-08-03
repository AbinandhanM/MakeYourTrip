using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TravelPackage.Models;
using TravelPackage.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TravelPackage.Exceptions;
using System;
using TravelPackage.Models.Context;
using TourPackage.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace TourPackage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TourContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
            });
            builder.Services.AddSwaggerGen(c => {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                     {
                         {
                            new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                            new string[] {}
                         }
                 });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactCors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });




            builder.Services.AddScoped<IRepo<Destination, int>, DestinationRepo>();
            builder.Services.AddScoped<IRepo<Exclusions, int>, ExclusionsRepo>();
            builder.Services.AddScoped<IRepo<Inclusions,int>,InclusionsRepo>(); 
            builder.Services.AddScoped<IRepo<TourDetails, int>, TourDetailsRepo>();
            builder.Services.AddScoped<IRepo<TourDestination, int>, TourDestinationRepo>();
            builder.Services.AddScoped<IRepo<TourExclusion, int>, TourExclusionRepo>();
            builder.Services.AddScoped<IRepo<TourInclusion, int>, TourInclusionRepo>();
            builder.Services.AddScoped<IRepo<TourDate, int>,TourDatesRepo>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors("ReactCors");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}