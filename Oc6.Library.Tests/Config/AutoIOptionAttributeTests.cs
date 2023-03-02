using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Oc6.Library.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Config
{
    public class AutoIOptionAttributeTests
    {
        [Fact]
        public void AddIConfigsFromAssembly()
        {
            TestSetting expected = new() { ParameterA = "Value A", ParameterB = "Value B" };

            IConfiguration configuration = GetConfigurationManager(expected);

            IServiceCollection services = new ServiceCollection();

            services = services.AddAutoIOptionsFromAssembly(configuration, typeof(TestSetting).Assembly);

            Validate(expected, services);
        }

        [Fact]
        public void AddAutoIOptionsFromCallingAssembly()
        {
            TestSetting expected = new() { ParameterA = "Value A", ParameterB = "Value B" };

            IConfiguration configuration = GetConfigurationManager(expected);

            IServiceCollection services = new ServiceCollection();

            services = services.AddAutoIOptionsFromCallingAssembly(configuration);

            Validate(expected, services);
        }

        [Fact]
        public void AddAutoIOptions()
        {
            TestSetting expected = new() { ParameterA = "Value A", ParameterB = "Value B" };

            IConfiguration configuration = GetConfigurationManager(expected);

            IServiceCollection services = new ServiceCollection();

            services = services.AddAutoIOptions<TestSetting>(configuration);

            Validate(expected, services);
        }

        [Fact]
        public void AddAutoIOptions_Throws_CustomAttributeFormatException()
        {
            TestSetting expected = new() { ParameterA = "Value A", ParameterB = "Value B" };

            IConfiguration configuration = GetConfigurationManager(expected);

            IServiceCollection services = new ServiceCollection();

            Assert.Throws<CustomAttributeFormatException>(() => services.AddAutoIOptions<object>(configuration));
        }

        private static void Validate(TestSetting expected, IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            IOptions<TestSetting>? options = serviceProvider.GetService<IOptions<TestSetting>>();

            Assert.NotNull(options);

            TestSetting? actual = options.Value;

            Assert.NotNull(actual);

            Assert.Equal(expected.ParameterA, actual.ParameterA);

            Assert.Equal(expected.ParameterB, actual.ParameterB);
        }

        private static IConfiguration GetConfigurationManager(TestSetting expected)
        {
            string configurationJson = $"{{\"TestSetting\":{{\"{nameof(expected.ParameterA)}\": \"{expected.ParameterA}\",\"{nameof(expected.ParameterB)}\": \"{expected.ParameterB}\"}}}}";

            using MemoryStream stream = new(Encoding.UTF8.GetBytes(configurationJson));

            ConfigurationManager configuration = new();

            return configuration.AddJsonStream(stream).Build();
        }

        [AutoIOptions("TestSetting")]
        public class TestSetting
        {
            public required string ParameterA { get; set; }

            public required string ParameterB { get; set; }
        }
    }
}
