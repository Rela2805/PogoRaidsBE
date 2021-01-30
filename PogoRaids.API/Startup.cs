using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PogoRaids.API.Services;
using PogoRaidsBackend.Helpers;
using PogoRaidsBackend.Repository;
using PogoRaidsBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<INHibernateHelper, DatabaseNHibernateHelper>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IDifficultyRepository, DifficultyRepository>();
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IRaidRepository, RaidRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPokemonService, PokemonService>();
            services.AddTransient<IRaidService, RaidService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IDifficultyService, DifficultyService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
