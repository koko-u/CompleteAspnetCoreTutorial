Imports System.Diagnostics.CodeAnalysis
Imports CommandAPI.Models
Imports [Optional]

Namespace CommandAPI.Data

    Public Interface ICommandsRepository

        Function SaveChanges() As Boolean

        Function GetAllCommands() As <NotNull> IEnumerable(Of Command)

        Function GetCommandById(id As Integer) As <NotNull> [Option](Of Command)

        Sub CreateCommand(<DisallowNull> cmd As Command)
        Sub UpdateCommand(<DisallowNull> cmd As Command)
    End Interface

End Namespace
