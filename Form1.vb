Public Class Form1
    Dim btnCell As Button
    Dim namafile As String
    Dim warna As Color

    Public board(9, 9) As Char
    Public boardTemp(9, 9) As Char
    Public jawaban(9, 9) As Char
    Dim angkaKembar(9, 9) As Boolean

    Dim klikBaris, klikKolom As Integer

    Private paramGA As GenAlg.parameterGA

    Public papanKosong, tersimpan, soalManual As Boolean
    Dim sukses As Boolean = False
    Dim sudahDicari As Boolean = False
    Dim fileSekarang As Integer = 0

    ' ---------------------------------- *** INTERFACE **** ----------------------------------
    Private Sub AngkaPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label4.Click, Label3.Click, Label2.Click, Label1.Click
        'Prosedur untuk menyimpan teks angka yang dipilih
        '--> Prosedur untuk semua label angka di panel kecil (panel untuk memilih angka)
        Panel1.Visible = False
        btnCell.Text = sender.text
        btnCell.ForeColor = Color.Blue

        '=> Mengisi angka pilihan user ke dalam array
        board(klikBaris, klikKolom) = sender.text
    End Sub
    Private Sub TombolP_Klik(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cell55.Click, Cell99.Click, Cell98.Click, Cell97.Click, Cell96.Click, Cell95.Click, Cell94.Click, Cell93.Click, Cell92.Click, Cell91.Click, Cell89.Click, Cell88.Click, Cell87.Click, Cell86.Click, Cell85.Click, Cell84.Click, Cell83.Click, Cell82.Click, Cell81.Click, Cell79.Click, Cell78.Click, Cell77.Click, Cell76.Click, Cell75.Click, Cell74.Click, Cell73.Click, Cell72.Click, Cell71.Click, Cell69.Click, Cell68.Click, Cell67.Click, Cell66.Click, Cell65.Click, Cell64.Click, Cell63.Click, Cell62.Click, Cell61.Click, Cell59.Click, Cell58.Click, Cell57.Click, Cell56.Click, Cell54.Click, Cell53.Click, Cell52.Click, Cell51.Click, Cell49.Click, Cell48.Click, Cell47.Click, Cell46.Click, Cell45.Click, Cell44.Click, Cell43.Click, Cell42.Click, Cell41.Click, Cell39.Click, Cell38.Click, Cell37.Click, Cell36.Click, Cell35.Click, Cell34.Click, Cell33.Click, Cell32.Click, Cell31.Click, Cell29.Click, Cell28.Click, Cell27.Click, Cell26.Click, Cell25.Click, Cell24.Click, Cell23.Click, Cell22.Click, Cell21.Click, Cell19.Click, Cell18.Click, Cell17.Click, Cell16.Click, Cell15.Click, Cell14.Click, Cell13.Click, Cell12.Click, Cell11.Click
        '--> Prosedur klik untuk semua kotak kosong di bidang permainan Sudoku

        '### Menentukan posisi X dan Y untuk Panel Memilih Angka ####
        'Panel1.Left = 159
        'Panel1.Top = 192

        Dim TombolAngka As Button = sender
        Dim baris As String = TombolAngka.Name.Substring(4, 1)
        Dim kolom As String = TombolAngka.Name.Substring(5, 1)

        klikBaris = baris
        klikKolom = kolom

        Dim P As New Point(Cursor.Position)
        Panel1.Location = PointToClient(Cursor.Position)
        btnCell = TombolAngka

        Panel1.Show()
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
    Private Function TingkatKesulitan() As String
        Dim tk As String = ""
        If MudahToolStripMenuItem.Checked = True Then
            tk = "mudah"
        ElseIf SangatMudahToolStripMenuItem.Checked = True Then
            tk = "sangat mudah"
        ElseIf SedangToolStripMenuItem.Checked = True Then
            tk = "sedang"
        ElseIf SulitToolStripMenuItem.Checked = True Then
            tk = "sulit"
        Else
            tk = "sangat sulit"
        End If
        Return tk
    End Function
    Private Function JumlahBaris() As UInt16
        Dim IoRead As IO.StreamReader
        Dim jum As UInt16 = 0
        IoRead = IO.File.OpenText(namafile)
        While IoRead.Peek <> -1
            IoRead.ReadLine()
            jum = jum + 1
        End While
        IoRead.Close()
        Return jum
    End Function
    Private Sub JumTkKesulitan(ByRef jSgtMudah As Byte, ByRef jMudah As Byte, _
                               ByRef jSedang As Byte, ByRef jSulit As Byte, _
                               ByRef JSgtSulit As Byte)
        Dim IoRead As IO.StreamReader
        Dim i As Byte
        Dim teks As String
        jSgtMudah = 0
        jMudah = 0
        jSedang = 0
        jSulit = 0
        JSgtSulit = 0

        IoRead = IO.File.OpenText(namafile)
        While IoRead.Peek <> -1
            teks = IoRead.ReadLine
            If teks = "mudah" Then
                jMudah += 1
            ElseIf teks = "sangat mudah" Then
                jSgtMudah += 1
            ElseIf teks = "sedang" Then
                jSedang += 1
            ElseIf teks = "sulit" Then
                jSulit += 1
            ElseIf teks = "sangat sulit" Then
                JSgtSulit += 1
            End If
            For i = 1 To 10
                IoRead.ReadLine()
            Next
        End While
        IoRead.Close()
    End Sub
    Public Sub IsiKotakPapan()
        'Mengisi kotak cell sesuai soal
        Dim i, j As Byte
        Dim tempControl As Control

        For i = 1 To 9
            For j = 1 To 9
                For Each tempControl In GetChildControls(TableLayoutPanel_Besar)
                    Dim namaControl As String = "Cell" + i.ToString + j.ToString
                    If tempControl.Name = namaControl Then
                        If board(i, j) <> "0" And boardTemp(i, j) <> "0" Then
                            tempControl.Text = board(i, j)
                            tempControl.Enabled = False
                            tempControl.ForeColor = Color.White
                            tempControl.BackColor = Color.LimeGreen
                        ElseIf board(i, j) <> "0" And boardTemp(i, j) = "0" Then
                            tempControl.Text = board(i, j)
                            tempControl.Enabled = True
                            tempControl.ForeColor = Color.Blue
                            tempControl.BackColor = Color.White
                        Else
                            tempControl.Text = ""
                            tempControl.Enabled = True
                            tempControl.ForeColor = Color.Blue
                            tempControl.BackColor = Color.White
                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub InisialisasiPapan()
        Dim x, y As Integer
        For x = 1 To 9
            For y = 1 To 9
                board(x, y) = "0"
            Next
        Next
    End Sub
    Private Sub DisableTkKesulitan(ByVal jSgtMudah As Byte, ByVal jMudah As Byte, _
                                   ByVal jSedang As Byte, ByVal jSulit As Byte, _
                                   ByVal JSgtSulit As Byte)

        SangatMudahToolStripMenuItem.Enabled = True
        MudahToolStripMenuItem.Enabled = True
        SedangToolStripMenuItem.Enabled = True
        SulitToolStripMenuItem.Enabled = True
        SangatSulitToolStripMenuItem.Enabled = True
        If jSgtMudah = 0 Then
            SangatMudahToolStripMenuItem.Enabled = False
        End If
        If jMudah = 0 Then
            MudahToolStripMenuItem.Enabled = False
        End If
        If jSedang = 0 Then
            SedangToolStripMenuItem.Enabled = False
        End If
        If jSulit = 0 Then
            SulitToolStripMenuItem.Enabled = False
        End If
        If JSgtSulit = 0 Then
            SangatSulitToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub BacaFile()
        Try
            Dim IoRead As IO.StreamReader
            Dim i, j, c As Byte
            Dim barisT As String
            Dim r, jumbaris As Integer
            Dim jSgtMudah, jMudah, jSedang, jSulit, jSgtSulit As Byte
            Dim terpilih As Boolean = False
            Dim formatsalah As Boolean = True

            jumbaris = JumlahBaris()
            JumTkKesulitan(jSgtMudah, jMudah, jSedang, jSulit, jSgtSulit)

            If jSgtMudah + jMudah + jSedang + jSulit + jSgtSulit = 0 Then
                MessageBox.Show("File gagal dibuka. Terdapat kesalahan pada format file teks", "Sudoku", MessageBoxButtons.OK)
                TableLayoutPanel_Besar.BackColor = Color.DarkSlateGray
            Else
                Randomize()

                r = fileSekarang

                'If fileSekarang = -1 Then
                '    r = 0 'digunakan untuk mencegah infinite looping
                'End If

                While r = fileSekarang 'Digunakan untuk memastikan bahwa soal yg akan dibuka bukan soal telah dibuka
                    If TingkatKesulitan() = "mudah" Then
                        r = Math.Floor(Rnd() * jMudah) + 1
                        If jMudah = 1 Then
                            fileSekarang = -1 'digunakan untuk mencegah infinite looping
                        ElseIf jMudah = 0 Then
                            r = 0 'menandai bahwa pada level tersebut soal tidak ada
                        End If
                    ElseIf TingkatKesulitan() = "sangat mudah" Then
                        r = Math.Floor(Rnd() * jSgtMudah) + 1
                        If jSgtMudah = 1 Then
                            fileSekarang = -1
                        ElseIf jSgtMudah = 0 Then
                            r = 0
                        End If
                    ElseIf TingkatKesulitan() = "sedang" Then
                        r = Math.Floor(Rnd() * jSedang) + 1
                        If jSedang = 1 Then
                            fileSekarang = -1
                        ElseIf jSedang = 0 Then
                            r = 0
                        End If
                    ElseIf TingkatKesulitan() = "sulit" Then
                        r = Math.Floor(Rnd() * jSulit) + 1
                        If jSulit = 1 Then
                            fileSekarang = -1
                        ElseIf jSulit = 0 Then
                            r = 0
                        End If
                    ElseIf TingkatKesulitan() = "sangat sulit" Then
                        r = Math.Floor(Rnd() * jSgtSulit) + 1
                        If jSgtSulit = 1 Then
                            fileSekarang = -1
                        ElseIf jSgtSulit = 0 Then
                            r = 0
                        End If
                    End If

                    If r = 0 Then 'Jika tidak ditemukan soal pada level tersebut, dapat diambil dari level lain
                        fileSekarang = -1
                        If jMudah > 0 Then
                            r = Math.Floor(Rnd() * jMudah) + 1
                            GantiTandaCek(False, True, False, False, False)
                        ElseIf jSgtMudah > 0 Then
                            r = Math.Floor(Rnd() * jSgtMudah) + 1
                            GantiTandaCek(True, False, False, False, False)
                        ElseIf jSedang > 0 Then
                            r = Math.Floor(Rnd() * jSedang) + 1
                            GantiTandaCek(False, False, True, False, False)
                        ElseIf jSulit > 0 Then
                            r = Math.Floor(Rnd() * jSulit) + 1
                            GantiTandaCek(False, False, False, True, False)
                        ElseIf jSgtSulit > 0 Then
                            r = Math.Floor(Rnd() * jSgtSulit) + 1
                            GantiTandaCek(False, False, False, False, True)
                        End If
                    End If
                End While

                c = 0

                fileSekarang = r

                'Membaca file teks
                IoRead = IO.File.OpenText(namafile)
                While IoRead.Peek <> -1 And terpilih = False
                    barisT = IoRead.ReadLine    'baca tingkat kesulitan
                    If barisT = TingkatKesulitan() Then
                        c += 1
                        If c = r Then
                            For i = 1 To 9
                                barisT = IoRead.ReadLine
                                For j = 1 To 9
                                    board(i, j) = barisT(j - 1)
                                Next
                            Next
                            terpilih = True 'Jika sudah terpilih, maka looping akan berhenti 

                        Else
                            For i = 1 To 9  'skip baca angka soal
                                IoRead.ReadLine()
                            Next
                        End If
                    Else
                        For i = 1 To 9  'skip baca angka soal
                            IoRead.ReadLine()
                        Next
                    End If
                    barisT = IoRead.ReadLine    'baca baris kosong
                End While
                IoRead.Close()

                '=> Mengcopy papan ke array temporary untuk menyimpan soal sebelum diisi
                For c = 1 To 9
                    For i = 1 To 9
                        boardTemp(c, i) = board(c, i)
                    Next
                Next

                IsiKotakPapan()

                TableLayoutPanel_Besar.Enabled = True
                TingkatKesulitanToolStripMenuItem.Enabled = True
                SoalBaruToolStripMenuItem.Enabled = True
                papanKosong = False
                Label_Level.Visible = True
                Label_Level.Text = TingkatKesulitan.ToString.ToUpper

                DisableTkKesulitan(jSgtMudah, jMudah, jSedang, jSulit, jSgtSulit)
                Panel1.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("File gagal dibuka!", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub BukaFileSoal()
        Dim resultDialog As DialogResult = _
            OpenFileDialog1.ShowDialog()
        If resultDialog = Windows.Forms.DialogResult.OK Then
            namafile = OpenFileDialog1.FileName
            InisialisasiPapan()
            sukses = False
            sudahDicari = False
            soalManual = False
            SimpanSoalToolStripMenuItem.Enabled = False

            fileSekarang = 0
            BacaFile()
        End If
    End Sub

    Private Sub GantiSoal()
        Panel1.Visible = False
        If namafile <> "" Then
            BacaFile() 'Membaca soal yang sesuai dengan tingkat kesulitan yang dipilih
        Else
            MessageBox.Show("Buka file soal terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        fileSekarang = 0
    End Sub

    Private Sub GantiTandaCek(ByVal ksmudah As Boolean, ByVal kmudah As Boolean, _
                          ByVal ksedang As Boolean, ByVal ksulit As Boolean, _
                          ByVal kxsulit As Boolean)
        SangatMudahToolStripMenuItem.Checked = ksmudah
        MudahToolStripMenuItem.Checked = kmudah
        SedangToolStripMenuItem.Checked = ksedang
        SulitToolStripMenuItem.Checked = ksulit
        SangatSulitToolStripMenuItem.Checked = kxsulit
        If ksmudah Then
            SangatMudahToolStripMenuItem.BackColor = Color.Silver
        Else
            SangatMudahToolStripMenuItem.BackColor = warna
        End If
        If kmudah Then
            MudahToolStripMenuItem.BackColor = Color.Silver
        Else
            MudahToolStripMenuItem.BackColor = warna
        End If
        If ksedang Then
            SedangToolStripMenuItem.BackColor = Color.Silver
        Else
            SedangToolStripMenuItem.BackColor = warna
        End If
        If ksulit Then
            SulitToolStripMenuItem.BackColor = Color.Silver
        Else
            SulitToolStripMenuItem.BackColor = warna
        End If
        If kxsulit Then
            SangatSulitToolStripMenuItem.BackColor = Color.Silver
        Else
            SangatSulitToolStripMenuItem.BackColor = warna
        End If
        sudahDicari = False
    End Sub
    Private Sub GantiWarnaPapan()
        If TingkatKesulitan() = "sangat mudah" Then
            TableLayoutPanel_Besar.BackColor = Color.Green
        ElseIf TingkatKesulitan() = "mudah" Then
            TableLayoutPanel_Besar.BackColor = Color.YellowGreen
        ElseIf TingkatKesulitan() = "sedang" Then
            TableLayoutPanel_Besar.BackColor = Color.Cyan
        ElseIf TingkatKesulitan() = "sulit" Then
            TableLayoutPanel_Besar.BackColor = Color.Orange
        ElseIf TingkatKesulitan() = "sangat sulit" Then
            TableLayoutPanel_Besar.BackColor = Color.Crimson
        End If
    End Sub
    Private Sub AktifkanTombol(ByVal kondisi As Boolean)
        MenuStrip1.Enabled = kondisi
        Button_Ulang_Permainan.Enabled = kondisi
        Button_CekJawaban.Enabled = kondisi
        Button_Pengaturan_GA.Enabled = kondisi
        Button_TampilkanSolusi.Enabled = kondisi
        Button_CariSolusi.Enabled = kondisi
    End Sub
    Public Sub AktifkanButton()
        Button_CariSolusi.Enabled = True
        Button_CekJawaban.Enabled = True
        Button_TampilkanSolusi.Enabled = True
        Button_Ulang_Permainan.Enabled = True
    End Sub

    Private Sub TampilkanError()
        Dim i, j As Byte
        Dim tempControl As Control

        For i = 1 To 9
            For j = 1 To 9
                For Each tempControl In GetChildControls(TableLayoutPanel_Besar)
                    Dim namaControl As String = "Cell" + i.ToString + j.ToString
                    If tempControl.Name = namaControl Then
                        If angkaKembar(i, j) Then
                            tempControl.ForeColor = Color.Red
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    ' ---------------------------------- *** PROCESS **** ----------------------------------
    Private Sub InisialisasiParameterGa()
        paramGA = New parameterGA
    End Sub
    Private Sub cekValiditasAngka(ByRef barisBenar As Boolean, _
                                  ByRef kolomBenar As Boolean, _
                                  ByRef regionBenar As Boolean)

        Dim i, j, x, y, r, c, cc As Byte
        barisBenar = True
        kolomBenar = True
        regionBenar = True

        For i = 1 To 9
            For j = 1 To 9
                angkaKembar(i, j) = False
            Next
        Next


        '=> Cek apakah semua baris sesuai dengan aturan Sudoku
        c = 0
        For i = 1 To 9
            For x = 1 To 8
                For y = x + 1 To 9
                    If board(i, x) <> "0" Then
                        If board(i, x) = board(i, y) Then
                            barisBenar = False
                            angkaKembar(i, x) = True
                            angkaKembar(i, y) = True
                            '=> Menyimpan angka yang sebaris pada array
                            c += 1
                            'bkSalahBaris(c, 1, 1) = i.ToString
                            'bkSalahBaris(c, 1, 2) = x.ToString
                            'bkSalahBaris(c, 2, 1) = i.ToString
                            'bkSalahBaris(c, 2, 2) = y.ToString
                        End If
                    End If
                Next
            Next
        Next
        ' barisErr = c

        '=> Cek apakah semua kolom sesuai dengan aturan Sudoku
        c = 0
        For j = 1 To 9
            For x = 1 To 8
                For y = x + 1 To 9
                    If board(x, j) <> "0" Then
                        If board(x, j) = board(y, j) Then
                            kolomBenar = False
                            angkaKembar(x, j) = True
                            angkaKembar(y, j) = True
                            c += 1
                            '=> Menyimpan angka yang sekolom pada array
                            'bkSalahKolom(c, 1, 1) = x.ToString
                            'bkSalahKolom(c, 1, 2) = j.ToString
                            'bkSalahKolom(c, 2, 1) = y.ToString
                            'bkSalahKolom(c, 2, 2) = j.ToString
                        End If
                    End If
                Next
            Next
        Next
        ' kolomErr = c

        '=> Cek apakah semua region sesuai dengan aturan Sudoku
        c = 0
        For r = 1 To 9
            Dim arrReg(9, 3) As Byte '=> Menyimpan satu region ke dalam array
            Array.Clear(arrReg, 0, 10)
            cc = 0
            For x = ((r - 1) \ 3) * 3 + 1 To ((r - 1) \ 3) * 3 + 3
                For y = 3 * ((r - 1) Mod 3) + 1 To 3 * ((r - 1) Mod 3) + 3
                    cc += 1
                    arrReg(cc, 1) = board(x, y).ToString
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
                            angkaKembar(arrReg(i, 2), arrReg(i, 3)) = True
                            angkaKembar(arrReg(j, 2), arrReg(j, 3)) = True

                            '=> Menyimpan angka yang sekolom pada array
                            c += 1
                            'bkSalahRegion(c, 1, 1) = arrReg(i, 2).ToString
                            'bkSalahRegion(c, 1, 2) = arrReg(i, 3).ToString
                            'bkSalahRegion(c, 2, 1) = arrReg(j, 2).ToString
                            'bkSalahRegion(c, 2, 2) = arrReg(j, 3).ToString
                        End If
                    End If
                Next
            Next
        Next
        'regionErr = c
    End Sub
    Private Sub KonversiPapanKeArray(ByRef A() As Integer)
        Dim r, x, y, indeks As Integer

        indeks = 0
        For r = 1 To 9
            For x = ((r - 1) \ 3) * 3 + 1 To ((r - 1) \ 3) * 3 + 3
                For y = 3 * ((r - 1) Mod 3) + 1 To 3 * ((r - 1) Mod 3) + 3
                    A(indeks) = Val(boardTemp(x, y))
                    indeks += 1
                Next
            Next
        Next
    End Sub
    Private Sub KonversiArrayKeBoard(ByVal A() As Integer)
        Dim r, x, y, indeks As Integer

        indeks = 0
        For r = 1 To 9
            For x = ((r - 1) \ 3) * 3 + 1 To ((r - 1) \ 3) * 3 + 3
                For y = 3 * ((r - 1) Mod 3) + 1 To 3 * ((r - 1) Mod 3) + 3
                    jawaban(x, y) = A(indeks).ToString
                    indeks += 1
                Next
            Next
        Next
    End Sub
    Private Sub LakukanProsesAlgoritmaGenetika()
        Dim papan(81) As Integer
        Dim x, y As Integer
        Dim kalimat As String

        sukses = False
        sudahDicari = True

        AktifkanTombol(False)

        GenAlg.CetakLog("############################################################")
        GenAlg.CetakLog("================")
        GenAlg.CetakLog("S  O  A  L   ")
        If soalManual Then
            GenAlg.CetakLog("M A N U A L")
        Else
            GenAlg.CetakLog(TingkatKesulitan)
        End If
        GenAlg.CetakLog("================")
        For x = 1 To 9
            kalimat = ""
            For y = 1 To 9
                kalimat = kalimat + boardTemp(x, y)
                If y = 3 Or y = 6 Then
                    kalimat = kalimat + " | "
                End If
            Next
            GenAlg.CetakLog(kalimat)
            If x = 3 Or x = 6 Then
                GenAlg.CetakLog("-----------------------")
            End If
        Next
        GenAlg.CetakLog("")


        Dim thl As Date = Now
        GenAlg.CetakLog("-----------------------------------------------------------")
        GenAlg.CetakLog(Now.ToString("dd-MM-yyyy HH:mm:ss") + ", Melakukan Proses Genetika Algoritma")
        GenAlg.CetakLog("-----------------------------------------------------------")
        GenAlg.CetakLog("Jumlah Populasi = " + paramGA.JumlahKromosom.ToString)
        GenAlg.CetakLog("Maks Genenerasi = " + paramGA.MaksimumGenerasi.ToString)
        GenAlg.CetakLog("% Mutasi = " + (paramGA.PeluangMutasi * 100).ToString + " %")
        GenAlg.CetakLog("% Crossover = " + (paramGA.PeluangCrossOver * 100).ToString + " %")
        KonversiPapanKeArray(papan)
        '--> Lakukan proses algoritma genetika
        GenAlg.DemoGA(paramGA, papan, txtKeterangan, ProgressBar1, sukses)
        MessageBox.Show("Selesai!", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information)
        KonversiArrayKeBoard(papan)

        If Not sukses Then
            CetakInformasi(" Hasil terbaik")
        Else
            CetakInformasi("    Jawaban")
        End If

        AktifkanTombol(True)

    End Sub
    Private Sub CetakInformasi(ByVal kalimat As String)
        Dim x, y As Integer

        GenAlg.CetakInfo("================")
        GenAlg.CetakInfo(kalimat)
        GenAlg.CetakInfo("================")
        For x = 1 To 9
            kalimat = ""
            For y = 1 To 9
                kalimat = kalimat + jawaban(x, y)
                If y = 3 Or y = 6 Then
                    kalimat = kalimat + " | "
                End If
            Next
            GenAlg.CetakInfo(kalimat)
            If x = 3 Or x = 6 Then
                GenAlg.CetakInfo("-----------------------")
            End If
        Next
        GenAlg.CetakInfo("")

    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        LakukanProsesAlgoritmaGenetika()
    End Sub
    ' ---------------------------------- *** CONTROLS **** ----------------------------------

    Private Sub AlgoritmaGenetikaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlgoritmaGenetikaToolStripMenuItem.Click
        Pengaturan.Show()
    End Sub
    Private Sub Button_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_batal.Click
        Panel1.Visible = False
    End Sub
    Private Sub Button_Hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_hapus.Click
        Panel1.Visible = False
        btnCell.Text = ""
    End Sub
    Private Sub BukaFileSoalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BukaFileSoalToolStripMenuItem.Click
        If soalManual And Not tersimpan Then
            If KeluarDialog("Soal belum tersimpan. Anda yakin?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) Then
                BukaFileSoal()
            End If
        Else
            BukaFileSoal()
        End If
    End Sub
    Private Sub SangatMudahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SangatMudahToolStripMenuItem.Click
        If SangatMudahToolStripMenuItem.Checked = False Then
            GantiTandaCek(True, False, False, False, False)
            GantiSoal()
        End If
    End Sub
    Private Sub MudahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MudahToolStripMenuItem.Click
        If MudahToolStripMenuItem.Checked = False Then
            GantiTandaCek(False, True, False, False, False)
            GantiSoal()
        End If
    End Sub
    Private Sub SedangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SedangToolStripMenuItem.Click
        If SedangToolStripMenuItem.Checked = False Then
            GantiTandaCek(False, False, True, False, False)
            GantiSoal()
        End If
    End Sub
    Private Sub SulitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SulitToolStripMenuItem.Click
        If SulitToolStripMenuItem.Checked = False Then
            GantiTandaCek(False, False, False, True, False)
            GantiSoal()
        End If
    End Sub
    Private Sub SangatSulitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SangatSulitToolStripMenuItem.Click
        If SangatSulitToolStripMenuItem.Checked = False Then
            GantiTandaCek(False, False, False, False, True)
            GantiSoal()
        End If
    End Sub
    Private Sub PengisianManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengisianManualToolStripMenuItem.Click
        Form_BuatSoal.ShowDialog()
        If papanKosong = False Then
            TableLayoutPanel_Besar.Enabled = True
            sudahDicari = False
        End If
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub SoalBaruToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoalBaruToolStripMenuItem.Click
        If namafile <> "" Then
            If KeluarDialog("Yakin ingin mengganti permainan lain?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) Then
                InisialisasiPapan()
                sukses = False
                sudahDicari = False
                BacaFile()
            End If
        Else
            MessageBox.Show("Buka file soal terlebih dahulu", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MudahToolStripMenuItem.Checked = True
        TableLayoutPanel_Besar.Enabled = False
        TableLayoutPanel_Besar.BackColor = Color.DarkSlateGray
        warna = SangatMudahToolStripMenuItem.BackColor
        GantiTandaCek(False, True, False, False, False)
        papanKosong = True
        tersimpan = False
        TingkatKesulitanToolStripMenuItem.Enabled = False
        SoalBaruToolStripMenuItem.Enabled = False
        SimpanSoalToolStripMenuItem.Enabled = False
        InisialisasiParameterGa()
    End Sub
    Private Sub Button_CekJawaban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CekJawaban.Click
        If Not papanKosong Then
            Dim barisBenar, kolomBenar, regionBenar, masihkosong As Boolean
            Dim i, j As Byte

            For i = 1 To 9
                For j = 1 To 9
                    If board(i, j) = "0" Then masihkosong = True
                Next
            Next

            If masihkosong Then
                MessageBox.Show("Masih ada kotak yang belum terisi!", "Sudoku")
            Else
                cekValiditasAngka(barisBenar, kolomBenar, regionBenar)
                If barisBenar And kolomBenar And regionBenar Then
                    MessageBox.Show("Jawaban sudah BENAR!", "Sudoku")
                Else
                    If KeluarDialog("Jawaban masih SALAH. Tunjukkan angka-angka kembar pada papan?", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1) Then
                        TampilkanError()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Buka file soal atau lakukan pengisian manual terlebih dahulu", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub Button_Ulang_Permainan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Ulang_Permainan.Click
        If Not papanKosong Then
            Dim keluar As Boolean
            Dim i, j As Byte

            If KeluarDialog("Hapus semua isian di papan permainan?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) Then
                For i = 1 To 9
                    For j = 1 To 9
                        board(i, j) = boardTemp(i, j)
                    Next
                Next
                IsiKotakPapan()
            End If
            If keluar Then
            End If
        Else
            MessageBox.Show("Buka file soal atau lakukan pengisian manual terlebih dahulu", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button_TampilkanSolusi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_TampilkanSolusi.Click
        If Not papanKosong Then
            If sudahDicari Then
                Dim i, j As Byte
                For i = 1 To 9
                    For j = 1 To 9
                        board(i, j) = jawaban(i, j)
                    Next
                Next
                If sukses Then
                    IsiKotakPapan()
                Else
                    If KeluarDialog("Solusi tidak ditemukan. Tampilkan hasil terbaik ke papan?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) Then
                        IsiKotakPapan()
                    End If
                End If
            Else
                MessageBox.Show("Solusi belum ditemukan. Silakan cari terlebih dahulu.", "Sudoku")
            End If
        Else
            MessageBox.Show("Buka file soal atau lakukan pengisian manual terlebih dahulu", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button_Pengaturan_GA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pengaturan_GA.Click
        Pengaturan.parameter.maksGen = paramGA.MaksimumGenerasi
        Pengaturan.parameter.pop = paramGA.JumlahKromosom
        Pengaturan.parameter.jumElit = paramGA.JumlahElitism
        Pengaturan.parameter.pMutasi = paramGA.PeluangMutasi
        Pengaturan.parameter.pCrossOver = paramGA.PeluangCrossOver

        Pengaturan.ShowDialog()

        paramGA.MaksimumGenerasi = Pengaturan.parameter.maksGen
        paramGA.JumlahKromosom = Pengaturan.parameter.pop
        paramGA.JumlahElitism = Pengaturan.parameter.jumElit
        paramGA.PeluangMutasi = Pengaturan.parameter.pMutasi
        paramGA.PeluangCrossOver = Pengaturan.parameter.pCrossOver
    End Sub
    Private Sub Button_CariSolusi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CariSolusi.Click
        If Not papanKosong Then
            BackgroundWorker1.RunWorkerAsync()
        Else
            MessageBox.Show("Buka file soal atau lakukan pengisian manual terlebih dahulu", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    ' ---------------------------------- *** LAIN-LAIN **** ----------------------------------

    Private Function KeluarDialog(ByVal kalimat As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton) As Boolean
        Dim keluar As Boolean = False
        If buttons = MessageBoxButtons.OKCancel Then
            If MessageBox.Show(kalimat, "Sudoku", buttons, MessageBoxIcon.Question, defaultButton) = Windows.Forms.DialogResult.OK Then
                keluar = True
            End If
        ElseIf buttons = MessageBoxButtons.YesNo Then
            If MessageBox.Show(kalimat, "Sudoku", buttons, MessageBoxIcon.Question, defaultButton) = Windows.Forms.DialogResult.Yes Then
                keluar = True
            End If
        End If
        Return keluar
    End Function

    Private Sub SimpanSoalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpanSoalToolStripMenuItem.Click
        SimpanSoal.ShowDialog()
    End Sub

End Class