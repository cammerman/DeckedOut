using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Reflection;
using Jessica;
using Jessica.ViewEngine.Razor;
using Jessica.ViewEngine;
using DeckedOut.Persistence;
using DeckedOut.Domain;
using MarkdownSharp;

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
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.GetInterfaces().Any())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeckRepository>()
                .As<IDeckRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RazorViewEngine>().AsSelf();

            builder.RegisterType<Markdown>().AsSelf();

            return builder.Build();
        }
    }
}