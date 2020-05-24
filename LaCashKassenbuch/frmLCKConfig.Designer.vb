<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLCKConfig
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKunde1 = New System.Windows.Forms.TextBox()
        Me.txtKunde2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKunde3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKunde4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(190, 138)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Kunde1"
        '
        'txtKunde1
        '
        Me.txtKunde1.Location = New System.Drawing.Point(51, 12)
        Me.txtKunde1.Name = "txtKunde1"
        Me.txtKunde1.Size = New System.Drawing.Size(214, 20)
        Me.txtKunde1.TabIndex = 2
        '
        'txtKunde2
        '
        Me.txtKunde2.Location = New System.Drawing.Point(51, 38)
        Me.txtKunde2.Name = "txtKunde2"
        Me.txtKunde2.Size = New System.Drawing.Size(214, 20)
        Me.txtKunde2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kunde2"
        '
        'txtKunde3
        '
        Me.txtKunde3.Location = New System.Drawing.Point(51, 64)
        Me.txtKunde3.Name = "txtKunde3"
        Me.txtKunde3.Size = New System.Drawing.Size(214, 20)
        Me.txtKunde3.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kunde3"
        '
        'txtKunde4
        '
        Me.txtKunde4.Location = New System.Drawing.Point(51, 90)
        Me.txtKunde4.Name = "txtKunde4"
        Me.txtKunde4.Size = New System.Drawing.Size(214, 20)
        Me.txtKunde4.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Kunde4"
        '
        'frmLCKConfig
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 165)
        Me.Controls.Add(Me.txtKunde4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtKunde3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKunde2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKunde1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmLCKConfig"
        Me.Text = "Konfiguration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtKunde1 As TextBox
    Friend WithEvents txtKunde2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtKunde3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtKunde4 As TextBox
    Friend WithEvents Label4 As Label
End Class
