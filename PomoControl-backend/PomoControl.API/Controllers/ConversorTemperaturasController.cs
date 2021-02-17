using System;
using Microsoft.AspNetCore.Mvc;
using PomoControl.API.Controllers;

namespace APITemperatura.Controllers
{
    [Route("api/[controller]")]
    public class ConversorTemperaturasController : PomoController
    {
        /// <summary>
        /// Transforma uma temperatura em Fahrenheit para o equivalente
        /// nas escalas Celsius e Kelvin.
        /// </summary>
        /// <param name="temperatura">Temperatura em Fahrenheit</param>
        /// <returns>Objeto contendo valores para uma temperatura
        /// nas escalas Fahrenheit, Celsius e Kelvin.</returns>
        [HttpGet("Fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(double temperatura)
        {
            //var valorFahrenheit = temperatura;
            //double ValorKelvin = 0;
            //var valorCelsius =
            //    Math.Round((temperatura - 32.0) / 1.8, 2);
            //valorKelvin = valorCelsius + 273.15;

            return new { Temp = temperatura };
        }
    }
}