<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReDelimIt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReDelimIt))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.txtDelim = New System.Windows.Forms.TextBox()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.chkHeaders = New System.Windows.Forms.CheckBox()
        Me.chkAddKey = New System.Windows.Forms.CheckBox()
        Me.chkGenerateSQL = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(358, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Select..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(377, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Go"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CSV File:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "New Delimiter:"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(93, 7)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(259, 20)
        Me.txtFile.TabIndex = 4
        '
        'txtDelim
        '
        Me.txtDelim.Location = New System.Drawing.Point(93, 32)
        Me.txtDelim.Name = "txtDelim"
        Me.txtDelim.Size = New System.Drawing.Size(56, 20)
        Me.txtDelim.TabIndex = 5
        Me.txtDelim.Text = "<*TMP*>"
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'chkHeaders
        '
        Me.chkHeaders.AutoSize = True
        Me.chkHeaders.Location = New System.Drawing.Point(93, 58)
        Me.chkHeaders.Name = "chkHeaders"
        Me.chkHeaders.Size = New System.Drawing.Size(129, 17)
        Me.chkHeaders.TabIndex = 7
        Me.chkHeaders.Text = "CSV File has Headers"
        Me.chkHeaders.UseVisualStyleBackColor = True
        '
        'chkAddKey
        '
        Me.chkAddKey.AutoSize = True
        Me.chkAddKey.Location = New System.Drawing.Point(93, 81)
        Me.chkAddKey.Name = "chkAddKey"
        Me.chkAddKey.Size = New System.Drawing.Size(175, 17)
        Me.chkAddKey.TabIndex = 8
        Me.chkAddKey.Text = "Add AutoIncrement Primary Key"
        Me.chkAddKey.UseVisualStyleBackColor = True
        '
        'chkGenerateSQL
        '
        Me.chkGenerateSQL.AutoSize = True
        Me.chkGenerateSQL.Location = New System.Drawing.Point(93, 105)
        Me.chkGenerateSQL.Name = "chkGenerateSQL"
        Me.chkGenerateSQL.Size = New System.Drawing.Size(177, 17)
        Me.chkGenerateSQL.TabIndex = 9
        Me.chkGenerateSQL.Text = "Generate SQL Bulk Insert Script"
        Me.chkGenerateSQL.UseVisualStyleBackColor = True
        '
        'ReDelimIt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 135)
        Me.Controls.Add(Me.chkGenerateSQL)
        Me.Controls.Add(Me.chkAddKey)
        Me.Controls.Add(Me.chkHeaders)
        Me.Controls.Add(Me.txtDelim)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ReDelimIt"
        Me.Text = "ReDelimIt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents txtDelim As System.Windows.Forms.TextBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents chkAddKey As System.Windows.Forms.CheckBox
    Friend WithEvents chkHeaders As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerateSQL As System.Windows.Forms.CheckBox

End Class
