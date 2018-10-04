using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Logic.BL.Repositories;
using Logic.BL.Services;
using Logic.BL.Utils;
using AutoMapper;
using Api.Customers.Application.Assembler;
using Logic.BL.Common.Application;
using Logic.BL.Common.Infrastructure.Persistence.NHibernate;
using Logic.BL.Customers.Domain.Repository;

namespace Api
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();

            //services.AddSingleton(new SessionFactory(Configuration["ConnectionString"]));
            //services.AddScoped<UnitOfWork>();
            //services.AddTransient<MovieRepository>();
            //services.AddTransient<CustomerRepository>();
            //services.AddTransient<MovieService>();
            //services.AddTransient<CustomerService>();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("SQL_STRCON_PATTERNS")));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();
            services.AddSingleton(new CustomerCreateAssembler(mapper));
            //services.AddSingleton(new MovieAssembler(mapper));
            services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();
            services.AddTransient<ICustomerRepository, CustomerRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new CustomerRepository((UnitOfWorkNHibernate)unitOfWork);
            });
            //services.AddTransient<ICustomerRepository, CustomerNHibernateRepository>((ctx) =>
            //{
            //    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
            //    return new CustomerNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            //});
            //services.AddTransient<IMovieRepository, MovieNHibernateRepository>((ctx) =>
            //{
            //    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
            //    return new MovieNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
