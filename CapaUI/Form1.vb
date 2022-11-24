Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = CapaDatos.Conexion.ListarProductos
        DataGridView2.DataSource = CapaDatos.Conexion.ListarBodegas

    End Sub

    Sub LimpiarCampos()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If TextBox1.Text = "" Then
            MsgBox("Ingrese Codigo del Articulo")
            Exit Sub

        End If
        DataGridView1.DataSource = CapaDatos.Conexion.BuscarArticulo(TextBox1.Text)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Ingrese Todos los Datos del Articulo")
            Exit Sub

        End If
        CapaDatos.Conexion.InsertarArticulo(TextBox2.Text, TextBox3.Text, TextBox4.Text, ComboBox1.Text)
        LimpiarCampos()
        MsgBox("Producto Guardado")
        DataGridView1.DataSource = CapaDatos.Conexion.ListarProductos()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Ingrese Todos los Datos del Articulo")
            Exit Sub

        End If
        CapaDatos.Conexion.ActualizarArticulo(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, ComboBox1.Text)
        LimpiarCampos()
        MsgBox("Producto Actualizado")
        DataGridView1.DataSource = CapaDatos.Conexion.ListarProductos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Ingrese Los Datos del Articulo")
            Exit Sub

        End If

        CapaDatos.Conexion.EliminarArticulo(TextBox1.Text)
        LimpiarCampos()
        MsgBox("Producto Eliminado")
        DataGridView1.DataSource = CapaDatos.Conexion.ListarProductos()
    End Sub


    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        TextBox2.Text = StrConv(TextBox2.Text, VbStrConv.ProperCase) 'Primera Letra Mayuscula'
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim CN As New SqlConnection("Data Source=DESKTOP-3I6COSJ\MSSQLSERVER01;Initial Catalog=Bodega;Integrated Security=True")
        Dim CMD As New SqlCommand("SELECT Descripcion FROM BODEGA WHERE Codigo_Bodega = " & ComboBox1.Text, CN)
        Dim DT As SqlDataReader
        CN.Open()
        DT = CMD.ExecuteReader
        DT.Read()
        TextBox5.Text = DT.Item("Descripcion").ToString
        DT.Close()
        CN.Close()


    End Sub
End Class
