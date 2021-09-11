Imports CommandAPI.Data
Imports CommandAPI.Helpers
Imports CommandAPI.Models
Imports Microsoft.AspNetCore.Mvc
Imports [Optional]

Namespace CommandAPI.Controllers

    <ApiVersion("1.0")>
    <Route("api/v{version:apiVersion}/[controller]")>
    <ApiController()>
    Public Class CommandsController
        Inherits ControllerBase

        Private ReadOnly _commandsRepository As ICommandsRepository

        Public Sub New(commandsRepository As ICommandsRepository)
            _commandsRepository = commandsRepository
        End Sub

        <HttpGet()>
        Public Function [Get]() As ActionResult(Of IEnumerable(Of Command))

            Return Ok(_commandsRepository.GetAllCommands())
        End Function

        <HttpGet("{id}")>
        Public Function [Get](id As Integer) As ActionResult(Of Command)
            Dim command As [Option](Of Command) = _commandsRepository.GetCommandById(id)
            Return _
                command.Match(Of ActionResult(Of Command))(
                    some := AddressOf Ok,
                    none := AddressOf NotFound
                )
        End Function
    End Class

End Namespace
