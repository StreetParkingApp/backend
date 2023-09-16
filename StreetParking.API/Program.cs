using Microsoft.EntityFrameworkCore;
using StreetParking.API.DbContexts;
using StreetParking.API.Services;


var builder = WebApplication.CreateBuilder(args);
// Add controllers with Accept header set to default json and add xml formatters


builder.Services.AddDbContext<StreetParkingContext>(dbContextOptions => 
    dbContextOptions.UseMySql(builder.Configuration["ConnectionStrings:StreetParkingDbConnectionString"], 
    ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:StreetParkingDbConnectionString"])));

builder.Services.AddScoped<IStreetParkingService, StreetParkingService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;

}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });

app.Run();
