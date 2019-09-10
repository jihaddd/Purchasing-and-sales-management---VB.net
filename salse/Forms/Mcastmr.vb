Imports System.Data.SqlClient
Public Class Mcastmr
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")
    Dim adabter As SqlDataAdapter
    Dim vxc As New DataTable
    Sub t()
        TextBox1.Focus()
        vxc.Rows.Clear()
        Dim qery As String = "select name as الاسم, phone as [رقم الجوال], addres as العنوان, qty as [ الكمية], catogry as الصنف, pric as السعر, tax as [القيمة المضافة], total as المجموع from castomr"
        adabter = New SqlDataAdapter(qery, sqlcon)
        adabter.Fill(vxc)
        DataGridView1.DataSource = vxc

    End Sub
    Sub x()
        TextBox9.Text = (Val(TextBox8.Text) * 100) + Val(TextBox7.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            Dim reslo As DataTable = vxc.Copy
            Dim dv As DataView = reslo.DefaultView
            dv.RowFilter = " [الاسم] like '%" & TextBox5.Text & "%'"
            Me.DataGridView1.DataSource = dv
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            '  If MsgBox("هل تريد حذف المنتج", MsgBoxStyle.YesNo, "تنبيه") = DialogResult Then
            Dim cmd As New SqlCommand
            Dim strup As String = "delete from castomr where name ='" & (Me.DataGridView1.CurrentRow.Cells(0).Value) & "'"
            cmd = New SqlCommand(strup, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            MsgBox("تم الحذف", MsgBoxStyle.Information, "تأكيد")
            sqlcon.Close()
            t()
            ' Else
            '   MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "تنبيه")
            ' End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Mcastmr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()

        t()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            If (String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or
             String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox4.Text)) Then
                MsgBox("ادخل البيانات")
                Return
            Else
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                        MsgBox("هذا الاسم موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                        TextBox5.Clear()
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

            Dim rew As DataRow = vxc.NewRow

            rew(0) = TextBox1.Text
            rew(1) = TextBox2.Text
            rew(2) = TextBox3.Text
            rew(3) = TextBox4.Text
            rew(4) = TextBox6.Text
            rew(5) = TextBox7.Text
            rew(6) = TextBox8.Text
            rew(7) = TextBox9.Text

            vxc.Rows.Add(rew)
            Me.DataGridView1.DataSource = vxc
            Dim my_query As String = "insert into castomr(name, phone, addres, qty, catogry, pric, tax, total  )
              values('" & TextBox1.Text & "', " & Val(TextBox2.Text) & ", '" & TextBox3.Text & "', " & Val(TextBox4.Text) & ", '" & TextBox6.Text & "', " & Val(TextBox7.Text) & ", " & Val(TextBox8.Text) & ", " & Val(TextBox9.Text) & ");"
            Dim cmd As New SqlCommand(my_query, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox6.Text = " "
            TextBox7.Text = " "
            TextBox8.Text = " "
            TextBox9.Text = " "
        Catch ex As Exception

        End Try

    End Sub



    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            MsgBox("ادخل اسم العميل", MsgBoxStyle.Information, "تنبيه")
            upcastmr.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged, TextBox7.TextChanged
        x()
    End Sub
End Class