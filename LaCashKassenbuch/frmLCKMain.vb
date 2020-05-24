Public Class frmLCKMain

	Private Sub frmLCKMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		dtpDate1.Value = New Date(Now.Year, Now.Month, 1)
		Me.Text = Me.Text + " v" + prgVersion
		LoadSettings()
		tmrInit.Start()
	End Sub

	Private Sub frmLCKMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		SaveSettings()
	End Sub

	Private Sub LoadSettings()
		dtpDate1.Value = My.Settings.Datum
		chkSteuer.Checked = My.Settings.Steuer
		chkGiro.Checked = My.Settings.Giro
		chkGutschein.Checked = My.Settings.Gutschein
	End Sub

	Private Sub SaveSettings()
		My.Settings.Datum = dtpDate1.Value
		My.Settings.Steuer = chkSteuer.Checked
		My.Settings.Giro = chkGiro.Checked
		My.Settings.Gutschein = chkGutschein.Checked
	End Sub

	Private Sub cmdErzeugeKassenbuch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdErzeugeKassenbuch.Click
		Dim i As Integer
		Dim days As Integer
		Dim dt As Date
		Dim dt1, dt2 As DateTime

		KassenbuchLoeschen()

		dt = New Date(dtpDate1.Value.Year, dtpDate1.Value.Month, 1)				'erster tag des monats

		ErzeugeHeader(dt)

		cmdErzeugeKassenbuch.Enabled = False
		cmdSaveKassenbuch.Enabled = False
		days = DateTime.DaysInMonth(dtpDate1.Value.Year, dtpDate1.Value.Month)
		pbKassenbuch1.Maximum = days
		For i = 0 To days - 1
			'For i = 7 To 7
			dt = New Date(dtpDate1.Value.Year, dtpDate1.Value.Month, dtpDate1.Value.Day)
			dt = dt.AddDays(i)
			dt1 = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
			dt2 = New DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59)

			lblStatus.Text = "Überprüfe Daten vom " + dt.ToString("d. MMMM yyyy")
			DoEvents()
			'progress bar anpassen
			pbKassenbuch1.Value = i + 1

			'kassenbestände
			Me.KassabTableAdapter.FillByDateFromTo(Me.KassendatenExportDataSet.kassab, dt1, dt2)

			If KassabBindingSource.Count = 0 Then
				lblStatus.Text = lblStatus.Text + " - keine Daten vorhanden"
			Else
				lblStatus.Text = lblStatus.Text + "...Daten werden verarbeitet"
				DoEvents()
			End If
			DoEvents()

			'buchungen
			Me.Buch2TableAdapter.FillByDateFromTo(Me.KassendatenExportDataSet.buch2, dt1, dt2)

			If Buch2BindingSource.Count > 0 Then
				ErzeugeKassenbuch(dt)
				ErzeugeTrennlinie()
			End If

			DoEvents()
		Next
		cmdErzeugeKassenbuch.Enabled = True
		cmdSaveKassenbuch.Enabled = True

		HinzufuegenZeile(True, "v" + prgVersion)
		HinzufuegenZeile(True, "Druckdatum: " + Now.ToString)

		Clipboard.SetText(rtbKassenbuch.Text)
		lblStatus.Text = ""
	End Sub

	Private Sub cmdSaveKassenbuch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveKassenbuch.Click
		If sfdKassenbuch.ShowDialog = Windows.Forms.DialogResult.OK Then				'save as dialog
			rtbKassenbuch.SaveFile(sfdKassenbuch.FileName)
		End If
	End Sub

	Private Sub ErzeugeTrennlinie()
		HinzufuegenZeile(False, "")
		HinzufuegenZeile(False, "")
		HinzufuegenZeile(False, "")
	End Sub

	Private Sub ErzeugeHeader(ByVal dt As DateTime)
		Dim days As Integer
		Dim dt1, dt2 As DateTime

		days = DateTime.DaysInMonth(dt.Year, dt.Month)
		dt1 = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
		dt2 = dt1.AddDays(days - 1)

		HinzufuegenZeile(True, My.Settings.Kunde1)
		HinzufuegenZeile(True, My.Settings.Kunde2)
		HinzufuegenZeile(True, My.Settings.Kunde3)
		HinzufuegenZeile(True, My.Settings.Kunde4)
		HinzufuegenZeile(False, "")
		HinzufuegenZeile(False, "")
		HinzufuegenZeile(False, "KASSENBUCH VOM " + dt1.ToString(formatDatum) + " BIS " + dt2.ToString(formatDatum))
		HinzufuegenZeile(False, "")
		HinzufuegenZeile(False, "")
	End Sub

	Private Sub ErzeugeAnfangsbestand(ByVal dt As DateTime, ByVal betrag As Single)
		Dim s1 As String
		Dim s2 As String

		s1 = dt.ToString(formatDatum) + "     ANFANGSBESTAND"
		s2 = betrag.ToString("0.00") + " EUR"
		HinzufuegenZeileLinksRechts(True, s1, s2, " ")
		HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
	End Sub

	Private Sub ErzeugeAnfangsbestand2(ByVal dt As DateTime, ByVal betrag As Single)
		Dim s As String

		s = dt.ToString(formatDatum)
		HinzufuegenZeileBestand(s, "ANFANGSBESTAND", -1, -1, betrag)
		HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
	End Sub

	Private Sub ErzeugeEndbestand(ByVal dt As DateTime, ByVal betrag As Single)
		Dim s1 As String
		Dim s2 As String

		s1 = "ENDBESTAND"
		s2 = betrag.ToString("0.00") + " EUR"

		HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
		HinzufuegenZeileLinksRechts(True, s1, s2, " ")
		'HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
	End Sub

	Private Sub ErzeugeEndbestand2(ByVal dt As DateTime, ByVal summeEinnahme As Single, ByVal summeAusgabe As Single, ByVal betrag As Single)
		HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
		HinzufuegenZeileBestand("", "ENDBESTAND", summeEinnahme, summeAusgabe, betrag)
		'HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
		HinzufuegenZeileBestand("", "SALDO", -1, -1, summeEinnahme - summeAusgabe)
		'HinzufuegenZeileLinksRechts(True, "", "————————————", " ")
	End Sub

	Private Sub ErzeugeKassenbuch(ByVal dt As DateTime)
		Dim i As Integer

		Dim betrag As Single
		Dim zahlart As String
		Dim txt As String
		Dim datumzeit As DateTime
		Dim bunr2 As Integer
		Dim bunr As Integer
		Dim typ As Integer
		Dim steuersatz As Single
		Dim umsatzsteuer As Single

		Dim calcKassenbestand As Single				'laufender kassenbestand
		Dim summeEinnahme As Single					'summe dewr einnahmen
		Dim summeAusgabe As Single					'summe der ausgaben

		HinzufuegenSpaltenUeberschriften()
		betrag = KassabBindingSource.Current("startbetrag") / 100				'convert cent in EUR
		'ErzeugeAnfangsbestand(dt, betrag)
		ErzeugeAnfangsbestand2(dt, betrag)

		calcKassenbestand = betrag									'speichere kassenbestand
		summeEinnahme = 0					'laufende summen zurücksetzen
		summeAusgabe = 0

		pbKassenbuch2.Maximum = Buch2BindingSource.Count - 1
		For i = 0 To Buch2BindingSource.Count - 1
			Buch2BindingSource.Position = i
			pbKassenbuch2.Value = i
			zahlart = Buch2BindingSource.Current("zahlart")
			betrag = Buch2BindingSource.Current("betrag") / 100				'convert cent in EUR
			txt = Buch2BindingSource.Current("txt")
			datumzeit = Buch2BindingSource.Current("datumzeit")
			bunr2 = Buch2BindingSource.Current("bunr2")
			bunr = Buch2BindingSource.Current("bunr")
			typ = Buch2BindingSource.Current("typ")

			If zahlart = "BAR" Then
				calcKassenbestand = calcKassenbestand + betrag							'neuen kassenbestand errechnen

				If txt = "VERKAUF" Then txt = "BARVERKAUF" 'begriffe ändern

				Select Case typ
					Case 0			'verkauf
						'suchen in kass (feld bunr)
						Me.KassTableAdapter.FillByBuNr(Me.KassendatenExportDataSet.kass, bunr)
						umsatzsteuer = KassBindingSource.Current("mwst1") / 100
						steuersatz = 100 / (Math.Abs(betrag) - Math.Abs(umsatzsteuer)) * Math.Abs(umsatzsteuer)
						If betrag < 0 Then umsatzsteuer = 0 : steuersatz = 0
						If betrag < 0 Then txt = txt + " STORNO"
					Case 1			'ausgabe
						'suchen in kassea (feld bunr)
						Me.KasseaTableAdapter.FillByBuNr(Me.KassendatenExportDataSet.kassea, bunr)
						steuersatz = KasseaBindingSource.Current("mwst")
						umsatzsteuer = KasseaBindingSource.Current("mwst1") / 100
						'bunr = -1
						bunr = bunr + 100000
				End Select

				If betrag > 0 Then									'beträge zusammenzählen
					summeEinnahme = summeEinnahme + Math.Abs(betrag)
				Else
					summeAusgabe = summeAusgabe + Math.Abs(betrag)
				End If

				ErzeugeKassenbuchZeileBar(datumzeit, bunr, txt, betrag, steuersatz, umsatzsteuer, calcKassenbestand)
			End If

			If zahlart = "GUTSCH" Then
				If chkGutschein.Checked Then ErzeugeKassenbuchZeileGutschein(datumzeit, bunr, betrag, calcKassenbestand)
			End If

			If zahlart = "GIRO" Then
				If chkGiro.Checked Then ErzeugeKassenbuchZeileGiro(datumzeit, bunr, txt, betrag, calcKassenbestand)
			End If
			DoEvents()
		Next

		betrag = KassabBindingSource.Current("endbetrag") / 100				'convert cent in EUR
		'ErzeugeEndbestand(dt, betrag)
		ErzeugeEndbestand2(dt, summeEinnahme, summeAusgabe, betrag)
	End Sub

	Private Sub KassenbuchLoeschen()
		rtbKassenbuch.Text = ""
	End Sub

	Private Sub ErzeugeKassenbuchZeileBar(ByVal zeitstempel As DateTime, ByVal bonnummer As Integer, ByVal buchungstext As String, ByVal betrag As Single, ByVal steuersatz As Single, ByVal umsatzsteuer As Single, ByVal kassenbestand As Single)
		Dim result As String
		Dim s As String
		Dim d As Single

		result = ""

		s = zeitstempel.ToString(formatZeit)
		result = result + s.PadRight(sZeitstempelZeit) + sTrennzeichen

		s = bonnummer.ToString
		If bonnummer = -1 Then s = "" 'keine bonnummer drucken
		result = result + s.PadLeft(sBonNummer) + sTrennzeichen

		'*** buchungstext
		s = buchungstext
		result = result + s.PadRight(sBuchungstext) + sTrennzeichen

		'*** einnahme
		s = ""
		If betrag > 0 Then
			d = Math.Abs(betrag)
			s = d.ToString("0.00") + " EUR"
		End If
		result = result + s.PadLeft(sEinnahme) + sTrennzeichen

		'*** ausgaben
		s = ""
		If betrag < 0 Then
			d = Math.Abs(betrag)
			s = d.ToString("0.00") + " EUR"
		End If
		result = result + s.PadLeft(sAusgabe) + sTrennzeichen

		'*** steuersatz
		s = ""
		If chkSteuer.Checked Then
			s = steuersatz.ToString("0.0") + "%"
			If steuersatz = 0 Then s = ""
		End If
		result = result + s.PadRight(sSteuersatz) + sTrennzeichen

		'*** umsatzsteuer
		s = ""
		If chkSteuer.Checked Then
			d = Math.Abs(umsatzsteuer)
			s = d.ToString("0.00") + " EUR"
			If umsatzsteuer = 0 Then s = ""
		End If
		result = result + s.PadLeft(sUmsatzsteuer) + sTrennzeichen

		'*** kassenbestand
		s = kassenbestand.ToString("0.00") + " EUR"
		result = result + s.PadLeft(sKassenbestand) + sTrennzeichen

		HinzufuegenZeile(False, result)
	End Sub

	Private Sub ErzeugeKassenbuchZeileGutschein(ByVal zeitstempel As DateTime, ByVal bonnummer As Integer, ByVal betrag As Single, ByVal kassenbestand As Single)
		Dim result As String
		Dim s As String
		Dim d As Double

		result = ""

		s = zeitstempel.ToString(formatZeit)
		result = result + s.PadRight(sZeitstempelZeit) + sTrennzeichen

		s = bonnummer.ToString
		result = result + s.PadLeft(sBonNummer) + sTrennzeichen

		'*** buchungstext
		s = "* Gutschein"
		If betrag < 0 Then s = s + " ausgegeben"
		If betrag > 0 Then s = s + " eingelöst"
		d = Math.Abs(betrag)
		s = s + " "
		s = s + "(" + d.ToString("0.00") + " EUR" + ")"

		result = result + s.PadRight(sBuchungstext) + sTrennzeichen

		'*** einnahme
		s = ""
		result = result + s.PadLeft(sEinnahme) + sTrennzeichen

		'*** ausgaben
		s = ""
		result = result + s.PadLeft(sAusgabe) + sTrennzeichen

		'*** steuersatz
		s = ""
		result = result + s.PadRight(sSteuersatz) + sTrennzeichen

		'*** umsatzsteuer
		s = ""
		result = result + s.PadLeft(sUmsatzsteuer) + sTrennzeichen

		'*** kassenbestand
		s = kassenbestand.ToString("0.00") + " EUR"
		s = ""
		result = result + s.PadLeft(sKassenbestand) + sTrennzeichen

		HinzufuegenZeile(False, result)
	End Sub

	Private Sub ErzeugeKassenbuchZeileGiro(ByVal zeitstempel As DateTime, ByVal bonnummer As Integer, ByVal buchungstext As String, ByVal betrag As Single, ByVal kassenbestand As Single)
		Dim result As String
		Dim s As String

		result = ""

		s = zeitstempel.ToString(formatZeit)
		result = result + s.PadRight(sZeitstempelZeit) + sTrennzeichen

		s = bonnummer.ToString
		result = result + s.PadLeft(sBonNummer) + sTrennzeichen

		'*** buchungstext
		s = "KARTENZAHLUNG / GIRO"
		result = result + s.PadRight(sBuchungstext) + sTrennzeichen

		'*** einnahme
		s = ""
		result = result + s.PadLeft(sEinnahme) + sTrennzeichen

		'*** ausgaben
		s = ""
		result = result + s.PadLeft(sAusgabe) + sTrennzeichen

		'*** steuersatz
		s = ""
		result = result + s.PadRight(sSteuersatz) + sTrennzeichen

		'*** umsatzsteuer
		s = ""
		result = result + s.PadLeft(sUmsatzsteuer) + sTrennzeichen

		'*** kassenbestand
		s = kassenbestand.ToString("0.00") + " EUR"
		s = ""
		result = result + s.PadLeft(sKassenbestand) + sTrennzeichen

		HinzufuegenZeile(False, result)
	End Sub

	Private Sub DoEvents()
		Dim i As Integer
		For i = 0 To 1599
			Application.DoEvents() : Application.DoEvents() : Application.DoEvents()
			Application.DoEvents() : Application.DoEvents() : Application.DoEvents()
			Application.DoEvents() : Application.DoEvents() : Application.DoEvents()
		Next
	End Sub

	Private Sub HinzufuegenZeile(ByVal bold As Boolean, ByVal s As String)
		Dim ss As Integer

		ss = rtbKassenbuch.TextLength

		rtbKassenbuch.AppendText(s + vbCrLf)
		If bold Then
			rtbKassenbuch.SelectionStart = ss
			rtbKassenbuch.SelectionLength = rtbKassenbuch.TextLength - ss
			rtbKassenbuch.SelectionFont = New Font(rtbKassenbuch.Font.Name, rtbKassenbuch.Font.Size, FontStyle.Bold)
		End If
	End Sub

	Private Sub HinzufuegenZeileLinksRechts(ByVal bold As Boolean, ByVal s1 As String, ByVal s2 As String, ByVal padchar As Char)
		Dim links, rechts As Integer

		links = sSpalteBreite \ 2
		rechts = sSpalteBreite - links
		HinzufuegenZeile(bold, s1.PadRight(links, padchar) + s2.PadLeft(rechts, padchar))
	End Sub

	Private Sub HinzufuegenZeileBestand(ByVal datum As String, ByVal beschreibung As String, ByVal summeEinnahme As Single, ByVal summeAusgabe As Single, ByVal kassenBestand As Single)
		Dim s As String
		Dim result As String

		result = ""

		s = datum
		result = result + s.PadRight(sZeitstempelDatum) + sTrennzeichen

		s = beschreibung
		result = result + s.PadRight(sBuchungstext) + sTrennzeichen

		If summeEinnahme < 0 Then s = "" Else s = summeEinnahme.ToString("0.00") + " EUR"
		result = result + s.PadLeft(sEinnahme) + sTrennzeichen

		If summeAusgabe < 0 Then s = "" Else s = summeAusgabe.ToString("0.00") + " EUR"
		result = result + s.PadLeft(sAusgabe) + sTrennzeichen

		s = ""
		result = result + s.PadRight(sSteuersatz) + sTrennzeichen

		s = ""
		result = result + s.PadLeft(sUmsatzsteuer) + sTrennzeichen

		s = kassenBestand.ToString("0.00") + " EUR"
		result = result + s.PadLeft(sKassenbestand)

		HinzufuegenZeile(True, result)
	End Sub

	Private Sub HinzufuegenSpaltenUeberschriften()
		Dim s As String
		Dim result As String

		result = ""

		s = "ZEIT"
		result = result + s.PadRight(sZeitstempelZeit) + sTrennzeichen

		s = "BON-NR"
		result = result + s.PadLeft(sBonNummer) + sTrennzeichen

		'*** buchungstext
		s = "TEXT"
		result = result + s.PadRight(sBuchungstext) + sTrennzeichen

		'*** einnahme
		s = "EINNAHME"
		result = result + s.PadLeft(sEinnahme) + sTrennzeichen

		'*** ausgaben
		s = "AUSGABE"
		result = result + s.PadLeft(sAusgabe) + sTrennzeichen

		'*** steuersatz
		If chkSteuer.Checked Then s = "UST%" Else s = ""
		result = result + s.PadRight(sSteuersatz) + sTrennzeichen

		'*** umsatzsteuer
		If chkSteuer.Checked Then s = "UMSATZSTEUER" Else s = ""
		result = result + s.PadLeft(sUmsatzsteuer) + sTrennzeichen

		'*** kassenbestand
		s = "KASSENBEST."
		result = result + s.PadLeft(sKassenbestand) + sTrennzeichen


		sSpalteBreite = result.Length					'breite der gesamten spalte speichern
		sSpalteBreite = sSpalteBreite - sTrennzeichen.Length

		HinzufuegenZeile(True, result)

		s = StrDup(sSpalteBreite, "—")				'linie erzeugen
		HinzufuegenZeile(False, s)
		'        1234567890  12345  12345678901234567890123456789012345  123456789012  123456789012  12345  123456789012  123456789012
		'        123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567
	End Sub

	Private Sub dtpDate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate1.ValueChanged
		dtpDate1.Value = New Date(dtpDate1.Value.Year, dtpDate1.Value.Month, 1)
	End Sub

	Private Sub tmrInit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInit.Tick
		Dim s As String
		Dim d As DateTime
		Dim filename As String

		tmrInit.Stop()

		d = Now
		d = d.AddMonths(-1)

		If My.Computer.FileSystem.FileExists("KassendatenExport.MDB") Then
			d = My.Computer.FileSystem.GetFileInfo("KassendatenExport.MDB").LastWriteTime
			d = d.AddMonths(-1)
		End If

		filename = d.ToString("yyyy MMMM") + " Kassenbuch.rtf"

		s = ""
		s = s + "Soll für für " + d.ToString("MMMM yyyy") + " ein Kassenbuch erzeugt werden und dieses unter dem Dateinamen '" + filename + "' gespeichert werden, dieses Programm beendet und das Kassenbuch in einer Textverarbeitung geöffnet werden?" + vbCrLf
		s = s + vbCrLf
		s = s + "HINWEIS: Die Daten aus der Kasse müssen exportiert worden sein, bevor dieses Programm gestartet wird!"
		If MessageBox.Show(s, "Kassenbuch automatisch erstellen?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
			dtpDate1.Value = d
			cmdErzeugeKassenbuch_Click(sender, e)

			sfdKassenbuch.FileName = filename
			cmdSaveKassenbuch_Click(sender, e)
			If My.Computer.FileSystem.FileExists(sfdKassenbuch.FileName) Then
				Process.Start(sfdKassenbuch.FileName)
			End If

			Application.Exit()
		End If
	End Sub

	Private Sub cmdKonfiguration_Click(sender As Object, e As EventArgs) Handles cmdKonfiguration.Click
		frmLCKConfig.ShowDialog()
	End Sub
End Class