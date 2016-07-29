using Autofac;
using NUnit.Framework;

namespace WhatTheAutofac
{
    public class Resolving_Instances_Where_One_Interface_Is_Implemented
    {
        private ContainerBuilder _containerBuilder;
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _containerBuilder =  new ContainerBuilder();
            _containerBuilder.RegisterType<ImplementOneInterface>().As<IFirstInterface>();

            _container = _containerBuilder.Build();
        }

        [Test]
        public void Can_Resolve_By_First_Interface()
        {
            var resolvedInstance = _container.Resolve<IFirstInterface>();

            Assert.That(resolvedInstance, Is.TypeOf<ImplementOneInterface>());
        }
    }
}
