Imports CommandAPI.Data
Imports CommandAPI.Data.Impl
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.Versioning
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace CommandAPI
    Public Class Startup
        ' This method gets called by the runtime. Use this method to add services to the container.
        ' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        Public Sub ConfigureServices(services As IServiceCollection)
            services.AddApiVersioning(AddressOf ApiVersionOptions)
            services.AddControllers()

            services.AddScoped(Of ICommandsRepository, MockCommandRepository)()
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(app As IApplicationBuilder, env As IWebHostEnvironment)
            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
            End If

            app.UseRouting()
            app.UseEndpoints(Sub(endpoints) endpoints.MapControllers())
        End Sub

        Private Sub ApiVersionOptions(options As ApiVersioningOptions)
            options.DefaultApiVersion = new ApiVersion(1, 0)
            options.AssumeDefaultVersionWhenUnspecified = True
            options.ReportApiVersions = True
        End Sub

    End Class
End Namespace
