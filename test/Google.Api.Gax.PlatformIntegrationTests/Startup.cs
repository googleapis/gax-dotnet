/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Linq;

namespace Google.Api.Gax.PlatformIntegrationTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var platform = await Google.Api.Gax.Platform.InstanceAsync();
                var envs = Environment.GetEnvironmentVariables();
                // Output a the detected platform, the all environment variables.
                string output = envs.Cast<DictionaryEntry>()
                    .Select(x => new { key = x.Key.ToString(), value = x.Value.ToString() })
                    .OrderBy(x => x.key)
                    .Aggregate($"{platform.Type}\n{platform}\n\n", (acc, x) => acc + $"[{x.key}]: '{x.value}'\n");
                await context.Response.WriteAsync(output);
            });
        }
    }
}
