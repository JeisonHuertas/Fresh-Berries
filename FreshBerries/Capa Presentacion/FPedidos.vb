Public Class FPedidos
    Dim LP As New LPedidos()
    Dim fTablaPedidos As New FTablaPedidos
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtCantidad.Text.Equals("") Or txtCosto.Text.Equals("") Or txtDireccion.Text.Equals("") Or txtNombre.Text.Equals("") Or txtProducto.Text.Equals("") Or txtTelefono.Text.Equals("") Then
            MsgBox("Complete los datos", MsgBoxStyle.Critical)
        Else
            Try
                Dim LP As New LPedidos()

                LP.insertarPedido(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtProducto.Text, CInt(txtCantidad.Text), CInt(txtCosto.Text), DatePicker.Value)
                LP.mostrar()
                fTablaPedidos.mostarDataGridView(LP.mostrar)
                llenarListaPrioridad()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        txtCantidad.Text = ""
        txtCosto.Text = ""
        txtDireccion.Text = ""
        txtNombre.Text = ""
        txtProducto.Text = ""
        txtTelefono.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVerPedidos.Click
        fTablaPedidos.Show()
        fTablaPedidos.mostarDataGridView(LP.mostrar())
    End Sub

    Private Sub FPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Llenar el data grid view

        fTablaPedidos.mostarDataGridView(LP.mostrar)

        '' LLenar la tabla de prioridad de envio
        llenarListaPrioridad()
    End Sub
    Public Sub llenarListaPrioridad()
        Dim arregloPedidos = fTablaPedidos.darArrayPedidos()
        listBoxPrioridad.Items.Clear()

        For i = 0 To arregloPedidos.Length - 1 Step 1
            If arregloPedidos(i) Is Nothing Then
                Continue For
            End If
            Dim longStr As Integer = 20 - (arregloPedidos(i).nombres_cli.Length)
            Dim Str As String = arregloPedidos(i).nombres_cli + StrDup(longStr, "-") + ">" + arregloPedidos(i).fecha_cli.ToString("dd/MM/yyyy")
            listBoxPrioridad.Items.Add(Str)
        Next
    End Sub

    Private Sub listBoxPrioridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBoxPrioridad.SelectedIndexChanged

    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim indice As Integer = listBoxPrioridad.SelectedIndex

        Dim idPedido As Integer = fTablaPedidos.darArrayPedidos(indice).Id_Pedido

        Dim ConsultaPedido() As String = LP.consultarPedido(idPedido)

        Dim vEmergente As New FEmergenteDatos

        vEmergente.mostrarDatos(ConsultaPedido(0), ConsultaPedido(1), ConsultaPedido(2), ConsultaPedido(3), ConsultaPedido(4), ConsultaPedido(5), ConsultaPedido(6))
        vEmergente.ShowDialog()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim indice As Integer = listBoxPrioridad.SelectedIndex

        Dim idPedido As Integer = fTablaPedidos.darArrayPedidos(indice).Id_Pedido

        Dim ventana As New vEmergenteActualizar

        Dim ConsultaPedido() As String = LP.consultarPedido(idPedido)

        ventana.mostrar(idPedido, ConsultaPedido(0), ConsultaPedido(1), ConsultaPedido(2), ConsultaPedido(3), ConsultaPedido(4), ConsultaPedido(5), ConsultaPedido(6))
        ventana.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim indice As Integer = listBoxPrioridad.SelectedIndex

        Dim idPedido As Integer = fTablaPedidos.darArrayPedidos(indice).Id_Pedido
        If MsgBox("¿Seguro que quiere elimanar el registro?", MsgBoxStyle.OkCancel) = vbOK Then
            LP.eliminarPedido(idPedido)
            fTablaPedidos.mostarDataGridView(LP.mostrar)
            llenarListaPrioridad()
        End If
    End Sub
    Public Function darFTablaPedidos() As FTablaPedidos
        Return Me.fTablaPedidos
    End Function

End Class