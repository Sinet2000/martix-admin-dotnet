using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder(args);
bld.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

var app = bld.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(
        c =>
        {
            c.Errors.UseProblemDetails();
        })
    .UseSwaggerGen();
app.Run();

namespace Martix.Api
{
    public partial class Program;
}