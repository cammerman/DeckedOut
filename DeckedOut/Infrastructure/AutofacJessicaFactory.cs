using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica.Factory;
using Autofac;

namespace DeckedOut.Infrastructure
{
    public class AutofacJessicaFactory : IJessicaFactory
    {
        protected IContainer Container { get; private set; }

        public AutofacJessicaFactory(IContainer container)
        {
            Container = container;
        }

        public object CreateInstance(Type type)
        {
            return Container.Resolve(type);
        }
    }
}