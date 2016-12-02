using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wichtel.Common;
using Wichtel.WebApi.Controllers;
using Xunit;

namespace Wichtel.WebApi.Tests
{
    public class WichtelnControllerTests
    {
        [Fact]
        public void Index_ReturnsAWinner()
        {
            var mockRepository = new MockRepository();
            var mockLoggerFactory = new MockLoggerFactory();
            var controller = new WichtelnController(mockRepository, mockLoggerFactory);

            var result = controller.Get();
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.NotNull(jsonResult);
            Assert.NotNull(jsonResult.Value);
            Assert.IsType<Winner>(jsonResult.Value);
            var theWinner = Assert.IsAssignableFrom<Winner>(jsonResult.Value);
            Assert.Equal("@writeline", theWinner.Who);
        }

        public class MockRepository : IRepository
        {
            public Winner LookupWinner()
            {
                return new Winner
                {
                    Who = "@writeline",
                    What = "A simple tweet!"                
                };
            }
        }

        public class MockLoggerFactory : ILoggerFactory
        {
            public void AddProvider(ILoggerProvider provider)
            {
            }

            public ILogger CreateLogger(string categoryName)
            {
                return new MockLogger();
            }

            public void Dispose()
            {
            }
        }

        public class MockLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
            }
        }
    }
}
