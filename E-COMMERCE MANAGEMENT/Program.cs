
using System.Text;
using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Mapping;
using E_COMMERCE_MANAGEMENT.Repos.Impelementation;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using E_COMMERCE_MANAGEMENT.UnitOfWorkkk;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace E_COMMERCE_MANAGEMENT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddScoped(typeof(IGenaricRepo<>),typeof(GenaricRepo<>));
            builder.Services.AddScoped<IUnitOWork,UnitOfWork>();

            builder.Services.AddScoped<IUserCustom,UserCustom>();

            builder.Services.AddScoped<ICatigoryCustom,CatigoryCustom>();
            builder.Services.AddScoped<IProductCustom,ProductCustom>();
            builder.Services.AddScoped<IOrdeCustom,OrderCustom>();
            builder.Services.AddAutoMapper(typeof(AllProfail));

            var key = Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]);
            builder.Services.AddAuthentication(option =>
            {

                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidAudience = builder.Configuration["jwt:audience"],
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["jwt:issuer"],
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
