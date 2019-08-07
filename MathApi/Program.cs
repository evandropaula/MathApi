//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MathApi
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// ASP.NET core program entry point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">Program arguments</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create web host builder
        /// </summary>
        /// <param name="args">Web host builder arguments</param>
        /// <returns>Web host builder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
