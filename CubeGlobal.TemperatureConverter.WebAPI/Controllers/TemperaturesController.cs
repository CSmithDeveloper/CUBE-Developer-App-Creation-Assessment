// <copyright file="TemperaturesController.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.WebAPI.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.ServiceContracts;

    /// <summary>
    /// The Temperatures Controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class TemperaturesController : ApiController
    {
        /// <summary>
        /// The temperature converter service.
        /// </summary>
        private readonly ITemperatureConverterService temperatureConverterService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperaturesController"/> class.
        /// </summary>
        /// <param name="temperatureConverterService">The temperature converter service.</param>
        public TemperaturesController(ITemperatureConverterService temperatureConverterService)
        {
            this.temperatureConverterService = temperatureConverterService;
        }

        /// <summary>
        /// Converts the temperature.
        /// </summary>
        /// <param name="convertFromScale">The convert from scale.</param>
        /// <param name="convertToScale">The convert to scale.</param>
        /// <param name="conversionValue">The conversion value.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// The converted temperature.
        /// </returns>
        [HttpGet]
        [Route("api/Temperatures/Convert")]
        public IHttpActionResult ConvertTemperature([FromUri(Name = "From")]TemperatureScale convertFromScale, [FromUri(Name = "To")]TemperatureScale convertToScale, [FromUri(Name = "Value")]decimal conversionValue, [FromUri(Name = "UserName")]string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return this.ResponseMessage(this.Request.CreateResponse(HttpStatusCode.BadRequest, "A UserName must be provided."));
            }
            
            decimal convertedTemperature = this.temperatureConverterService.ConvertTemperature(convertFromScale, convertToScale, conversionValue, userName);
            convertedTemperature = Math.Round(convertedTemperature, 4);

            return this.ResponseMessage(this.Request.CreateResponse(HttpStatusCode.OK, convertedTemperature));
        }
    }
}