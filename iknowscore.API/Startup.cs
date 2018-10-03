using System;
using System.Text;
using AutoMapper;
using iknowscore.DomainModel.Models;
using iknowscore.Repositories.Interfaces;
using iknowscore.Repositories.Repositories;
using iknowscore.Services;
using iknowscore.Services.Interfaces;
using iknowscore.Services.ViewModels.Maps;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace iknowscore.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddDbContext<iknowscoreContext>(options => options
                        .UseSqlServer(Configuration.GetConnectionString("iknowscore")));

            RegisterRepositories(services);
            RegisterServices(services);

            // Job to send messages
            services.AddSingleton<IHostedService, MessageSenderTimedHostedService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowPublic",
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:57380")
                            //.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerfactory, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors("AllowPublic");
            app.UseMvc();

            // Automapper Configuration
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITournamentService, TournamentService>();
            services.AddTransient<IForecastService, ForecastService>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddTransient<IMessageNotificationService, MessageNotificationService>();
            services.AddTransient<IMessageSenderService, SendGridMessageSenderService>();
            services.AddTransient<IMessageStorageService, DatabaseMessageStorageService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<Player>, Repository<Player>>();
            services.AddTransient<IRepository<Team>, Repository<Team>>();
            services.AddTransient<ITournamentRepository, TournamentRepository>();
            services.AddTransient<IRepository<Forecast>, Repository<Forecast>>();
            services.AddTransient<IRepository<Template>, Repository<Template>>();
            services.AddTransient<IRepository<PrimaryLanguage>, Repository<PrimaryLanguage>>();
            services.AddTransient<IRepository<Room>, Repository<Room>>();
            services.AddTransient<IRepository<Message>, Repository<Message>>();
            services.AddTransient<IRepository<Room>, Repository<Room>>();
        }
    }
}
