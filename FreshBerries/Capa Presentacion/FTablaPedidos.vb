Public Class FTablaPedidos
    Dim LP As New LPedidos()

    Public Sub FTablaPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewPedidos.Columns(0).Width() = 40
        FPedidos.Close()
    End Sub
    Public Sub mostarDataGridView(ods As DataSet)
        DataGridViewPedidos.DataSource = ods.Tables("Pedidos")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub FTablaPedidos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FPedidos.Show()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Public Function darArrayPedidos() As DPedidos()
        Return LP.contruirArrayPedidos(DataGridViewPedidos)
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim idPedido As Integer = CInt(DataGridViewPedidos.CurrentRow.Cells(0).Value)
        LP.eliminarPedido(idPedido)
        mostarDataGridView(LP.mostrar)
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim ventana As New vEmergenteActualizar
        ventana.mostrar(CInt(DataGridViewPedidos.CurrentRow.Cells(0).Value),
                        DataGridViewPedidos.CurrentRow.Cells(1).Value.ToString,
                        DataGridViewPedidos.CurrentRow.Cells(2).Value.ToString,
                        DataGridViewPedidos.CurrentRow.Cells(3).Value.ToString,
                        DataGridViewPedidos.CurrentRow.Cells(4).Value.ToString,
                        CInt(DataGridViewPedidos.CurrentRow.Cells(5).Value),
                        CInt(DataGridViewPedidos.CurrentRow.Cells(6).Value),
                        DataGridViewPedidos.CurrentRow.Cells(7).Value)
        ventana.ShowDialog()
        mostarDataGridView(LP.mostrar)
    End Sub

    Private Sub DataGridViewPedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPedidos.CellContentClick

    End Sub
End Class