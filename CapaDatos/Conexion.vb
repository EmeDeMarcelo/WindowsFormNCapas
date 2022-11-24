Imports System.Data.SqlClient

Public Class Conexion


    Public Shared Function ListarProductos() As DataTable

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using DA As New SqlDataAdapter("Sp_Listar", CN)
                Using TABLA As New DataTable
                    DA.Fill(TABLA)
                    Return TABLA

                End Using
            End Using
        End Using

    End Function

    Public Shared Function ListarBodegas() As DataTable

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using DAB As New SqlDataAdapter("Sp_ListarBodega", CN)
                Using TABLA As New DataTable
                    DAB.Fill(TABLA)
                    Return TABLA

                End Using
            End Using
        End Using

    End Function

    Public Shared Function BuscarArticulo(Codigo As Integer) As DataTable

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using CMD As New SqlCommand("Sp_BuscarCodigo", CN)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@CODIGO", Codigo)
                Using DAB As New SqlDataAdapter(CMD)
                    Using TABLA As New DataTable
                        DAB.Fill(TABLA)
                        Return TABLA

                    End Using
                End Using
            End Using
        End Using

    End Function


    Public Shared Sub InsertarArticulo(Descripcion As String, Valor As Integer, Stock As Integer, CodigoBodega As Integer)

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using CMD As New SqlCommand("Sp_Insertar", CN)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@DESCRIPCION", Descripcion)
                CMD.Parameters.AddWithValue("@VALOR", Valor)
                CMD.Parameters.AddWithValue("@STOCK", Stock)
                CMD.Parameters.AddWithValue("@CODIGO_BODEGA", CodigoBodega)

                CN.Open()
                CMD.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Public Shared Sub ActualizarArticulo(Codigo As Integer, Descripcion As String, Valor As Integer, Stock As Integer, CodigoBodega As Integer)

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using CMD As New SqlCommand("Sp_Actualizar", CN)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@CODIGO", Codigo)
                CMD.Parameters.AddWithValue("@DESCRIPCION", Descripcion)
                CMD.Parameters.AddWithValue("@VALOR", Valor)
                CMD.Parameters.AddWithValue("@STOCK", Stock)
                CMD.Parameters.AddWithValue("@CODIGO_BODEGA", CodigoBodega)

                CN.Open()
                CMD.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Public Shared Sub EliminarArticulo(Codigo As Integer)

        Using CN As New SqlConnection(My.Settings.Conexion)
            Using CMD As New SqlCommand("Sp_Eliminar", CN)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@CODIGO", Codigo)

                CN.Open()
                CMD.ExecuteNonQuery()

            End Using
        End Using
    End Sub



End Class
