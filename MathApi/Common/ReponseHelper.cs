//-----------------------------------------------------------------------
// <copyright file="ResponseHelper.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MathApi.Common
{
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Response helper class
    /// </summary>
    internal sealed class ResponseHelper
    {
        /// <summary>
        /// Add default headers to response object
        /// </summary>
        /// <param name="response">HTTP Response</param>
        /// <param name="requestTelemetry">Request telemetry</param>
        public static void AddHeaders(HttpResponse response, RequestTelemetry requestTelemetry)
        {
            response.Headers.Add("X-MathApi-Request-Id", requestTelemetry.Id);
            response.Headers.Add("X-MathApi-Request-Timestamp", requestTelemetry.Timestamp.ToString());
            response.Headers.Add("X-MathApi-Server-ExecutionTimeMs", requestTelemetry.Duration.TotalMilliseconds.ToString());
        }
    }
}
