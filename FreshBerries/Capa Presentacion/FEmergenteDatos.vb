Public Class FEmergenteDatos
    Private Sub FEmergenteDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub mostrarDatos(nom As String, dir As String, tel As String, prod As String, cant As String, cost As String, fecha As String)
        txtNombre.Text = nom
        txtDireccion.Text = dir
        txtTelefono.Text = tel
        txtProducto.Text = prod
        txtCantidad.Text = cant
        txtCosto.Text = cost
        txtFechaEntrega.Text = fecha

    End Sub
End Class