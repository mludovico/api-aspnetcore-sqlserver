using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Minha1Conexao.Data;
using Minha1Conexao.Data.Interface;
using Minha1Conexao.Data.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Minha1Conexao
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaProfessorRepository, TurmaProfessorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("sqlserver"))
            );

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto Minha primeira conexão",
                    Description = "Meu projeto fantástico de api de escola com .NET",
                    TermsOfService = new Uri("https://www.microsoft.com/fwlink/?LinkID=206977"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcelo",
                        Email = "maludovico@gmail.com",
                        Url = new Uri("https://www.microsoft.com/learn")
                    }
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            var key = Encoding.ASCII.GetBytes(Configuracoes.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("v1/swagger.json", "Minha Conexão");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
