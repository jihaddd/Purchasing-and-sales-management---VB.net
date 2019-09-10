Imports System.Data.SqlClient
Public Class msup
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")
    Dim adabter As SqlDataAdapter
    Dim ds As New DataTable
    Sub t()
        ds.Rows.Clear()
        Dim qery As String = "select name as الاسم, phon as [رقم الجوال], Emil as الايميل, namepro as [اسم المنتج], idbank as [رقم الحساب] from Supplier"
        adabter = New SqlDataAdapter(qery, sqlcon)
        adabter.Fill(ds)
        DataGridView1.DataSource = ds
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If (String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or
           String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox4.Text) Or String.IsNullOrEmpty(TextBox5.Text)) Then
                MsgBox("ادخل البيانات")
                Return
            Else
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                        MsgBox("هذا الاسم موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox1.Focus()
                        Exit Sub
                    End If
                Next
            End If
            Dim rew As DataRow = ds.NewRow

            rew(0) = TextBox1.Text
            rew(1) = TextBox2.Text
            rew(2) = TextBox3.Text
            rew(3) = TextBox4.Text
            rew(4) = TextBox5.Text
            ds.Rows.Add(rew)
            Me.DataGridView1.DataSource = ds
            Dim my_query As String = "insert into Supplier(name, phon, Emil, namepro, idbank) values('" & TextBox1.Text & "', " & Val(TextBox2.Text) & ", '" & TextBox3.Text & "', '" & TextBox4.Text & "', " & Val(TextBox5.Text) & ");"
            Dim cmd As New SqlCommand(my_query, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            t()
            sqlcon.Close()
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox5.Text = " "
            TextBox1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub msupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Try
            Dim reslo As DataTable = ds.Copy
            Dim dv As DataView = reslo.DefaultView
            dv.RowFilter = " [الاسم] like '%" & TextBox6.Text & "%'"
            Me.DataGridView1.DataSource = dv
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cmd As New SqlCommand
            Dim strup As String = "delete from Supplier where name ='" & (Me.DataGridView1.CurrentRow.Cells(0).Value) & "'"
            cmd = New SqlCommand(strup, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تم الحذف", MsgBoxStyle.Information, "تأكيد")
            sqlcon.Close()
            t()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            MsgBox("ادخل اسم المورد", MsgBoxStyle.Information, "تنبيه")
            upsupplier.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If (String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or
             String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox4.Text)) Then
                    MsgBox("ادخل البيانات")
                    Return
                Else
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                            MsgBox("هذا الاسم موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                            TextBox1.Clear()
                            TextBox2.Clear()
                            TextBox3.Clear()
                            TextBox4.Clear()
                            TextBox5.Clear()
                            TextBox1.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                Dim rew As DataRow = ds.NewRow

                rew(0) = TextBox1.Text
                rew(1) = TextBox2.Text
                rew(2) = TextBox3.Text
                rew(3) = TextBox4.Text
                rew(4) = TextBox5.Text
                ds.Rows.Add(rew)
                Me.DataGridView1.DataSource = ds
                Dim my_query As String = "insert into Supplier(name, phon, Emil, namepro, idbank) values('" & TextBox1.Text & "', " & Val(TextBox2.Text) & ", '" & TextBox3.Text & "', '" & TextBox4.Text & "', " & Val(TextBox5.Text) & ");"
                Dim cmd As New SqlCommand(my_query, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                t()
                sqlcon.Close()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox1.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class