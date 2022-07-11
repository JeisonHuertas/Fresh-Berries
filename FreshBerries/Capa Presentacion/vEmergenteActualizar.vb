Public Class vEmergenteActualizar
    Dim LP As New LPedidos
    Dim fPedidos As New FPedidos
    Dim idPedido As Integer
    Public Sub mostrar(id As Integer, nom As String, dir As String, tel As String, prod As String, cant As Integer, cost As Integer, fecha As Date)
        Me.idPedido = id
        txtNombre.Text = nom
        txtDireccion.Text = dir
        txtTelefono.Text = tel
        txtProducto.Text = prod
        txtCantidad.Text = cant
        txtCosto.Text = cost
        DatePicker.Value = fecha
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        LP.actualizarPedido(Me.idPedido, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtProducto.Text, CInt(txtCantidad.Text), CInt(txtCosto.Text), DatePicker.Value)
        fPedidos.llenarListaPrioridad()
    End Sub

    Private Sub vEmergenteActualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class