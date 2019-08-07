//-----------------------------------------------------------------------
// <copyright file="Fibonacci.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Math.Core.Series
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Microsoft.ApplicationInsights;

    /// <summary>
    /// Fibonacci provider
    /// </summary>
    public sealed class Fibonacci
    {
        /// <summary>
        /// Max K
        /// </summary>
        public const int MaxK = 30000;

        /// <summary>
        /// Application insights telemetry client
        /// </summary>
        private readonly TelemetryClient telemetryClient = new TelemetryClient();

        /// <summary>
        /// Get Fibonacci series up to the upper limit defined by MaxK constant
        /// </summary>
        /// <param name="k">Number of elements to generate the Fibonacci series for</param>
        /// <returns>Fibonacci series</returns>
        /// <remarks>
        /// Big integer is supported by major programming languages, which are possible clients:
        ///     C#      https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger?view=netframework-4.8
        ///     Java    https://docs.oracle.com/javase/7/docs/api/java/math/BigInteger.html
        ///     Node.js  https://www.npmjs.com/package/big-integer
        ///     Python  https://docs.python.org/3/library/stdtypes.html
        ///     Ruby    https://ruby-doc.org/core-2.6.1/Integer.html
        /// </remarks>
        public List<BigInteger> GetSeries(int k)
        {
            try
            {
                if (k < 1)
                {
                    throw new ArgumentException("K must be greater or equal than 1.");
                }

                if (k > MaxK)
                {
                    throw new ArgumentException($"K cannot be greater than {MaxK}");
                }

                List<BigInteger> fibonacci = new List<BigInteger>(k) { 0 };

                if (k > 1)
                {
                    fibonacci.Add(1);

                    for (int i = 2; i < k; i++)
                    {
                        fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
                    }
                }

                telemetryClient.TrackEvent("Get-Fibonacci-Series-Completed", new Dictionary<string, string> { { "k", k.ToString() } });

                return fibonacci;
            }
            catch (Exception ex)
            {
                telemetryClient.TrackException(ex, new Dictionary<string, string> { { "k", k.ToString() } });
                throw;
            }
        }        
    }
}
