Public Class frmLCKConfig
    Private Sub frmLCKConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub
    Private Sub LoadSettings()
        txtKunde1.Text = My.Settings.Kunde1
        txtKunde2.Text = My.Settings.Kunde2
        txtKunde3.Text = My.Settings.Kunde3
        txtKunde4.Text = My.Settings.Kunde4
    End Sub

    Private Sub SaveSettings()
        My.Settings.Kunde1 = txtKunde1.Text
        My.Settings.Kunde2 = txtKunde2.Text
        My.Settings.Kunde3 = txtKunde3.Text
        My.Settings.Kunde4 = txtKunde4.Text
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        SaveSettings()
        Me.Close()
    End Sub
End Class