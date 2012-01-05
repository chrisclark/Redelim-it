Imports System.IO


Public Class ReDelimIt

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim res = OpenFileDialog1.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            txtFile.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(txtDelim.Text) OrElse String.IsNullOrEmpty(txtFile.Text) Then
            MsgBox("Both enter both a file path and a delimiter.")
        Else
            Dim ouputpath = txtFile.Text & ".delim"
            Try
                Redelimiter.Redelimit(txtDelim.Text, chkHeaders.Checked, chkAddKey.Checked, txtFile.Text, ouputpath)
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
            frmSuccess.Show()
            frmSuccess.txtOutputPath.Text = "test"
        End If
    End Sub
End Class
