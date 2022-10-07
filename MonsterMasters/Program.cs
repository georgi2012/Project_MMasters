using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MonsterMasters.Core.Orbs;
using MonsterMasters.Data.Contracts;
using MonsterMasters.Data.Contracts.Orbs;
using MonsterMasters.Data.Monsters;
using MonsterMasters.Data.Orbs;
using RegisterAndLoginApp.Api.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthenticationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});
//builder.Services.AddMvc();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddScoped<AuthenticationContext>();
builder.Services.AddScoped<IMonsterFactory,MonsterFactory>();
builder.Services.AddScoped<IOrbOpener, OrbOpener>();
//inject configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 4;
});

//builder.Services.Configure<AuthenticationContext>(opt =>
//{
//    if(opt.Orb.ToList().Count == 0)
//    {
//        opt.Orb.AddRangeAsync(new Orb[]
//        {
//            new BasicOrb(),
//            new RareOrb(),
//            new LuckyOrb()
//        });
//    }
//});


builder.Services.AddCors();

var key = Encoding.UTF8.GetBytes(
    builder.Configuration["AppSettings:JWTSecret"].ToString());

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;//not only requests of type https
    x.SaveToken = false;//we dont save it here
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero//expiration time, no timezone difference
    };
});

var app = builder.Build();

//^injection for UserManager, SignInManager
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader().AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.Run();
