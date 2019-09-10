Imports System.Data.SqlClient
Public Class upcastmr
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")

    Sub x()
        TextBox8.Text = (Val(TextBox7.Text) * 100) + Val(TextBox6.Text)
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated

        Try
            Dim strqery As String = "select * from castomr where name='" & TextBox1.Text & "'"
            Dim cmd As New SqlCommand(strqery, sqlcon)
            sqlcon.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()

            If dr.HasRows Then
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox4.Text = dr(3)
                TextBox5.Text = dr(4)
                TextBox6.Text = dr(5)
                TextBox7.Text = dr(6)
                TextBox8.Text = dr(7)

            Else
                MsgBox("الاسم غير صحيح", MsgBoxStyle.Information, "تنبيه")
                TextBox1.Focus()
                TextBox1.Text = " "
            End If

            sqlcon.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE castomr SET name='" & TextBox1.Text & "', phone=" & TextBox2.Text & ", addres='" & TextBox3.Text & "', qty=" & TextBox4.Text & ", catogry='" & TextBox5.Text & "', pric=" & TextBox6.Text & ", tax=" & TextBox7.Text & ", total=" & TextBox8.Text & "  where name='" & TextBox1.Text & "'"
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mcastmr.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged, TextBox6.TextChanged
        x()
    End Sub
End Class