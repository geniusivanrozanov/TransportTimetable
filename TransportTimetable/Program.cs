using Microsoft.AspNetCore.HttpOverrides;
using TransportTimetable.BLL.Extensions;
using TransportTimetable.DAL.Extensions;
using TransportTimetable.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();

builder.Services.AddBllServices();
builder.Services.AddRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}
app.UseCors("CorsPolicy");

app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthorization();

app.MapControllers();

app.Services.MigrateDatabase();

app.Run();