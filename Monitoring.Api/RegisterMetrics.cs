using App.Metrics;
using App.Metrics.Counter;

namespace Monitoring.Api
{
    public class RegisterMetrics
    {
        public static CounterOptions GetWeatherForecasts => new CounterOptions
        {
            Name = "Getting WeatherForecasts",
            Context = "WeatherForecastController",
            MeasurementUnit = Unit.Calls
        };
    }
}