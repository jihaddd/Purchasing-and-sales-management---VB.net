Imports System.Data.SqlClient
Public Class Mordar
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")
    Dim adabter As SqlDataAdapter
    Dim ds As New DataTable
    Sub t()
        ds.Rows.Clear()

        Dim qery As String = "select idd as [رقم التسلسل], id as [رقم المنتج], name as [اسم المنتج], qty as الكمية, price as المبلغ, totle as المجموع from sales"
        adabter = New SqlDataAdapter(qery, sqlcon)
        adabter.Fill(ds)
        DataGridView1.DataSource = ds

    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Try
            Dim reslo As DataTable = ds.Copy
            Dim dv As DataView = reslo.DefaultView
            dv.RowFilter = " [اسم المنتج] like '%" & TextBox6.Text & "%'"
            Me.DataGridView1.DataSource = dv

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            MsgBox("ادخل رقم التسلسل", MsgBoxStyle.Information, "تنبيه")
            uporder.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Mordar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        order.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class