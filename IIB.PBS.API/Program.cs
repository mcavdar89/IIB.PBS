
using IIB.PBS.BL.Abstracts;
using IIB.PBS.BL.Concretes;
using IIB.PBS.DAL.Abstracts;
using IIB.PBS.DAL.Concretes;
using IIB.PBS.DAL.Contexts;
using IIB.PBS.Model.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//servisleri yönettiğimiz yer
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



#region IOC 
builder.Services.AddScoped<IPBSRepository,PBSRepository>();
builder.Services.AddScoped<IPersonelServis,PersonelServis>();
builder.Services.AddScoped<IAccountServis,AccountServis>();

builder.Services.AddDbContext<PBSContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("PBSConnection"));
});

builder.Services.AddAutoMapper(typeof(PBSProfile));


#endregion

var app = builder.Build();
//middleware ları yönettiğimiz yer


app.UseCors("AllowOrigin");


app.MapDefaultControllerRoute();


app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/ahmet", () => 9+5);

app.Run();




