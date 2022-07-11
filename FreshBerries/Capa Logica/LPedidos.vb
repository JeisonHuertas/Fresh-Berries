Imports System.Data.OleDb
Public Class LPedidos

    Public Function insertarPedido(nom As String, dir As String, tel As String, prod As String, cant As Integer, cost As Integer, fecha As Date) As Boolean
        Dim DP As New DPedidos(nom, dir, tel, prod, cant, cost, fecha)

        If DP.insertarPedido(DP) = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function mostrar() As DataSet
        Dim DP As New DPedidos()

        Return DP.mostrar()
    End Function

    Public Function contruirArrayPedidos(dataGridView As DataGridView) As DPedidos()
        Dim elementos As Integer = 0
        Dim pedidos(elementos) As DPedidos

        For fila = 0 To dataGridView.Rows.Count - 1 Step 1
            If dataGridView.Rows(fila).Cells(0).Value Is Nothing Then
                Exit For
            End If
            pedidos(elementos) = New DPedidos(dataGridView.Rows(fila).Cells(0).Value, dataGridView.Rows(fila).Cells(1).Value.ToString, dataGridView.Rows(fila).Cells(7).Value)
            elementos += 1
            ReDim Preserve pedidos(elementos)
        Next
        ''Ordenar el arreglo por fecha

        ordenarArray(pedidos)

        Return pedidos
    End Function
    Public Sub ordenarArray(aPedidos() As DPedidos)
        For i = 0 To aPedidos.Length - 1 Step 1
            Dim menor As DPedidos = aPedidos(i)
            Dim posMenor As Integer = i

            For j = i + 1 To aPedidos.Length - 1 Step 1
                If aPedidos(j) Is Nothing Then
                    Continue For
                End If
                If aPedidos(j).fecha_cli < menor.fecha_cli Then
                    menor = aPedidos(j)
                    posMenor = j
                End If
            Next
            Dim aux As DPedidos = aPedidos(i)
            aPedidos(i) = aPedidos(posMenor)
            aPedidos(posMenor) = aux
        Next
    End Sub
    Public Function consultarPedido(id As Integer) As String()
        Try

            Dim DP As New DPedidos

            Dim consultaPedido() As String = DP.consultarPedido(id)

            Return consultaPedido
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    Public Function actualizarPedido(id As Integer, nom As String, dir As String, tel As String, prod As String, cant As Integer, cost As Integer, fecha As Date) As Boolean

        Try
            Dim pedido As New DPedidos(id, nom, dir, tel, prod, cant, cost, fecha)
            pedido.actualizarPedido(pedido)

            Return True
        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        End Try

    End Function

    Public Function eliminarPedido(idPedido As Integer) As Boolean
        Try
            Dim pedido As New DPedidos

            pedido.eliminarPedido(idPedido)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
End Class
