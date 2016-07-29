using System.Collections;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;

namespace WhatTheAutofac
{
    public class Resolving_Instances_Where_Multiple_Interfaces_Are_Implemented
    {
        private ContainerBuilder _containerBuilder;
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _containerBuilder =  new ContainerBuilder();
//            _containerBuilder.RegisterType<ImplementBothInterfaces>().As<IFirstInterface>();
//            _containerBuilder.RegisterType<ImplementBothInterfaces>().As<ISecondInterface>();
            _containerBuilder.RegisterType<ImplementsCommonInterface>().As<IFirstInterface>();
            _containerBuilder.RegisterType<ImplementBothInterfaces>().As<IFirstInterface>();

            //            _containerBuilder.RegisterType<ImplementsCommonInterface>().As<ICommonInterface>();

            _container = _containerBuilder.Build();
        }

        [Test]
        public void Can_Resolve_By_First_Interface()
        {
            var resolvedInstance = _container.Resolve<IFirstInterface>();

            var resolvedInstances = _container.Resolve<IEnumerable<IFirstInterface>>();

            Assert.That(resolvedInstance, Is.TypeOf<ImplementBothInterfaces>());
        }

        [Test]
        public void Can_Resolve_By_Second_Interface()
        {
            var resolvedInstance = _container.Resolve<ISecondInterface>();

            Assert.That(resolvedInstance, Is.TypeOf<ImplementBothInterfaces>());
        }

        [Test]
        public void Can_Resolve_By_Deep_Implemented_Interface()
        {
            var resolvedInstance = _container.Resolve<ISecondInterface>();

            Assert.That(resolvedInstance, Is.TypeOf<ImplementsCommonInterface>());
        }

        [Test]
        public void Can_Resolve_By_TopLevel_Implemented_Interface()
        {
            var resolvedInstance = _container.Resolve<ICommonInterface>();

            Assert.That(resolvedInstance, Is.TypeOf<ImplementsCommonInterface>());
        }
    }
}
