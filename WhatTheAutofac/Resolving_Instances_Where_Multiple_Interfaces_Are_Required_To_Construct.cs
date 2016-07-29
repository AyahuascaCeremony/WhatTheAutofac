using Autofac;
using Autofac.Core;
using NUnit.Framework;

namespace WhatTheAutofac
{
    public class Resolving_Instances_Where_Multiple_Interfaces_Are_Required_To_Construct
    {
        private ContainerBuilder _containerBuilder;
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<RequiresMultipleInterfaces>().As<IRequireMultipleInterfaces>();
            _containerBuilder.RegisterType<ImplementBothInterfaces>().AsImplementedInterfaces();
//            _containerBuilder.RegisterType<RequiresMultipleInterfaces>().As<IRequireMultipleInterfaces>();


            //            _containerBuilder.RegisterType<ImplementBothInterfaces>().AsImplementedInterfaces();


            _container = _containerBuilder.Build();
        }

        [Test]
        public void Will_Fail_When_Resolving_Instance()
        {
            var requireMultipleInterfaces = _container.Resolve<IRequireMultipleInterfaces>();
            Assert.That(requireMultipleInterfaces, Is.TypeOf<RequiresMultipleInterfaces>());
        }
    }
}
