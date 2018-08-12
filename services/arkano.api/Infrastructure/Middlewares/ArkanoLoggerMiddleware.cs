namespace arkano.api.Infrastructure.Middlewares
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using arkano.common.exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class ArkanoLoggerMiddleware
    {
        public ArkanoLoggerMiddleware(RequestDelegate next, ILogger<ArkanoLoggerMiddleware> logger)
        {
            this.Next = next;
            this.Logger = logger;
        }

        private RequestDelegate Next { get; }

        private ILogger<ArkanoLoggerMiddleware> Logger { get; }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch watch = Stopwatch.StartNew();
            string eventName = string.Empty;
            try
            {
                await this.Next(context).ConfigureAwait(true);
            }
            catch (ArkanoException handledException)
            {
                this.Logger.LogError(handledException, "HANDLED ERROR");
                throw handledException;
            }
            catch (Exception unhandledException)
            {
                this.Logger.LogCritical(unhandledException, "UNHANDLED ERROR");
                throw unhandledException;
            }
            finally
            {
                watch.Stop();
                this.Logger.LogInformation($"{eventName} - Duration: {watch.ElapsedMilliseconds} milliseconds");
            }
        }
    }
}
