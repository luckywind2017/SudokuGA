Public Class SimpanSoal
    Dim namafile As String = ""
    Dim checked As Integer

    Private Sub SimpanSoalSudoku()
        Dim obj As New System.IO.StreamWriter(namafile, True)
        Dim tgl As Date = Now
        Dim tingkatkesulitan As String = ""
        Dim x, y As Integer

        'obj.WriteLine(Now.ToString("dd-MM-yyyy HH:mm:ss") + ", " + kalimat)
        tingkatkesulitan = CheckedListBox1.Items(checked).ToString.ToLower
        obj.WriteLine(tingkatkesulitan)
        For x = 1 To 9
            For y = 1 To 9
                obj.Write(Form1.boardTemp(x, y))
            Next
            obj.WriteLine("")
        Next
        obj.WriteLine("")
        obj.Close()
    End Sub

    Private Sub Button_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Browse.Click

        Dim resultDialog As DialogResult = _
            SaveFileDialog1.ShowDialog()
        If resultDialog = Windows.Forms.DialogResult.OK Then
            namafile = SaveFileDialog1.FileName
            TextBox_NamaFile.Text = SaveFileDialog1.FileName
        End If

    End Sub

    Private Sub Button_Simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Simpan.Click
        If CheckedListBox1.CheckedItems.Count <> 1 Then
            MessageBox.Show("Pilih salah satu tingkat kesulitan!", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf namafile = "" Then
            MessageBox.Show("Nama file masih kosong!", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            SimpanSoalSudoku()
            MessageBox.Show("Soal telah tersimpan", "Sudoku")
            Form1.tersimpan = True
            Me.Close()
        End If
    End Sub

    Private Sub Button_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Batal.Click
        Me.Close()
    End Sub

    Private Sub SimpanSoal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckedListBox1.SelectionMode = SelectionMode.One
        CheckedListBox1.SetItemChecked(0, True)
        CheckedListBox1.SetItemChecked(1, False)
        CheckedListBox1.SetItemChecked(2, False)
        CheckedListBox1.SetItemChecked(3, False)
        CheckedListBox1.SetItemChecked(4, False)
        checked = 0

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        CheckedListBox1.SetItemChecked(checked, False)
        checked = CheckedListBox1.SelectedIndex
    End Sub
End Class