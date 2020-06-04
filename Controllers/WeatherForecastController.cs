namespace DemoApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The weather forecast controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// The summaries.
        /// </summary>
        private static readonly string[] Summaries = new[]
                                                         {
                                                             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
                                                             "Balmy", "Hot", "Sweltering", "Scorching"
                                                         };

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger<WeatherForecastController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(
                index => new WeatherForecast
                             {
                                 Date = DateTime.Now.AddDays(index),
                                 TemperatureC = rng.Next(-20, 55),
                                 Summary = Summaries[rng.Next(Summaries.Length)]
                             }).ToArray();
        }

        /// <summary>
        /// The slow response.
        /// </summary>
        /// <param name="millisecondsDelay">
        /// The milliseconds delay.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("DelayedResponse")]
        public async Task<IActionResult> DelayedResponse(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            var message = new { message = $"{millisecondsDelay} ms delayed response." };
            return Ok(message);
        }
    }
}