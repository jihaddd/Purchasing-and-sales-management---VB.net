Imports System.Data.SqlClient
Public Class Mpro
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")
    Dim adabter As SqlDataAdapter
    Dim ds As New DataTable
    Sub t()
        ds.Rows.Clear()
        Dim qery As String = "select name as [اسم المنتج], qty as الكمية, price as المبلغ from purchases"
        adabter = New SqlDataAdapter(qery, sqlcon)
        adabter.Fill(ds)
        DataGridView1.DataSource = ds
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If (String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or
          String.IsNullOrEmpty(TextBox3.Text)) Then
                MsgBox("ادخل البيانات")
                Return
            Else
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                        MsgBox("هذا النتج موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox1.Clear()
                        Mordar.t()
                        TextBox1.Focus()
                        Exit Sub
                    End If
                Next
            End If

            Dim rew As DataRow = ds.NewRow

            rew(0) = TextBox1.Text
            rew(1) = TextBox2.Text
            rew(2) = TextBox3.Text
            ds.Rows.Add(rew)
            Me.DataGridView1.DataSource = ds
            Dim my_query As String = "insert into purchases(name, qty, price) values('" & TextBox1.Text & "', " & Val(TextBox2.Text) & ", " & Val(TextBox3.Text) & ");"
            Dim cmd As New SqlCommand(my_query, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            t()
            sqlcon.Close()
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Mpro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            Dim reslo As DataTable = ds.Copy
            Dim dv As DataView = reslo.DefaultView
            dv.RowFilter = " [اسم المنتج] like '%" & TextBox4.Text & "%'"
            Me.DataGridView1.DataSource = dv
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            MsgBox("ادخل اسم المنتج", MsgBoxStyle.Information, "تنبيه")
            uppro.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cmd As New SqlCommand
            Dim strup As String = "delete from purchases where name ='" & (Me.DataGridView1.CurrentRow.Cells(0).Value) & "'"
            cmd = New SqlCommand(strup, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تم الحذف", MsgBoxStyle.Information, "تأكيد")
            sqlcon.Close()
            t()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If (String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or
           String.IsNullOrEmpty(TextBox3.Text)) Then
                    MsgBox("ادخل البيانات")
                    Return
                Else
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                            MsgBox("هذا النتج موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                            TextBox2.Clear()
                            TextBox3.Clear()
                            TextBox4.Clear()
                            TextBox1.Clear()
                            Mordar.t()
                            TextBox1.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                Dim rew As DataRow = ds.NewRow

                rew(0) = TextBox1.Text
                rew(1) = TextBox2.Text
                rew(2) = TextBox3.Text
                ds.Rows.Add(rew)
                Me.DataGridView1.DataSource = ds
                Dim my_query As String = "insert into purchases(name, qty, price) values('" & TextBox1.Text & "', " & Val(TextBox2.Text) & ", " & Val(TextBox3.Text) & ");"
                Dim cmd As New SqlCommand(my_query, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                t()
                sqlcon.Close()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class