Public Class Inicio

    Dim usuario As String
    Dim contrasena As String

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        usuario = txtUsuario.Text
        contrasena = txtConstrasena.Text
        If usuario.Equals("user") And contrasena.Equals("user") Then
            Me.Hide()
            FPedidos.Show()
        End If
    End Sub

End Class