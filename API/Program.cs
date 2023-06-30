using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

//Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["jwt:issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["jwt:audience"],

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))
        };
    });

builder.Services.AddCors(o => o.AddPolicy("angular", option =>
    option.WithOrigins("http://localhost:4200")
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader()
));

//BLL
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
//DAL
builder.Services.AddScoped<IUserRepository, UserRepository>(sp =>
    new UserRepository(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddScoped<IUser_StatsRepository, User_StatsRepository>(sp =>
    new User_StatsRepository(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddScoped<ISuccessRepository, SuccessRepository>(sp =>
    new SuccessRepository(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddScoped<IFriendRepository, FriendsRepository>(sp =>
    new FriendsRepository(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("angular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
