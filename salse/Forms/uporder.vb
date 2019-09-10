Imports System.Data.SqlClient
Public Class uporder
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")

    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        Try
            Dim strqery As String = "select * from sales where idd=" & TextBox1.Text & ""
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
                TextBox5.Focus()
            Else
                MsgBox("رقم المنتج غير صحيح", MsgBoxStyle.Information, "تنبيه")
                TextBox1.Focus()
                TextBox1.Text = " "
            End If

            sqlcon.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE sales SET id=" & TextBox2.Text & ", name='" & TextBox3.Text & "', price=" & TextBox4.Text & ", qty=" & TextBox5.Text & ", totle=" & TextBox6.Text & " where idd= " & TextBox1.Text & ""
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mordar.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox6.Text = Val(TextBox4.Text) * Val(TextBox5.Text)
    End Sub
End Class