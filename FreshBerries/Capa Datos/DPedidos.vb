Imports System.Data.OleDb

Public Class DPedidos
    Inherits Conexion

    Private Id As Integer
    Private nombres As String
    Private direccion As String
    Private telefono As String
    Private productos As String
    Private cantidad As Integer
    Private costo As Integer
    Private fechaEntrega As Date

    Private cmd As OleDbCommand
    Private dataReader As OleDbDataReader
    Public Sub New(nom As String, dir As String, tel As String, prod As String, cant As Integer, cost As Integer, fecha As Date)
        nombres = nom
        direccion = dir
        telefono = tel
        productos = prod
        cantidad = cant
        costo = cost
        fechaEntrega = fecha
    End Sub
    Public Sub New(id As Integer, nom As String, dir As String, tel As String, prod As String, cant As Integer, cost As Integer, fecha As Date)
        Me.Id = id
        nombres = nom
        direccion = dir
        telefono = tel
        productos = prod
        cantidad = cant
        costo = cost
        fechaEntrega = fecha
    End Sub
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, nom As String, fecha As Date)
        Me.Id = id
        Me.nombres = nom
        Me.fechaEntrega = fecha
    End Sub

    Public Property Id_Pedido As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property
    Public Property nombres_cli As String
        Get
            Return nombres
        End Get
        Set(value As String)
            nombres = value
        End Set
    End Property
    Public Property direccion_cli As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property
    Public Property telefono_cli As String
        Get
            Return telefono
        End Get
        Set(value As String)
            telefono = value
        End Set
    End Property
    Public Property poductos_cli As String
        Get
            Return productos
        End Get
        Set(value As String)
            productos = value
        End Set
    End Property
    Public Property cantidad_cli As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
        End Set
    End Property
    Public Property costo_cli As Integer
        Get
            Return costo
        End Get
        Set(value As Integer)
            costo = value
        End Set
    End Property
    Public Property fecha_cli As Date
        Get
            Return fechaEntrega
        End Get
        Set(value As Date)
            fechaEntrega = value
        End Set
    End Property
    Public Function insertarPedido(DP As DPedidos) As Boolean
        Try
            conectar()
            Dim sql As String = "INSERT INTO Pedidos(Nombres,Direccion,Telefono,Productos,Cantida,Costo,Fecha_Entrega)VALUES('" & DP.nombres_cli & "','" & DP.direccion_cli & "','" & DP.telefono_cli & "','" & DP.poductos_cli & "', " & DP.cantidad_cli & ", " & DP.costo_cli & ",' " & DP.fecha_cli & "')"
            cmd = New OleDbCommand(sql, conn)

            If cmd.ExecuteNonQuery() Then
                MsgBox("Pedido registrado con exito")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function mostrar() As DataSet

        Dim oda As New OleDbDataAdapter
        Dim ods As New DataSet
        Dim sql As String

        sql = "SELECT *FROM Pedidos"

        Try
            oda = New OleDbDataAdapter(sql, conn)
            ods.Tables.Add("Pedidos")
            oda.Fill(ods.Tables("Pedidos"))
            Return ods
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ods
        End Try
    End Function

    Public Function consultarPedido(id As Integer) As String()
        Try
            conectar()
            Dim sql As String
            sql = "SELECT Nombres,Direccion,Telefono,Productos,Cantida,Costo,Fecha_Entrega FROM Pedidos WHERE Id=" & id & ""
            cmd = New OleDbCommand(sql)

            cmd.Connection = conn

            dataReader = cmd.ExecuteReader()

            If dataReader.Read Then
                Dim consultaPedido = New String() {dataReader.Item("Nombres"), dataReader.Item("Direccion"), dataReader.Item("Telefono"), dataReader.Item("Productos"), dataReader.Item("Cantida"), dataReader.Item("Costo"), dataReader.Item("Fecha_Entrega")}
                Return consultaPedido
                dataReader.Close()
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        Finally
            desconectar()
        End Try

    End Function

    Public Function actualizarPedido(pedido As DPedidos) As Boolean
        Try
            conectar()
            Dim sql As String
            sql = "UPDATE Pedidos SET Nombres='" & pedido.nombres_cli & "',Direccion='" & pedido.direccion_cli & "',Telefono='" & pedido.telefono_cli & "',Productos='" & pedido.productos & "',Cantida=" & pedido.cantidad_cli & ",Costo=" & pedido.costo_cli & ",Fecha_Entrega='" & pedido.fecha_cli & "' WHERE Id=" & pedido.Id_Pedido & ""
            cmd = New OleDbCommand(sql)

            cmd.Connection = conn

            If cmd.ExecuteNonQuery Then
                MsgBox("Los datos del pedido fueron actualizados correctamente", MsgBoxStyle.OkOnly)
                Return True
            Else
                MsgBox("No se actualizo", MsgBoxStyle.Critical)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        Finally
            desconectar()
        End Try

    End Function

    Public Function eliminarPedido(idPedido As Integer) As Boolean
        Try
            conectar()
            Dim sql As String = "DELETE FROM Pedidos WHERE Id=" & idPedido & ""
            cmd = New OleDbCommand(sql)

            cmd.Connection = conn

            If cmd.ExecuteNonQuery Then
                MsgBox("El pedido ha sido eliminado correctamente", MsgBoxStyle.Information)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class
