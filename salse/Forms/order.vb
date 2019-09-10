Imports System.Data.SqlClient
Public Class order
    Dim sqlcon As New SqlConnection("server=DESKTOP-BM39GJS\SQLEXPRESS; database=sales; integrated security=true")
    Dim vxc As New DataTable
    Sub x()
        TextBox5.Text = Val(TextBox3.Text) * Val(TextBox4.Text)
    End Sub
    Sub bana()
        vxc.Columns.Add("المعرف")
        vxc.Columns.Add("الاسم")
        vxc.Columns.Add("الكمية")
        vxc.Columns.Add("السعر")
        vxc.Columns.Add("المبلغ")
        ' vxc.Columns.Add("المجموع")
        DataGridView1.DataSource = vxc
        DataGridView1.Columns(0).Width = 226
        DataGridView1.Columns(1).Width = 226
        DataGridView1.Columns(2).Width = 226
        DataGridView1.Columns(3).Width = 226
        DataGridView1.Columns(4).Width = 226
        'DataGridView1.Columns(5).Width = 134
        TextBox1.Focus()



    End Sub
    Private Sub order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox7.Visible = False
        Label7.Visible = False
        TextBox1.Focus()
        bana()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged, TextBox3.TextChanged
        x()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim strqery As String = "select id, name, price from prodect where id=" & TextBox1.Text & ""
                Dim cmd As New SqlCommand(strqery, sqlcon)
                sqlcon.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    TextBox2.Text = dr(1)
                    TextBox4.Text = dr(2)
                    TextBox3.Focus()
                Else
                    MsgBox("رقم المنتج غير صحيح", MsgBoxStyle.Information, "تنبيه")
                    TextBox1.Focus()
                    TextBox1.Text = " "
                End If

                sqlcon.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text Then
                        MsgBox("هذا المنتج موجود مسبقا", MsgBoxStyle.Information, "تنبيه")
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        Mordar.t()
                        TextBox1.Focus()
                        Exit Sub
                    End If
                Next
                Dim rew As DataRow = vxc.NewRow
                rew(0) = TextBox1.Text
                rew(1) = TextBox2.Text
                rew(2) = TextBox3.Text
                rew(3) = TextBox4.Text
                rew(4) = TextBox5.Text
                ' rew(5) = TextBox6.Text
                vxc.Rows.Add(rew)
                Me.DataGridView1.DataSource = vxc
                Dim my_query As String = "insert into sales(id, name, price, qty, totle) values(" & Val(TextBox1.Text) & ", '" & TextBox2.Text & "', " & Val(TextBox4.Text) & ", " & Val(TextBox3.Text) & ", " & Val(TextBox5.Text) & ");"
                Dim cmd As New SqlCommand(my_query, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox5.Clear()
                TextBox1.Focus()
                Mordar.t()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        TextBox1.Text = Me.DataGridView1.CurrentRow.Cells(0).Value
        TextBox2.Text = Me.DataGridView1.CurrentRow.Cells(1).Value
        TextBox7.Text = Me.DataGridView1.CurrentRow.Cells(2).Value
        TextBox4.Text = Me.DataGridView1.CurrentRow.Cells(3).Value
        TextBox5.Text = Me.DataGridView1.CurrentRow.Cells(4).Value
        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        TextBox3.Visible = False
        TextBox7.Visible = True
        Label7.Visible = True
        TextBox7.Focus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
            TextBox6.Text = " "

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim sum As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            sum = sum + DataGridView1.Rows(i).Cells(4).Value
        Next
        TextBox6.Text = sum.ToString()
    End Sub
    Private Sub TextBox7_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim rew As DataRow = vxc.NewRow
                rew(0) = TextBox1.Text
                rew(1) = TextBox2.Text
                rew(2) = TextBox7.Text
                rew(3) = TextBox4.Text
                rew(4) = TextBox5.Text
                vxc.Rows.Add(rew)
                Me.DataGridView1.DataSource = vxc
                Dim cmd As New SqlCommand
                Dim strup As String = "UPDATE sales SET id=" & TextBox1.Text & ", name='" & TextBox2.Text & "', price=" & TextBox4.Text & ", qty=" & TextBox7.Text & ", totle=" & TextBox5.Text & " where totle= " & TextBox6.Text & ""
                cmd = New SqlCommand(strup, sqlcon)
                sqlcon.Open()
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                Mordar.t()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox7.Text = " "
                TextBox3.Visible = True
                TextBox7.Visible = False
                Label7.Visible = False
                TextBox1.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBox7_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox5.Text = Val(TextBox7.Text) * Val(TextBox4.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim my_query As String = "insert into fatorh(name, price, qty, totle, tootle) values('" & (DataGridView1.CurrentRow.Cells(1).Value) & "', " & (DataGridView1.CurrentRow.Cells(3).Value.ToString) & ", " & (DataGridView1.CurrentRow.Cells(2).Value) & ", " & (DataGridView1.CurrentRow.Cells(4).Value) & ", " & Val(TextBox6.Text) & ");"
            Dim cmd As New SqlCommand(my_query, sqlcon)
            sqlcon.Open()
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            fatorh.t()
            fatorh.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class