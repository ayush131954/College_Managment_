
using College_Managment_Utility;
using College_Managment_Utility.CustomerDomain.Interface;
using College_Managment_Utility.CustomerDomain;
using Microsoft.Extensions.FileProviders;
using College_Managment_Utility.CustomerDomain.Interface;
using College_Managment_Utility.CustomerDomain;
using College_Management_DataAccess.Interface;
using College_Management_DataAccess.Repository;
using Microsoft.AspNetCore.Http.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//var builder = WebApplication.CreateBuilder(args);

// Register services in DI container
//builder.Services.AddScoped<IDepartmentMaster, DepartmentMaster>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

// Register other services as needed
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositories,CoreRepositories>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
                    builder.WithOrigins("http://localhost:5095", "http://localhost:4200", "https://localhost:4200")  // Allow your frontend's URL
                           .AllowAnyHeader()
                           .AllowAnyMethod().AllowAnyOrigin());
});

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
//});
builder.Services.AddDirectoryBrowser();
builder.Services.AddScoped<IUtilityHelper, UtilityHelper>();

//builder.Services.AddControllers().AddNewtonsoftJson();


//var app = builder.Build();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRouting();
    app.UseCors("AllowAll");
    app.UseStaticFiles();
    //app.UseStaticFiles(new StaticFileOptions
    //{
    //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ImageFile")),
    //    RequestPath = "/ImageFile"
    //});       

    //app.UseDirectoryBrowser(new DirectoryBrowserOptions
    //{
    //    FileProvider = new PhysicalFileProvider(
    //            Path.Combine(Directory.GetCurrentDirectory(), "ImageFile")),
    //    RequestPath = "/ImageFile"
    //});
}

    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
