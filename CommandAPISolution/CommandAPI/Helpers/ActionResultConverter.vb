Imports Microsoft.AspNetCore.Mvc

Namespace CommandAPI.Helpers

    Module ActionResultConverter
        Function I(Of T)(value As T) As ActionResult(Of T)
            Return New ActionResult(Of T)(value)
        End Function

    End Module

End Namespace
