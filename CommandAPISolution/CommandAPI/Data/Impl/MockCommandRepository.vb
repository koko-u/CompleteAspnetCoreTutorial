Imports CommandAPI.Models
Imports [Optional]

Namespace CommandAPI.Data.Impl

    Public Class MockCommandRepository
        Implements ICommandsRepository

        Public Function SaveChanges() As Boolean Implements ICommandsRepository.SaveChanges
            Throw New NotImplementedException
        End Function

        Public Function GetAllCommands() As IEnumerable(Of Command) Implements ICommandsRepository.GetAllCommands
            Dim commands As New List(Of Command) From {
                    New Command() With { .Id = 0, .HowTo = "How to generate a migration", .CommandLine = "dotnet ef migrations add <Name of Migration>", .Platform = ".Net Core EF" },
                    New Command() With { .Id = 1, .HowTo = "Run migration", .CommandLine = "dotnet ef database update", .Platform = ".Net Core EF" },
                    New Command() With { .Id = 2, .HowTo = "List active migrations", .CommandLine = "dotnet ef migrations list", .Platform = ".Net Core EF" }
            }
            Return commands
        End Function

        Public Function GetCommandById(id As Integer) As [Option](Of Command) Implements ICommandsRepository.GetCommandById
            Dim command As New Command() With { .Id = 0, .HowTo = "How to generate a migration", .CommandLine = "dotnet ef migrations add <Name of Migration>", .Platform = ".Net Core EF" }
            Return command.Some()
        End Function

        Public Sub CreateCommand(cmd As Command) Implements ICommandsRepository.CreateCommand
            Throw New NotImplementedException
        End Sub

        Public Sub UpdateCommand(cmd As Command) Implements ICommandsRepository.UpdateCommand
            Throw New NotImplementedException
        End Sub
    End Class

End Namespace
