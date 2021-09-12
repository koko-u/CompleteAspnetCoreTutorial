Imports System.Reflection
Imports CommandAPI.Data
Imports CommandAPI.Data.Impl
Imports CommandAPI.Migrations
Imports FluentMigrator.Runner
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.Versioning
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace CommandAPI
    Public Class Startup

        Public ReadOnly Property Configuration As IConfiguration

        Public Sub New(configuration As IConfiguration)
            Me.Configuration = configuration
        End Sub

        ' This method gets called by the runtime. Use this method to add services to the container.
        ' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        Public Sub ConfigureServices(services As IServiceCollection)
            services.AddApiVersioning(AddressOf ApiVersionOptions)
            services.AddControllers()

            services.AddScoped(Of ICommandsRepository, SqlCommandsRepository)()

            Dim connectionString As String = Configuration.Item("CommandAPI:ConnectionString")
            services.AddDbContext(Of CommandContext)(DbContextOptions(connectionString))

            services _
                .AddLogging(Sub (configure) configure.AddFluentMigratorConsole()) _
                .AddFluentMigratorCore() _
                .ConfigureRunner(FluentMigratorConfig(connectionString))
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(app As IApplicationBuilder, env As IWebHostEnvironment)
            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
            End If

            app.UseRouting()
            app.UseEndpoints(Sub(endpoints) endpoints.MapControllers())

            app.Migrate()
        End Sub

        Private Sub ApiVersionOptions(options As ApiVersioningOptions)
            options.DefaultApiVersion = new ApiVersion(1, 0)
            options.AssumeDefaultVersionWhenUnspecified = True
            options.ReportApiVersions = True
        End Sub

        Private Function DbContextOptions(connectionString As String) As Action(Of DbContextOptionsBuilder)
            Return _
                Sub (options)
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)) _
                           .UseSnakeCaseNamingConvention() _
                           .EnableSensitiveDataLogging() _
                           .EnableDetailedErrors()
                End Sub
        End Function

        Private Function FluentMigratorConfig(connectionString As String) As Action(Of IMigrationRunnerBuilder)
            Return _
                Sub (config)
                    config _
                        .AddMySql5() _
                        .WithGlobalConnectionString(connectionString) _
                        .ScanIn(Assembly.GetExecutingAssembly()).For().All()
                End Sub
        End Function
    End Class
End Namespace
