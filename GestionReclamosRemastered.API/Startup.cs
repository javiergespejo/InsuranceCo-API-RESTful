using AutoMapper;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Core.Services;
using GestionReclamosRemastered.Infrastructure.Data;
using GestionReclamosRemastered.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GestionReclamosRemastered.API
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
            // Database connection
            services.AddDbContext<GestionReclamosContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("GestionReclamos"))
               );
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // NewtonsoftJson (httppatch enabled)
            // LoopHandler
            services.AddControllers().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            // User
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Reclamante
            services.AddTransient<IReclamanteService, ReclamanteService>();
            services.AddTransient<IReclamanteRepository, ReclamanteRepository>();
            // Siniestro
            services.AddTransient<ISiniestroRepository, SiniestroRepository>();
            services.AddTransient<ISiniestroService, SiniestroService>();
            // Recupero
            services.AddTransient<IRecuperoRepository, RecuperoRepository>();
            // Representante
            services.AddTransient<IRepresentativeRepository, RepresentativeRepository>();
            services.AddTransient<IRepresentativeService, RepresentativeService>();
            // GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Monto
            services.AddTransient<IMontoRepository, MontoRepository>();
            services.AddTransient<IMontoService, MontoService>();
            // Concepto Pago
            services.AddTransient<IConceptoPagoRepository, ConceptoPagoRepository>();
            services.AddTransient<IConceptoPagoService, ConceptoPagoService>();
            // Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };

            });
                        
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion Reclamos API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth32",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestion Reclamos API");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
