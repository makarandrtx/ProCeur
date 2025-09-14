using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProCeur.API.Shared.Service;
using ProCeur.API.Shared.Service.JwtToken;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(builder.Configuration); //this is swagger with JWT authorization
builder.Services.AddApplicationLayer();
builder.Services.ConfigurePostgreSqlServer(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
