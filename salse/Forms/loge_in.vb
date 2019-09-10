Public Class loge_in
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
            Hide()
            Home.Show()
            '   ElseIf TextBox1.Text = "user" And TextBox2.Text = "user" Then
            '   Hide()
            '   Form15.Show()
        Else
            MsgBox("اسم المستخدم او كلمة المرور خاطئة", MsgBoxStyle.Information, "تنبيه")
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
                Hide()
                Home.Show()
                '   ElseIf TextBox1.Text = "user" And TextBox2.Text = "user" Then
                '   Hide()
                '   Form15.Show()
            Else
                MsgBox("اسم المستخدم او كلمة المرور خاطئة", MsgBoxStyle.Information, "تنبيه")
            End If
        End If
    End Sub
End Class
