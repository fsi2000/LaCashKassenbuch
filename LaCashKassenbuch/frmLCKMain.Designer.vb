<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLCKMain
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
        Me.components = New System.ComponentModel.Container()
        Me.cmdErzeugeKassenbuch = New System.Windows.Forms.Button()
        Me.dtpDate1 = New System.Windows.Forms.DateTimePicker()
        Me.pbKassenbuch1 = New System.Windows.Forms.ProgressBar()
        Me.rtbKassenbuch = New System.Windows.Forms.RichTextBox()
        Me.cmdSaveKassenbuch = New System.Windows.Forms.Button()
        Me.sfdKassenbuch = New System.Windows.Forms.SaveFileDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.chkSteuer = New System.Windows.Forms.CheckBox()
        Me.chkGiro = New System.Windows.Forms.CheckBox()
        Me.chkGutschein = New System.Windows.Forms.CheckBox()
        Me.pbKassenbuch2 = New System.Windows.Forms.ProgressBar()
        Me.tmrInit = New System.Windows.Forms.Timer(Me.components)
        Me.Buch2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KassendatenExportDataSet = New LaCashKassenbuch.KassendatenExportDataSet()
        Me.KassabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Buch2TableAdapter = New LaCashKassenbuch.KassendatenExportDataSetTableAdapters.buch2TableAdapter()
        Me.KassabTableAdapter = New LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kassabTableAdapter()
        Me.KasseaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KassTableAdapter = New LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kassTableAdapter()
        Me.KasseaTableAdapter = New LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kasseaTableAdapter()
        Me.cmdKonfiguration = New System.Windows.Forms.Button()
        CType(Me.Buch2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KassendatenExportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KassabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KasseaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdErzeugeKassenbuch
        '
        Me.cmdErzeugeKassenbuch.Location = New System.Drawing.Point(4, 8)
        Me.cmdErzeugeKassenbuch.Name = "cmdErzeugeKassenbuch"
        Me.cmdErzeugeKassenbuch.Size = New System.Drawing.Size(204, 23)
        Me.cmdErzeugeKassenbuch.TabIndex = 0
        Me.cmdErzeugeKassenbuch.Text = "Kassenbuch erzeugen"
        Me.cmdErzeugeKassenbuch.UseVisualStyleBackColor = True
        '
        'dtpDate1
        '
        Me.dtpDate1.CustomFormat = "MMMM yyyy"
        Me.dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate1.Location = New System.Drawing.Point(448, 8)
        Me.dtpDate1.Name = "dtpDate1"
        Me.dtpDate1.Size = New System.Drawing.Size(200, 22)
        Me.dtpDate1.TabIndex = 6
        '
        'pbKassenbuch1
        '
        Me.pbKassenbuch1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbKassenbuch1.Location = New System.Drawing.Point(652, 8)
        Me.pbKassenbuch1.Name = "pbKassenbuch1"
        Me.pbKassenbuch1.Size = New System.Drawing.Size(228, 12)
        Me.pbKassenbuch1.TabIndex = 7
        '
        'rtbKassenbuch
        '
        Me.rtbKassenbuch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbKassenbuch.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbKassenbuch.Location = New System.Drawing.Point(4, 64)
        Me.rtbKassenbuch.Name = "rtbKassenbuch"
        Me.rtbKassenbuch.Size = New System.Drawing.Size(876, 446)
        Me.rtbKassenbuch.TabIndex = 10
        Me.rtbKassenbuch.Text = ""
        Me.rtbKassenbuch.ZoomFactor = 0.5!
        '
        'cmdSaveKassenbuch
        '
        Me.cmdSaveKassenbuch.Location = New System.Drawing.Point(4, 36)
        Me.cmdSaveKassenbuch.Name = "cmdSaveKassenbuch"
        Me.cmdSaveKassenbuch.Size = New System.Drawing.Size(204, 23)
        Me.cmdSaveKassenbuch.TabIndex = 1
        Me.cmdSaveKassenbuch.Text = "Kassenbuch speichern..."
        Me.cmdSaveKassenbuch.UseVisualStyleBackColor = True
        '
        'sfdKassenbuch
        '
        Me.sfdKassenbuch.DefaultExt = "rtf"
        Me.sfdKassenbuch.Filter = "Rich Text Format (*.rtf)|*.rtf"
        Me.sfdKassenbuch.FilterIndex = 0
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Location = New System.Drawing.Point(448, 40)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(432, 16)
        Me.lblStatus.TabIndex = 9
        '
        'chkSteuer
        '
        Me.chkSteuer.AutoSize = True
        Me.chkSteuer.Enabled = False
        Me.chkSteuer.Location = New System.Drawing.Point(396, 40)
        Me.chkSteuer.Name = "chkSteuer"
        Me.chkSteuer.Size = New System.Drawing.Size(59, 17)
        Me.chkSteuer.TabIndex = 2
        Me.chkSteuer.Text = "Steuer"
        Me.chkSteuer.UseVisualStyleBackColor = True
        Me.chkSteuer.Visible = False
        '
        'chkGiro
        '
        Me.chkGiro.AutoSize = True
        Me.chkGiro.Enabled = False
        Me.chkGiro.Location = New System.Drawing.Point(396, 12)
        Me.chkGiro.Name = "chkGiro"
        Me.chkGiro.Size = New System.Drawing.Size(48, 17)
        Me.chkGiro.TabIndex = 5
        Me.chkGiro.Text = "Giro"
        Me.chkGiro.UseVisualStyleBackColor = True
        Me.chkGiro.Visible = False
        '
        'chkGutschein
        '
        Me.chkGutschein.AutoSize = True
        Me.chkGutschein.Location = New System.Drawing.Point(240, 12)
        Me.chkGutschein.Name = "chkGutschein"
        Me.chkGutschein.Size = New System.Drawing.Size(132, 17)
        Me.chkGutschein.TabIndex = 4
        Me.chkGutschein.Text = "Gutscheine auflisten"
        Me.chkGutschein.UseVisualStyleBackColor = True
        '
        'pbKassenbuch2
        '
        Me.pbKassenbuch2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbKassenbuch2.Location = New System.Drawing.Point(652, 20)
        Me.pbKassenbuch2.Name = "pbKassenbuch2"
        Me.pbKassenbuch2.Size = New System.Drawing.Size(228, 12)
        Me.pbKassenbuch2.TabIndex = 8
        '
        'tmrInit
        '
        '
        'Buch2BindingSource
        '
        Me.Buch2BindingSource.DataMember = "buch2"
        Me.Buch2BindingSource.DataSource = Me.KassendatenExportDataSet
        '
        'KassendatenExportDataSet
        '
        Me.KassendatenExportDataSet.DataSetName = "KassendatenExportDataSet"
        Me.KassendatenExportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KassabBindingSource
        '
        Me.KassabBindingSource.DataMember = "kassab"
        Me.KassabBindingSource.DataSource = Me.KassendatenExportDataSet
        '
        'Buch2TableAdapter
        '
        Me.Buch2TableAdapter.ClearBeforeFill = True
        '
        'KassabTableAdapter
        '
        Me.KassabTableAdapter.ClearBeforeFill = True
        '
        'KasseaBindingSource
        '
        Me.KasseaBindingSource.DataMember = "kassea"
        Me.KasseaBindingSource.DataSource = Me.KassendatenExportDataSet
        '
        'KassBindingSource
        '
        Me.KassBindingSource.DataMember = "kass"
        Me.KassBindingSource.DataSource = Me.KassendatenExportDataSet
        '
        'KassTableAdapter
        '
        Me.KassTableAdapter.ClearBeforeFill = True
        '
        'KasseaTableAdapter
        '
        Me.KasseaTableAdapter.ClearBeforeFill = True
        '
        'cmdKonfiguration
        '
        Me.cmdKonfiguration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKonfiguration.Location = New System.Drawing.Point(778, 40)
        Me.cmdKonfiguration.Name = "cmdKonfiguration"
        Me.cmdKonfiguration.Size = New System.Drawing.Size(102, 24)
        Me.cmdKonfiguration.TabIndex = 11
        Me.cmdKonfiguration.Text = "Konfiguration"
        Me.cmdKonfiguration.UseVisualStyleBackColor = True
        '
        'frmLCKMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 512)
        Me.Controls.Add(Me.cmdKonfiguration)
        Me.Controls.Add(Me.pbKassenbuch2)
        Me.Controls.Add(Me.chkGutschein)
        Me.Controls.Add(Me.chkGiro)
        Me.Controls.Add(Me.chkSteuer)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmdSaveKassenbuch)
        Me.Controls.Add(Me.rtbKassenbuch)
        Me.Controls.Add(Me.pbKassenbuch1)
        Me.Controls.Add(Me.dtpDate1)
        Me.Controls.Add(Me.cmdErzeugeKassenbuch)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(600, 350)
        Me.Name = "frmLCKMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LaCash-Kassenbuch"
        CType(Me.Buch2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KassendatenExportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KassabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KasseaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdErzeugeKassenbuch As System.Windows.Forms.Button
	Friend WithEvents KassendatenExportDataSet As LaCashKassenbuch.KassendatenExportDataSet
	Friend WithEvents Buch2BindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents Buch2TableAdapter As LaCashKassenbuch.KassendatenExportDataSetTableAdapters.buch2TableAdapter
	Friend WithEvents dtpDate1 As System.Windows.Forms.DateTimePicker
	Friend WithEvents KassabBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents KassabTableAdapter As LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kassabTableAdapter
	Friend WithEvents KassBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents KassTableAdapter As LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kassTableAdapter
	Friend WithEvents KasseaBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents KasseaTableAdapter As LaCashKassenbuch.KassendatenExportDataSetTableAdapters.kasseaTableAdapter
	Friend WithEvents pbKassenbuch1 As System.Windows.Forms.ProgressBar
	Friend WithEvents rtbKassenbuch As System.Windows.Forms.RichTextBox
	Friend WithEvents cmdSaveKassenbuch As System.Windows.Forms.Button
	Friend WithEvents sfdKassenbuch As System.Windows.Forms.SaveFileDialog
	Friend WithEvents lblStatus As System.Windows.Forms.Label
	Friend WithEvents chkSteuer As System.Windows.Forms.CheckBox
	Friend WithEvents chkGiro As System.Windows.Forms.CheckBox
	Friend WithEvents chkGutschein As System.Windows.Forms.CheckBox
	Friend WithEvents pbKassenbuch2 As System.Windows.Forms.ProgressBar
	Friend WithEvents tmrInit As System.Windows.Forms.Timer
	Friend WithEvents cmdKonfiguration As Button
End Class
