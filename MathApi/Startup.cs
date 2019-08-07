//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Evandro">
//     Copyright (c) Evandro All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MathApi
{
    using System.IO.Compression;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// ASP.NET Core startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">ASP.NET Core configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets ASP.NET Core configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Collection of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Telemetry
            services.AddApplicationInsightsTelemetry();

            // Compression
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Detailed exceptiokn information is ONLY shared while in development mode
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
