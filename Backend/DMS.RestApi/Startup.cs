using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Shared;
using DMS.Workflows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DMS.Core.Models;
using System.Threading;
using DMS.RestApi.Chat;
using CloudDinary_BaseUsing.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DMS.RestApi
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {

      Configuration = configuration;
      var couchbaseSettings = new CouchbaseSettings();
      Configuration.GetSection("couchbase").Bind(couchbaseSettings);
      AppSettings.Instance.CouchbaseSettings = couchbaseSettings;

      var elasticSettings = new ElasticSetting();
      Configuration.GetSection("elastic").Bind(elasticSettings);
      AppSettings.Instance.ElasticSettings = elasticSettings;

      var permissionSetting = new PermissionSetting();
      Configuration.GetSection("permission").Bind(permissionSetting);
      AppSettings.Instance.PermissionSettings = permissionSetting;

      var ftpSetting = new FTPServer();
      Configuration.GetSection("ftpserver").Bind(ftpSetting);
      AppSettings.Instance.FtpServers = ftpSetting;


      var ocrSetting = new OcrSetting();
      Configuration.GetSection("ocr").Bind(ocrSetting);
      AppSettings.Instance.OcrSettings = ocrSetting;

      var redisSetting = new RedisSetting();
      Configuration.GetSection("redis").Bind(redisSetting);
      AppSettings.Instance.RedisSettings = redisSetting;


      var elasticLoggerSettings = new ElasticLoggerSettings();
      Configuration.GetSection("log").Bind(elasticLoggerSettings);
      AppSettings.Instance.ElasticLoggerSettings = elasticLoggerSettings;

      var itSelfSettings = new ItSelfSetting();
      Configuration.GetSection("itSelfApi").Bind(itSelfSettings);
      AppSettings.Instance.ItSelfSettings = itSelfSettings;

      DependencyResolution.Instance.Start();
      DependencyFactory.Instance.DependencyResolution = DependencyResolution.Instance;

    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
                  builder =>
                  {
                    builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader()
                                 .WithOrigins("http://localhost:4200")
                                 .AllowCredentials();
              });

      });

      services.AddMvc(options =>
      {
        options.Filters.Add(new GlobalExceptionHandler());

      }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddSignalR();
      services.Configure<FormOptions>(o => {
        o.ValueLengthLimit = int.MaxValue;
        o.MultipartBodyLengthLimit = int.MaxValue;
        o.MemoryBufferThreshold = int.MaxValue;
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors();
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
        RequestPath = new PathString("/Resources")
      });
      app.UseSignalR(options =>
      {
        options.MapHub<ChatHub>("/vnpt/Approval/ApprovalManagement/SendNotification");
      });

      app.UseMvc();

    }

  }
}
