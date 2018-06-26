Public Class Form_BuatSoal



    Dim btnCell As Button
    Dim angkaCell As Char
    Dim papan(9, 9) As Char
    Dim barisG, kolomG As Byte
    Dim barisErr, kolomErr, regionErr As Byte
    Dim bkSalahRegion(27, 2, 2) As Char
    Dim bkSalahBaris(27, 2, 2) As Char
    Dim bkSalahKolom(27, 2, 2) As Char


    Private Sub cekValiditasAngka(ByRef barisBenar As Boolean, _
                                  ByRef kolomBenar As Boolean, _
                                  ByRef regionBenar As Boolean)

        Dim i, j, x, y, r, c, cc As Byte
        barisBenar = True
        kolomBenar = True
        regionBenar = True

        '=> Cek apakah semua baris sesuai dengan aturan Sudoku
        c = 0
        For i = 1 To 9
            For x = 1 To 8
                For y = x + 1 To 9
                    If papan(i, x) <> "0" Then
                        If papan(i, x) = papan(i, y) Then
                            Debug.WriteLine(i.ToString + "," + x.ToString + "|" + i.ToString + "," + y.ToString + "=" + papan(i, x).ToString)
                            barisBenar = False
                            '=> Menyimpan angka yang sebaris pada array
                            c += 1
                            bkSalahBaris(c, 1, 1) = i.ToString
                            bkSalahBaris(c, 1, 2) = x.ToString
                            bkSalahBaris(c, 2, 1) = i.ToString
                            bkSalahBaris(c, 2, 2) = y.ToString
                        End If
                    End If
                Next
            Next
        Next
        barisErr = c

        '=> Cek apakah semua kolom sesuai dengan aturan Sudoku
        c = 0
        For j = 1 To 9
            For x = 1 To 8
                For y = x + 1 To 9
                    If papan(x, j) <> "0" Then
                        If papan(x, j) = papan(y, j) Then
                            kolomBenar = False
                            Debug.WriteLine(x.ToString + "," + j.ToString + "|" + x.ToString + "," + j.ToString + "=" + papan(x, j).ToString)
                            c += 1
                            '=> Menyimpan angka yang sekolom pada array
                            bkSalahKolom(c, 1, 1) = x.ToString
                            bkSalahKolom(c, 1, 2) = j.ToString
                            bkSalahKolom(c, 2, 1) = y.ToString
                            bkSalahKolom(c, 2, 2) = j.ToString
                        End If
                    End If
                Next
            Next
        Next
        kolomErr = c

        '=> Cek apakah semua region sesuai dengan aturan Sudoku
        c = 0
        For r = 1 To 9
            Dim arrReg(9, 3) As Byte '=> Menyimpan satu region ke dalam array
            Array.Clear(arrReg, 0, 10)
            cc = 0
            For x = ((r - 1) \ 3) * 3 + 1 To ((r - 1) \ 3) * 3 + 3
                For y = 3 * ((r - 1) Mod 3) + 1 To 3 * ((r - 1) Mod 3) + 3
                    cc += 1
                    arrReg(cc, 1) = papan(x, y).ToString
                    arrReg(cc, 2) = x
                    arrReg(cc, 3) = y
                Next
            Next

            '=> Mengecek apakah ada angka yang sama dalam region yang tersimpan
            For i = 1 To 8
                For j = i + 1 To 9
                    If (arrReg(i, 1) <> 0) And (arrReg(j, 1) <> 0) Then
                        If arrReg(i, 1) = arrReg(j, 1) Then
                            regionBenar = False
                            Debug.WriteLine(arrReg(i, 2).ToString + "," + arrReg(i, 3).ToString + "|" + arrReg(j, 2).ToString + "," + arrReg(j, 3).ToString + "=" + arrReg(i, 1).ToString)
                            '=> Menyimpan angka yang sekolom pada array
                            c += 1
                            bkSalahRegion(c, 1, 1) = arrReg(i, 2).ToString
                            bkSalahRegion(c, 1, 2) = arrReg(i, 3).ToString
                            bkSalahRegion(c, 2, 1) = arrReg(j, 2).ToString
                            bkSalahRegion(c, 2, 2) = arrReg(j, 3).ToString
                        End If
                    End If
                Next
            Next
        Next
        regionErr = c
    End Sub
    Private Sub TombolP_Klik(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cell55.Click, Cell99.Click, Cell98.Click, Cell97.Click, Cell96.Click, Cell95.Click, Cell94.Click, Cell93.Click, Cell92.Click, Cell91.Click, Cell89.Click, Cell88.Click, Cell87.Click, Cell86.Click, Cell85.Click, Cell84.Click, Cell83.Click, Cell82.Click, Cell81.Click, Cell79.Click, Cell78.Click, Cell77.Click, Cell76.Click, Cell75.Click, Cell74.Click, Cell73.Click, Cell72.Click, Cell71.Click, Cell69.Click, Cell68.Click, Cell67.Click, Cell66.Click, Cell65.Click, Cell64.Click, Cell63.Click, Cell62.Click, Cell61.Click, Cell59.Click, Cell58.Click, Cell57.Click, Cell56.Click, Cell54.Click, Cell53.Click, Cell52.Click, Cell51.Click, Cell49.Click, Cell48.Click, Cell47.Click, Cell46.Click, Cell45.Click, Cell44.Click, Cell43.Click, Cell42.Click, Cell41.Click, Cell39.Click, Cell38.Click, Cell37.Click, Cell36.Click, Cell35.Click, Cell34.Click, Cell33.Click, Cell32.Click, Cell31.Click, Cell29.Click, Cell28.Click, Cell27.Click, Cell26.Click, Cell25.Click, Cell24.Click, Cell23.Click, Cell22.Click, Cell21.Click, Cell19.Click, Cell18.Click, Cell17.Click, Cell16.Click, Cell15.Click, Cell14.Click, Cell13.Click, Cell12.Click, Cell11.Click
        '--> Prosedur klik untuk semua kotak kosong di bidang permainan Sudoku
        Dim TombolAngka As Button = sender

        barisG = TombolAngka.Name.Substring(4, 1)
        kolomG = TombolAngka.Name.Substring(5, 1)

        Dim P As New Point(Cursor.Position)
        Panel1.Location = PointToClient(Cursor.Position)
        btnCell = TombolAngka
        Panel1.Show()
    End Sub
    Private Sub AngkaPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label4.Click, Label3.Click, Label2.Click, Label1.Click
        'Prosedur untuk menyimpan teks angka yang dipilih
        '--> Prosedur untuk semua label angka di panel kecil (panel untuk memilih angka)
        Panel1.Visible = False
        btnCell.Text = sender.text
        btnCell.ForeColor = Color.Black
        papan(barisG, kolomG) = sender.text
    End Sub
    Private Sub Button_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_batal.Click
        Panel1.Visible = False
    End Sub
    Private Sub Button_Hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_hapus.Click
        Panel1.Visible = False
        btnCell.Text = ""
        btnCell.BackColor = Color.White
        papan(barisG, kolomG) = "0"
    End Sub
    'Private Sub Isi_ke_Array(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_hapus.Click, Cell99.Leave, Cell98.Leave, Cell97.Leave, Cell96.Leave, Cell95.Leave, Cell94.Leave, Cell93.Leave, Cell92.Leave, Cell91.Leave, Cell89.Leave, Cell88.Leave, Cell87.Leave, Cell86.Leave, Cell85.Leave, Cell84.Leave, Cell83.Leave, Cell82.Leave, Cell81.Leave, Cell79.Leave, Cell78.Leave, Cell77.Leave, Cell76.Leave, Cell75.Leave, Cell74.Leave, Cell73.Leave, Cell72.Leave, Cell71.Leave, Cell69.Leave, Cell68.Leave, Cell67.Leave, Cell66.Leave, Cell65.Leave, Cell64.Leave, Cell63.Leave, Cell62.Leave, Cell61.Leave, Cell59.Leave, Cell58.Leave, Cell57.Leave, Cell56.Leave, Cell55.Leave, Cell54.Leave, Cell53.Leave, Cell52.Leave, Cell51.Leave, Cell49.Leave, Cell48.Leave, Cell47.Leave, Cell46.Leave, Cell45.Leave, Cell44.Leave, Cell43.Leave, Cell42.Leave, Cell41.Leave, Cell39.Leave, Cell38.Leave, Cell37.Leave, Cell36.Leave, Cell35.Leave, Cell34.Leave, Cell33.Leave, Cell32.Leave, Cell31.Leave, Cell29.Leave, Cell28.Leave, Cell27.Leave, Cell26.Leave, Cell25.Leave, Cell24.Leave, Cell23.Leave, Cell22.Leave, Cell21.Leave, Cell19.Leave, Cell18.Leave, Cell17.Leave, Cell16.Leave, Cell15.Leave, Cell14.Leave, Cell13.Leave, Cell12.Leave, Cell11.Leave
    '    papan(barisG, kolomG) = angkaCell
    'End Sub
    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        If KeluarDialog("Pengisian papan tidak akan tersimpan. Anda yakin ingin keluar?", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2) Then
            Me.Close()
        End If
    End Sub
    Public Function GetChildControls(ByVal parent As Control) As ArrayList
        'Mengembalikan daftar semua child control di dalam sebuah control
        Dim hasil As New ArrayList()
        For Each ctrl As Control In parent.Controls
            hasil.Add(ctrl)
            hasil.AddRange(GetChildControls(ctrl))
        Next
        Return hasil
    End Function

    Private Sub inisialisasiPapan()
        Dim i, j As Byte
        For i = 1 To 9
            For j = 1 To 9
                papan(i, j) = "0"
            Next
        Next
        'Mengisi kotak cell sesuai soal
        Dim tempControl As Control

        For i = 1 To 9
            For j = 1 To 9
                For Each tempControl In GetChildControls(TableLayoutPanel_Besar)
                    Dim namaControl As String = "Cell" + i.ToString + j.ToString
                    If tempControl.Name = namaControl Then
                        tempControl.Text = ""
                        tempControl.Enabled = True
                        tempControl.ForeColor = Color.Black
                        tempControl.BackColor = Color.White
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub InisialisasiWarnaIsiKotak(ByVal warna As Color)
        Dim tempControl As Control
        For Each tempControl In Form1.GetChildControls(TableLayoutPanel_Besar)
            tempControl.ForeColor = Color.Black
        Next
    End Sub
    Private Sub PewarnaanIsiKotak(ByVal baris1 As String, _
                                  ByVal kolom1 As String, _
                                  ByVal baris2 As String, _
                                  ByVal kolom2 As String, _
                                  ByVal warna As Color)
        '=> Mewarnai button sesuai warna error baris/kolom/region
        Dim tempControl As Control
        For Each tempControl In Form1.GetChildControls(TableLayoutPanel_Besar)
            Dim namaControl1 As String = "Cell" + baris1 + kolom1
            Dim namaControl2 As String = "Cell" + baris2 + kolom2
            If tempControl.Name = namaControl1 Or tempControl.Name = namaControl2 Then
                tempControl.ForeColor = warna
            End If

        Next
    End Sub

    Private Sub TulisLabelError(ByVal kalimat As String, ByVal warna As Color)
        '=> Menampilkan pesan error baris/kolom/region
        If LabelError1.Visible = False Then
            LabelError1.Visible = True
            LabelError1.ForeColor = warna
            LabelError1.Text = kalimat
        ElseIf LabelError2.Visible = False Then
            LabelError2.Visible = True
            LabelError2.ForeColor = warna
            LabelError2.Text = kalimat
        Else
            LabelError3.Visible = True
            LabelError3.ForeColor = warna
            LabelError3.Text = kalimat
        End If
    End Sub

    Private Function KeluarDialog(ByVal kalimat As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton) As Boolean
        Dim keluar As Boolean = False
        If MessageBox.Show(kalimat, "Sudoku", buttons, MessageBoxIcon.Question, defaultButton) = 1 Then
            keluar = True
        End If
        Return keluar
    End Function

    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Dim masihKosong As Boolean = True
        Dim barisBenar As Boolean = True
        Dim kolomBenar As Boolean = True
        Dim regionBenar As Boolean = True
        Dim i, j, c As Byte

        '=> Cek apakah papan masih kosong
        For i = 1 To 9
            For j = 1 To 9
                If papan(i, j) <> "0" Then
                    masihKosong = False
                End If
            Next
        Next

        cekValiditasAngka(barisBenar, kolomBenar, regionBenar)

        LabelError1.Visible = False
        LabelError2.Visible = False
        LabelError3.Visible = False
        InisialisasiWarnaIsiKotak(Color.Black)

        If masihKosong Then
            If KeluarDialog("Papan masih kosong. Anda yakin?", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1) Then
                '==> Mengcopy soal yang telah diinputkan ke papan di form utama
                For i = 1 To 9
                    For j = 1 To 9
                        Form1.board(i, j) = papan(i, j)
                        Form1.boardTemp(i, j) = papan(i, j)
                    Next
                Next
                Form1.IsiKotakPapan()
                Form1.SoalBaruToolStripMenuItem.Enabled = False
                Form1.TingkatKesulitanToolStripMenuItem.Enabled = False
                Form1.SimpanSoalToolStripMenuItem.Enabled = True
                Form1.soalManual = True
                Form1.papanKosong = False
                Form1.TableLayoutPanel_Besar.BackColor = Color.DarkSlateGray

                Me.Close()
            End If
        ElseIf Not barisBenar Or Not kolomBenar Or Not regionBenar Then
            MessageBox.Show("Pengisian papan masih belum sesuai dengan aturan Sudoku", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LabelErrorInfo.Visible = True
            If Not barisBenar Then
                TulisLabelError("- Baris", Color.Red)
                For c = 1 To barisErr
                    PewarnaanIsiKotak(bkSalahBaris(c, 1, 1), bkSalahBaris(c, 1, 2), _
                                      bkSalahBaris(c, 2, 1), bkSalahBaris(c, 2, 2), Color.Red)
                Next
            End If

            If Not kolomBenar Then
                TulisLabelError("- Kolom", Color.Blue)
                For c = 1 To kolomErr
                    PewarnaanIsiKotak(bkSalahKolom(c, 1, 1), bkSalahKolom(c, 1, 2), _
                                      bkSalahKolom(c, 2, 1), bkSalahKolom(c, 2, 2), Color.Blue)
                Next
            End If

            If Not regionBenar Then
                TulisLabelError("- Region", Color.Green)
                For c = 1 To regionErr
                    PewarnaanIsiKotak(bkSalahRegion(c, 1, 1), bkSalahRegion(c, 1, 2), _
                                      bkSalahRegion(c, 2, 1), bkSalahRegion(c, 2, 2), Color.Green)
                Next
            End If
        Else 'Jika sudah benar, maka user boleh keluar dari form
            LabelErrorInfo.Visible = False
            If KeluarDialog("Pengisian papan sudah benar. Anda yakin ingin keluar?", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1) Then
                '==> Mengcopy soal yang telah diinputkan ke papan di form utama
                For i = 1 To 9
                    For j = 1 To 9
                        Form1.board(i, j) = papan(i, j)
                        Form1.boardTemp(i, j) = papan(i, j)
                    Next
                Next
                Form1.IsiKotakPapan()
                Form1.SoalBaruToolStripMenuItem.Enabled = False
                Form1.TingkatKesulitanToolStripMenuItem.Enabled = False
                Form1.SimpanSoalToolStripMenuItem.Enabled = True
                Form1.soalManual = True
                Form1.papanKosong = False
                Form1.Label_Level.Visible = False
                Form1.TableLayoutPanel_Besar.BackColor = Color.DarkSlateGray

                Me.Close()
            End If
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inisialisasiPapan()
    End Sub

End Class