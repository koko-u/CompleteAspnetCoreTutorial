Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging

Namespace CommandAPI
    Public Class Program
        Public Shared Sub Main(ByVal args As String())
            Call CreateHostBuilder(args).Build().Run()
        End Sub

        Public Shared Function CreateHostBuilder(ByVal args As String()) As IHostBuilder
            Return Host.CreateDefaultBuilder(args) _
                       .ConfigureWebHostDefaults(Sub(webBuilder) webBuilder.UseStartup(Of Startup)())
        End Function
    End Class
End Namespace
