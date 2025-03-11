using Cassie.DependencyInjection.Extensions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Cassie.DependencyInjection.Extensions.Tests
{
    public interface IMockTransientService { }
    public interface IMockScopedService { }
    public interface IMockSingletonService { }
    //public interface IMockUnknownService { }
    //public interface IMultipleService { }
    

    public class MockTransientService : IMockTransientService, ITransientService { }
    public class MockScopedService : IMockScopedService, IScopedService { }
    public class MockSingletonService : IMockSingletonService, ISingletonService { }
    //public class MockUnknownService : IMockUnknownService { }
    //public class MultipleLifetimeService : IMultipleService, ITransientService, IScopedService { }

    public class RegistrationDITests
    {
        public RegistrationDITests()
        {
        }

        [Fact]
        public void RegisterDependencies_ShouldRegisterTransientService()
        {
            // Arrange
            var _services = CreateServiceCollection();
            var assembly = typeof(MockTransientService).Assembly;

            // Act
            _services.RegisterDependencies(assembly);
            var serviceProvider = _services.BuildServiceProvider();

            // Assert
            var service1 = serviceProvider.GetService<IMockTransientService>();
            var service2 = serviceProvider.GetService<IMockTransientService>();

            Assert.NotNull(service1);
            Assert.NotNull(service2);
            Assert.NotSame(service1, service2);
        }

        [Fact]
        public void RegisterDependencies_ShouldRegisterScopedService()
        {
            var _services = CreateServiceCollection();
            var assembly = typeof(MockScopedService).Assembly;
            _services.RegisterDependencies(assembly);
            var serviceProvider = _services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var service1 = scope.ServiceProvider.GetService<IMockScopedService>();
                var service2 = scope.ServiceProvider.GetService<IMockScopedService>();

                Assert.NotNull(service1);
                Assert.NotNull(service2);
                Assert.Same(service1, service2);
            }
        }

        [Fact]
        public void RegisterDependencies_ShouldRegisterSingletonService()
        {
            var _services = CreateServiceCollection();
            var assembly = typeof(MockSingletonService).Assembly;
            _services.RegisterDependencies(assembly);
            var serviceProvider = _services.BuildServiceProvider();

            var service1 = serviceProvider.GetService<IMockSingletonService>();
            var service2 = serviceProvider.GetService<IMockSingletonService>();

            Assert.NotNull(service1);
            Assert.NotNull(service2);
            Assert.Same(service1, service2);
        }

        //[Fact] TODO: add test for exception case later
        //public void RegisterDependencies_ShouldThrowException_WhenClassDoesNotImplementValidDIInterface()
        //{
        //    // Arrange
        //    var _services = CreateServiceCollection();
        //    var assembly = typeof(MockUnknownService).Assembly;

        //    // Act & Assert
        //    var exception = Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        _services.RegisterDependencies(assembly);
        //    });

        //    Assert.Equal("The class 'MockUnknownService' does not implement a valid DI interface (ITransientService, IScopedService, or ISingletonService).", exception.Message);
        //}

        //[Fact]
        //public void RegisterDependencies_ShouldThrowException_WhenClassImplementsMultipleLifetimes()
        //{
        //    // Arrange
        //    var _services = CreateServiceCollection();
        //    var assembly = typeof(MultipleLifetimeService).Assembly;

        //    // Act & Assert
        //    var exception = Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        _services.RegisterDependencies(assembly);
        //    });

        //    Assert.Equal("The class 'MultipleLifetimeService' implements multiple DI lifetimes (ITransientService, IScopedService, ISingletonService), which is not allowed. A class can only be registered with a single lifetime.", exception.Message);
        //}

        private IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }
    }
}
