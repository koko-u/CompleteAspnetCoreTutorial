Imports Microsoft.AspNetCore.Mvc

Namespace CommandAPI.Controllers

    <ApiVersion("1.0")>
    <Route("api/v{version:apiVersion}/[controller]")>
    <ApiController()>
    Public Class CommandsController
        Inherits ControllerBase

        <HttpGet()>
        Public Function [Get]() As ActionResult(Of IEnumerable(Of String))

            Return I(New String() { "This", "is", "Hard", "Coded" }.AsEnumerable())
        End Function

    
        Private Function I(Of T)(value As T) As ActionResult(Of T)
            Return New ActionResult(Of T)(value)
        End Function
    End Class

End Namespace
