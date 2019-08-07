//-----------------------------------------------------------------------
// <copyright file="FibonacciUnitTest.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Math.Core.UnitTest.Series
{
    using System.Collections.Generic;
    using System.Numerics;
    using Math.Core.Series;
    using NUnit.Framework;

    /// <summary>
    /// Fibonacci unit tests
    /// </summary>
    [TestFixture]
    [Author("Evandro Paula", "van.paula@gmail.com")]
    [Category("FibonacciUnsignedLong")]
    public class FibonacciUnitTest
    {
        /// <summary>
        /// Fibonacci provider
        /// </summary>
        private readonly Fibonacci fibonacci = new Fibonacci();

        /// <summary>
        /// Test when K is invalid and lower than 1
        /// </summary>
        /// <param name="k">Number of elements to generate the Fibonacci series for</param>
        [Test]
        public void GetSeriesWithKNegative([Values(-1, 0)]int k)
        {
            Assert.That(
                () => fibonacci.GetSeries(k), 
                Throws.ArgumentException.With.Message.Contains("K must be greater or equal than 1"));
        }

        /// <summary>
        /// Test when K is invalid and above upper bound limit (e.g. 50000)
        /// </summary>
        [Test]
        public void GetSeriesWithKGreaterThanMax()
        {
            Assert.That(
                () => fibonacci.GetSeries(Fibonacci.MaxK + 1), 
                Throws.ArgumentException.With.Message.Contains("K cannot be greater than"));
        }

        /// <summary>
        /// Test get Fibonacci series
        /// </summary>
        /// <param name="k">Number of elements to generate the Fibonacci series for</param>
        [Test]
        public void GetSeries([Values(1, 2, 5, 1000)] int k)
        {
            AssertSeries(fibonacci.GetSeries(k), k);
        }

        /// <summary>
        /// Assert Fibonacci series for a given K
        /// </summary>
        /// <param name="fibonacci">Fibonacci series</param>
        /// <param name="k">K nunmbers to be created in the Fibonacci series</param>
        private void AssertSeries(List<BigInteger> fibonacci, int k)
        {
            Assert.IsNotNull(fibonacci);
            Assert.IsNotEmpty(fibonacci);
            Assert.AreEqual(k, fibonacci.Count);

            for (int i = 0; i < fibonacci.Count; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual(BigInteger.Zero, fibonacci[i]);
                }
                else if (i == 1)
                {
                    Assert.AreEqual(BigInteger.One, fibonacci[i]);
                }
                else
                {
                    Assert.AreEqual(fibonacci[i - 1] + fibonacci[i - 2], fibonacci[i]);
                }
            }
        }
    }
}