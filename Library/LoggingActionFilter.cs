namespace DemoApi.Library
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;

    /// <summary>
    /// The logging action filter.
    /// </summary>
    public class LoggingActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingActionFilter"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' executing.");
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            var traceId = Activity.Current?.Id ?? context?.HttpContext?.TraceIdentifier;
            sb.AppendLine($"Activity.Current?.Id: {Activity.Current?.Id}");
            sb.AppendLine($"TraceIdentifier: {context?.HttpContext?.TraceIdentifier}");

            HttpRequest request = context.HttpContext?.Request;
            sb.AppendLine();
            sb.AppendLine($"{request.Method} {request.Host}{request.Path}");
            sb.AppendLine();
            IHeaderDictionary headers = request.Headers;

            if (headers != null)
            {
                foreach (KeyValuePair<string, StringValues> header in headers)
                {
                    sb.AppendLine($"{header.Key}: {header.Value}");
                }
            }

            this.logger.LogInformation(sb.ToString());
        }

        /// <summary>
        /// The on action executed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' completed.");
        }
    }
}
