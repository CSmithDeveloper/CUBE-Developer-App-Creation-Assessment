// <copyright file="HomeController.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.UI.Models;
    using Newtonsoft.Json;
    using Self = HomeController;

    /// <summary>
    /// The Home controller.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The about page message.
        /// </summary>
        private const string AboutMessage = "CUBE Full Stack Developer App Creation Assessment.";

        /// <summary>
        /// The web API URL.
        /// </summary>
        private readonly Uri webApiUrl = new Uri("http://localhost:41139/");

        /// <summary>
        /// The Index action.
        /// </summary>
        /// <returns>
        /// The action result.
        /// </returns>
        public async Task<ActionResult> Index()
        {
            var homeViewModel = new HomeViewModel(new ConvertModel(), await this.GetAudit());

            return this.View(homeViewModel);
        }

        /// <summary>
        /// The Convert form action.
        /// </summary>
        /// <param name="from">The the convert from scale.</param>
        /// <param name="to">The the convert to scale.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="userName">The name of the user.</param>
        /// <returns>
        /// The form action result.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> Convert(TemperatureScale from, TemperatureScale to, decimal value, string userName)
        {
            string requestUri = $"api/Temperatures/Convert?From={from}&To={to}&Value={value}&UserName={userName}";
            
            var convertModel = new ConvertModel
            {
                From = from,
                To = to,
                Value = value,
                UserName = userName
            };
                       
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.webApiUrl;
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage responseMessage = await client.GetAsync(requestUri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var requestResponse = responseMessage.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<decimal>(requestResponse);
                    convertModel.ConvertedValue = result;
                }

                var homeViewModel = new HomeViewModel(convertModel, await this.GetAudit());

                return this.View("Index", homeViewModel);
            }
        }

        /// <summary>
        /// The About action.
        /// </summary>
        /// <returns>
        /// The action result.
        /// </returns>
        public ActionResult About()
        {
            ViewBag.Message = Self.AboutMessage;
            return this.View();
        }

        /// <summary>
        /// Gets the audit.
        /// </summary>
        /// <returns>
        /// The audit.
        /// </returns>
        private async Task<List<AuditModel>> GetAudit()
        {
            const string RequestUri = "api/Audit";

            var audit = new List<AuditModel>();
            using (var client = new HttpClient())
            {      
                client.BaseAddress = this.webApiUrl;
                client.DefaultRequestHeaders.Clear();      
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      
                HttpResponseMessage responseMessage = await client.GetAsync(RequestUri);   
                
                if (responseMessage.IsSuccessStatusCode)
                {      
                    string requestResponse = responseMessage.Content.ReadAsStringAsync().Result;      
                    audit = JsonConvert.DeserializeObject<List<AuditModel>>(requestResponse);
                }
            }

            return audit;
        }
    }
}