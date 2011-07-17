using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Reflection;
using Jessica;
using Jessica.ViewEngine.Razor;
using Jessica.ViewEngine;

namespace DeckedOut.Infrastructure
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.BaseType == typeof(JessModule))
                .AsSelf();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.GetInterfaces().Any())
                .AsImplementedInterfaces();

            builder.RegisterType<RazorViewEngine>().AsSelf();

            return builder.Build();
        }
    }
}