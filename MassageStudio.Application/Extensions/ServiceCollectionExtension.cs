using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassageStudio.Application.ApplicationUser;
using MassageStudio.Application.Mappings;
using MassageStudio.Application.Types.Commands.AddType;
using MassageStudio.MVC.Areas.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Extensions
{
    public static  class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(AddTypeCommand));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new ApplicationMapper(userContext));
            }).CreateMapper()
            );
            services.AddAutoMapper(typeof(ApplicationMapper));
            services.AddValidatorsFromAssemblyContaining<AddTypeCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddTransient<IEmailSender, EmailSender>(provider => new EmailSender(configuration));
        }
    }
}
