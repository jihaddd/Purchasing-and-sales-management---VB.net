Imports System.Data.SqlClient
Public Class fatorh

    Dim sqlcon As New SqlConnection("server=-PC; database=sales; integrated security=true")
        Dim adabter As SqlDataAdapter
        Dim ds As New DataTable
        Sub t()
            ds.Rows.Clear()

        Dim qery As String = "select idd as [رقم التسلسل], name as [اسم المنتج], qty as الكمية, price as السعر, totle as المجموع, tootle as [المجوع الكلي] from fatorh"
        adabter = New SqlDataAdapter(qery, sqlcon)
            adabter.Fill(ds)
            DataGridView1.DataSource = ds

        End Sub

    Private Sub fatorh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        repfatorhh.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cmd As New SqlCommand
            Dim strup As String = "delete from fatorh where idd =" & (Me.DataGridView1.CurrentRow.Cells(0).Value)
            cmd = New SqlCommand(strup, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تم الحذف", MsgBoxStyle.Information, "تأكيد")
            sqlcon.Close()
            t()
        Catch ex As Exception

        End Try
    End Sub
End Class