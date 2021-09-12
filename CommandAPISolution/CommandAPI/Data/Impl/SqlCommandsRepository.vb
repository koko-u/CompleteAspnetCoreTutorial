Imports CommandAPI.Models
Imports [Optional]
Imports [Optional].Collections

Namespace CommandAPI.Data.Impl

    Public Class SqlCommandsRepository
        Implements ICommandsRepository

        Private ReadOnly _dbContext As CommandContext

        Public Sub New(dbContext As CommandContext)
            _dbContext = dbContext
        End Sub

        ''' <inheritdoc />
        Public Function SaveChanges() As Boolean Implements ICommandsRepository.SaveChanges
            Throw New NotImplementedException
        End Function

        ''' <inheritdoc />
        Public Function GetAllCommands() As IEnumerable(Of Command) _
            Implements ICommandsRepository.GetAllCommands

            Return _dbContext.Commands.AsEnumerable()
        End Function

        ''' <inheritdoc />
        Public Function GetCommandById(id As Integer) As [Option](Of Command) Implements ICommandsRepository.GetCommandById
            Return _dbContext.Commands.FirstOrNone(Function (command) command.Id = id)
        End Function

        ''' <inheritdoc />
        Public Sub CreateCommand(cmd As Command) Implements ICommandsRepository.CreateCommand
            Throw New NotImplementedException
        End Sub

        ''' <inheritdoc />
        Public Sub UpdateCommand(cmd As Command) Implements ICommandsRepository.UpdateCommand
            Throw New NotImplementedException
        End Sub
    End Class

End Namespace