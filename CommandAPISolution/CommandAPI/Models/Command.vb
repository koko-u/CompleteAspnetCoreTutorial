Imports System.ComponentModel.DataAnnotations

Namespace CommandAPI.Models

    Public Class Command

        <Key>
        <Required>
        Public Property Id As Integer

        <Required>
        <MaxLength(250)>
        Public Property HowTo As String

        <Required>
        Public Property Platform As String

        <Required>
        Public Property CommandLine As String
    End Class

End Namespace
