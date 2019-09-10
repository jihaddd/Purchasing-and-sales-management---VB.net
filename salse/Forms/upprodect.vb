Imports System.Data.SqlClient

Public Class upprodect
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")


    Private Sub TextBox1_Validated_1(sender As Object, e As EventArgs) Handles TextBox1.Validated
        Try
            Dim strqery As String = "select * from prodect where id=" & TextBox1.Text & ""
            Dim cmd As New SqlCommand(strqery, sqlcon)
            sqlcon.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()

            If dr.HasRows Then
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox4.Text = dr(3)
            Else
                MsgBox("رقم المنتج غير صحيح", MsgBoxStyle.Information, "تنبيه")
                TextBox1.Focus()
                TextBox1.Text = " "
            End If

            sqlcon.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE prodect SET id=" & TextBox1.Text & ", name='" & TextBox2.Text & "', price=" & TextBox3.Text & ", qty=" & TextBox4.Text & " where id=" & TextBox1.Text & ""
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mprodect.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "

                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE prodect SET id=" & TextBox1.Text & ", name='" & TextBox2.Text & "', price=" & TextBox3.Text & ", qty=" & TextBox4.Text & " where id=" & TextBox1.Text & ""
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mprodect.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "

                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE prodect SET id=" & TextBox1.Text & ", name='" & TextBox2.Text & "', price=" & TextBox3.Text & ", qty=" & TextBox4.Text & " where id=" & TextBox1.Text & ""
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mprodect.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "

                MsgBox("تم تحديث البيانات ", MsgBoxStyle.Information, "تنبيه")
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class