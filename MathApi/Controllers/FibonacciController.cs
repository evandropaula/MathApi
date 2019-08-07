//-----------------------------------------------------------------------
// <copyright file="FibonacciController.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MathApi.Controllers
{
    using System.Collections.Generic;
    using System.Numerics;
    using Math.Core.Series;
    using MathApi.Common;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Fibonacci series API controller
    /// </summary>
    [Route("api/math/series/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        /// <summary>
        ///  Application insights telemetry client
        /// </summary>
        private readonly TelemetryClient telemetryClient = new TelemetryClient();

        /// <summary>
        /// Fibonacci series provider
        /// </summary>
        private readonly Fibonacci fibonacci = new Fibonacci();

        /// <summary>
        /// GET api/math/series/Fibonacci/5
        /// </summary>
        /// <param name="k">K nunmbers to be created in the Fibonacci series</param>
        /// <returns>Fibonacci series</returns>
        [HttpGet("{k:range(1, 30000)}")]
        public ActionResult<List<BigInteger>> GetSeries(int k)
        {
            using (IOperationHolder<RequestTelemetry> operation = telemetryClient.StartOperation<RequestTelemetry>("Get-Fibonacci-Series-Api"))
            {
                List<BigInteger> fibonacciSeries = fibonacci.GetSeries(k);

                operation.Telemetry.Success = true;
                operation.Telemetry.ResponseCode = Response.StatusCode.ToString();
                operation.Telemetry.Stop();

                ResponseHelper.AddHeaders(Response, operation.Telemetry);

                return fibonacciSeries;
            }
        }
    }
}
