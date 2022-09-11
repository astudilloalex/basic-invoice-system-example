using InvoiceSystem.APPLICATION.Services;
using InvoiceSystem.INFRASTRUCTURE.Connections;
using InvoiceSystem.INFRASTRUCTURE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

string _swaggerDocName = "v1.0";

#region Declare builder for the app.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region Declare all repositories sorted alphabetically
builder.Services.AddScoped<CountryRepository>();
#endregion

#region Declare all custom database services sorted alphabetically
builder.Services.AddScoped<CountryService>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(_swaggerDocName, new OpenApiInfo { Title = "Invoice API v1.0", Version = "1.0" });
});

// Configure PostgreSQL database context to work with entity framework
builder.Services.AddDbContext<PostgreSQLContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
});

// Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.SetIsOriginAllowed(_ => true);
        builder.AllowCredentials();
    });
});
#endregion

#region Build the app.
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/" + _swaggerDocName + "/swagger.json", "Cities V1.0");
    });
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors("EnableCORS");
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
#endregion