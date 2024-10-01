﻿using Wolverine.Http;

namespace CritterStack.API.Endpoints;

public static class WeatherForecastEndpoint
{
    [WolverineGet("api/weatherforecast")]
    public static WeatherForecast[] GetWeatherForecast()
    {
        var summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }

}