Imports FluentMigrator

Namespace CommandAPI.Migrations

    ' ReSharper disable once InconsistentNaming
    <Migration(20210912122300)>
    Public Class Migration_20210912122300
        Inherits Migration

        ''' <inheritdoc />
        Public Overrides Sub Up()
            Create.Table("commands") _
                  .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity() _
                  .WithColumn("how_to").AsString(250).NotNullable() _
                  .WithColumn("platform").AsString().NotNullable() _
                  .WithColumn("command_line").AsString().NotNullable()
        End Sub

        ''' <inheritdoc />
        Public Overrides Sub Down()
            Delete.Table("commands")
        End Sub
    End Class

End Namespace
