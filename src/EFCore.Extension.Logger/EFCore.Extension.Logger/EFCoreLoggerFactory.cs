using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EFCore.Extension.Logger
{
    public class EfCoreLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EfCoreLogger(categoryName);//创建EFLogger类的实例
        }

        public void Dispose()
        {

        }
    }

    public class EfCoreLogger : ILogger
    {
        private readonly string _categoryName;

        public EfCoreLogger(string categoryName) => this._categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
            if (_categoryName == DbLoggerCategory.Database.Command.Name
                && logLevel == LogLevel.Information) {
                var logContent = formatter(state, exception);
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }

    public static class EFCoreLoggerExtensions
    {
        public static DbContextOptionsBuilder UseEFCoreLogger(this DbContextOptionsBuilder builder)
        {
            return builder.UseLoggerFactory(new EfCoreLoggerFactory());
        }
    }
}
