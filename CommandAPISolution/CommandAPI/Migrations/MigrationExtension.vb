Imports System.Runtime.CompilerServices
Imports FluentMigrator.Runner
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection

Namespace CommandAPI.Migrations

    Module MigrationExtension

        <Extension>
        Function Migrate(builder As IApplicationBuilder) As IApplicationBuilder
            Using scope As IServiceScope = builder.ApplicationServices.CreateScope()
                Dim runner As IMigrationRunner = scope.ServiceProvider.GetService(Of IMigrationRunner)()
                runner.ListMigrations()
                runner.MigrateUp()
                Return builder
            End Using

        End Function
    End Module

End Namespace
