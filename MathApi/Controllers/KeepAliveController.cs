//-----------------------------------------------------------------------
// <copyright file="KeepAliveController.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MathApi.Controllers
{
    using System.Net;
    using MathApi.Common;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Keep Alive API controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class KeepAliveController : ControllerBase
    {
        /// <summary>
        /// Application insights telemetry client
        /// </summary>
        private readonly TelemetryClient telemetryClient = new TelemetryClient();

        /// <summary>
        /// Keep Alive API, which is:
        ///  a) Often used by monitoring tools to detect connectivity issues.
        ///  b) Load balancers to determine connectivity issues and determined to take an instance out of rotation or not.
        /// </summary>
        /// <remarks>
        /// This implementation should often be lightweight since its call frequency is usually high to support fast recovery.
        /// </remarks>
        [HttpGet]
        public void Ping()
        {
            using (var operation = telemetryClient.StartOperation<RequestTelemetry>("Keep-Alive-Api"))
            {
                operation.Telemetry.ResponseCode = HttpStatusCode.OK.ToString();
                operation.Telemetry.Success = true;

                operation.Telemetry.Stop();

                ResponseHelper.AddHeaders(Response, operation.Telemetry);
            }
        }
    }
}
