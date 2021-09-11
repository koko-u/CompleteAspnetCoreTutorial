Imports CommandAPI.Models
Imports Microsoft.EntityFrameworkCore

Namespace CommandAPI.Data

    Public Class CommandContext
        Inherits DbContext

        Public Property CommandItems As DbSet(Of Command)

        Public Sub New(options As DbContextOptions)
            MyBase.New(options)
        End Sub


    End Class
End Namespace