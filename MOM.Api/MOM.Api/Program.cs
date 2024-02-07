using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MOM.BasicAuthentication.Authentication.Basic;
using MOM.BasicAuthentication.Authentication.Basic.Attributes;
using MOM.Business.IServices;
using MOM.Business.Services;
using MOM.Domain.Context;
using MOM.Domain.Entities;
using MOM.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//----- some option added to "AddSwaggerGen" by Omid :) ------
// AddSecurityDefinition && AddSecurityRequirement
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(BasicAuthenticationDefaults.AuthenticationScheme,
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "Basic",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Basic Authorization Header"
        });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = BasicAuthenticationDefaults.AuthenticationScheme
                }  
            },
            new string[]{"MOM-Admin"}
        }
    });
});

//-----this block of code added by Omid :) ------
// Basic Authentication
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
        BasicAuthenticationDefaults.AuthenticationScheme, null
    );

//-----this block of code added by Omid :) ------
// dependency injection
builder.Services.AddScoped<IGenericRepository<IkcopersonInfo>, GenericRepository<IkcopersonInfo>>();
builder.Services.AddScoped<IPersonInfoService, PersonInfoService>();

//-----this block of code added by Omid :) ------
// "dbCintext" is implemented in the 'appsettings.json' file , by Omid :)
builder.Services.AddDbContext<MOM_Context>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("dbContext"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();