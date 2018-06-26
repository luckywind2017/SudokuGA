Module GenAlg

    Public Class parameterGA
        Private pop, jumEks, jumElit As Integer
        Private pMutasi, pCrossOver, maksGen As Double

        Sub New()
            pop = 100
            jumEks = 2
            pMutasi = 0.2
            pCrossOver = 0.9
            maksGen = 10000
            jumElit = 0
        End Sub
        Sub New(ByVal populasi As Integer, ByVal jumEksperimen As Integer, _
                ByVal pMut As Double, ByVal pCross As Double, _
                ByVal maksGenerasi As Double, ByVal jElit As Integer)
            populasi = pop
            jumEksperimen = jumEks
            pMutasi = pMut
            pCrossOver = pCross
            maksGenerasi = maksGen
            jumElit = jElit
        End Sub

        Property JumlahKromosom() As Integer
            Get
                Return pop
            End Get
            Set(ByVal jumlah As Integer)
                pop = jumlah
            End Set
        End Property
        ReadOnly Property JumlahEksperimen() As Integer
            Get
                Return jumEks
            End Get
        End Property
        Property PeluangMutasi() As Double
            Get
                Return pMutasi
            End Get
            Set(ByVal value As Double)
                pMutasi = value
            End Set
        End Property
        Property PeluangCrossOver() As Double
            Get
                Return pCrossOver
            End Get
            Set(ByVal value As Double)
                pCrossOver = value
            End Set
        End Property
        Property MaksimumGenerasi() As Double
            Get
                Return maksGen
            End Get
            Set(ByVal jumlah As Double)
                maksGen = jumlah
            End Set
        End Property
        Property JumlahElitism()
            Get
                Return jumElit
            End Get
            Set(ByVal value)
                jumElit = value
            End Set
        End Property
    End Class

    Structure gen
        Dim papan() As Integer
        Dim fitness As Integer
        Dim sel_distance As Double
        Sub New(ByVal value)
            ReDim papan(value)
            fitness = 0
            sel_distance = 0
        End Sub

    End Structure

    Structure popElit
        Dim fitness, indeksPop As Integer
    End Structure

    Private sukses, selesai As Boolean
    Private noGenerasi As Integer
    Private paramGA As parameterGA
    Private bukanAngkaSoal(80) As Boolean

    Private tempPapan(80) As Integer
    Private populasi() As gen
    Private popTerpilih(1001) As Boolean

    Private Memo As RichTextBox
    Private PBar As ProgressBar
    Private startWaktu, stopWaktu As Date
    Private terbaik As Integer = 999999999


    '-------------------------------- *** FUNGSI UTAMA GA **** --------------------------------
    Public Sub DemoGA(ByVal param As parameterGA, ByRef arrPapan() As Integer, _
                      ByRef RTextBox As RichTextBox, ByRef progBar As ProgressBar, _
                      ByRef berhasil As Boolean)
        paramGA = param
        Array.Copy(arrPapan, tempPapan, 81)
        GenerateArrayBukanAngkaSoal()
        Memo = RTextBox
        PBar = progBar

        Inisialisasi()
        GeneratePopulasiAwal()
        While Not selesai
            EvaluasiPopulasi()
            GenerateSelectionistDistribution()
            selesai = evolusiBerakhir()
            If Not selesai Then
                GeneratePopulasiBaru()
                noGenerasi += 1
            End If

            If selesai Then
                PBar.Value = PBar.Maximum
            Else
                If PBar.Value < PBar.Maximum Then
                    PBar.Value = 273 - terbaik
                End If
            End If

        End While

        CetakHasil()
        Array.Copy(tempPapan, arrPapan, 81)
        berhasil = sukses
    End Sub

    Private Sub Inisialisasi()
        Dim c As Integer

        sukses = False
        selesai = False
        noGenerasi = 1
        startWaktu = Date.Now

        ReDim populasi(paramGA.JumlahKromosom)

        For c = 0 To paramGA.JumlahKromosom - 1
            populasi(c) = New gen(80)
            Array.Copy(tempPapan, populasi(c).papan, 81)
        Next

        ProgressBarInit()
    End Sub

    Private Sub GeneratePopulasiAwal()
        Dim x, i, j, indeks As Integer
        Dim popTemp(101) As gen
        Dim bilangan(9) As Integer
        Dim area(9) As Integer

        Randomize()

        For x = 0 To paramGA.JumlahKromosom - 1
            For i = 1 To 9
                indeks = i * 9 - 9
                For j = indeks To indeks + 8
                    area((j Mod 9) + 1) = populasi(x).papan(j)
                Next
                IsiRegion(area, x, indeks)
            Next
        Next
    End Sub

    Private Sub EvaluasiPopulasi()
        Dim x, nilaiP As Integer
        Dim indeks As Integer

        terbaik = 9999


        '## Menghitung nilai fitness (nilai penalti) pada papan Sudoku ##
        For x = 0 To paramGA.JumlahKromosom - 1

            nilaiP = NilaiPenalti(populasi(x).papan)
            populasi(x).fitness = nilaiP

            '--> Mencari nilai fitness terbaik
            If nilaiP < terbaik Then
                terbaik = nilaiP
                indeks = x
            End If
        Next

        '## Mencetak nilai terbaik ke RichTextBox
        CetakMemo("Generasi: " + noGenerasi.ToString + "/" + paramGA.MaksimumGenerasi.ToString + _
                 ", Fitness = " + terbaik.ToString + " (" + indeks.ToString + "/" _
                + paramGA.JumlahKromosom.ToString + ")")
    End Sub

    Private Sub GenerateSelectionistDistribution()
        Dim sumDistance As Double
        Dim x As Integer
        Dim alpha As Double = 0.00001

        sumDistance = 0
        For x = 0 To paramGA.JumlahKromosom - 1
            populasi(x).sel_distance = 1 / (populasi(x).fitness + alpha)
            sumDistance = sumDistance + populasi(x).sel_distance
        Next

        For x = 0 To paramGA.JumlahKromosom - 1
            populasi(x).sel_distance = populasi(x).sel_distance / sumDistance
          Next
    End Sub

    Private Function evolusiBerakhir() As Boolean
        Dim berakhir As Boolean = False
        Dim x, indeks As Integer
        sukses = False
        '## Mencari gen dengan nilai fitness terbaik (terkecil) ##
        Dim terbaik As Integer = 81 * 3
        For x = 0 To paramGA.JumlahKromosom - 1
            If populasi(x).fitness < terbaik Then
                terbaik = populasi(x).fitness
                indeks = x
            End If
        Next

        If noGenerasi >= paramGA.MaksimumGenerasi Then
            berakhir = True
        End If
        If terbaik = 0 Then
            sukses = True
        End If
        If sukses Then
            berakhir = True
        End If

        If berakhir Then
            For x = 0 To 80
                Debug.Write(populasi(indeks).papan(x))
            Next
            Array.Copy(populasi(indeks).papan, tempPapan, 81)
        End If

        Return berakhir
    End Function

    Private Sub GeneratePopulasiBaru()
        Dim x, indeks As Integer
        Dim p1, p2 As Double
        Dim pr1(81), pr2(81) As Integer
        Dim popBaru() As gen

        ReDim popTerpilih(paramGA.JumlahKromosom)
        ReDim popBaru(paramGA.JumlahKromosom)

        Randomize()

        For x = 0 To paramGA.JumlahKromosom - 1
            popTerpilih(x) = False
        Next

        selesai = False

        Elitism()

        indeks = 0
        For x = 0 To paramGA.JumlahKromosom - 1
            If popTerpilih(x) Then
                popBaru(indeks) = New gen(80)
                Array.Copy(populasi(x).papan, popBaru(indeks).papan, 81)
                indeks = indeks + 1
            End If
        Next

        For x = indeks To paramGA.JumlahKromosom - 1
            p1 = cariParent(Rnd)
            p2 = cariParent(Rnd)
            Array.Copy(populasi(p1).papan, pr1, 81)
            Array.Copy(populasi(p2).papan, pr2, 81)

            popBaru(x) = New gen(80)
            popBaru(x + 1) = New gen(80)

            GenerateOffspring(pr1, pr2, popBaru(x).papan, popBaru(x + 1).papan)
            x = x + 1
        Next

        For x = 0 To paramGA.JumlahKromosom - 1
            Array.Copy(popBaru(x).papan, populasi(x).papan, 81)
        Next
    End Sub

    Private Sub Elitism()

        Dim pop() As popElit
        ReDim pop(paramGA.JumlahElitism)

        Dim x, c, indeks, tertinggi As Integer
        Dim ketemu As Boolean

        For c = 0 To paramGA.JumlahKromosom - 1
            popTerpilih(c) = False
        Next

        If paramGA.JumlahElitism > 0 Then

            tertinggi = 0
            For c = 0 To paramGA.JumlahKromosom - 1
                If c < paramGA.JumlahElitism Then
                    pop(c).fitness = populasi(c).fitness
                    pop(c).indeksPop = c
                    popTerpilih(c) = True

                    indeks = indeks + 1
                    If populasi(c).fitness > tertinggi Then
                        tertinggi = populasi(c).fitness
                    End If
                Else
                    If populasi(c).fitness < tertinggi Then

                        'Mencari nilai fitness yg telah dimasukkan dalam array
                        ketemu = False
                        x = 0
                        While x < paramGA.JumlahElitism And Not ketemu
                            If pop(x).fitness = tertinggi Then
                                pop(x).fitness = populasi(c).fitness
                                popTerpilih(pop(x).indeksPop) = False
                                popTerpilih(c) = True
                                pop(x).indeksPop = c

                                ketemu = True
                            End If
                            x = x + 1
                        End While

                        'Mencari nilai fitness tertinggi sebagai batas
                        tertinggi = 0
                        For x = 0 To paramGA.JumlahElitism - 1
                            If pop(x).fitness > tertinggi Then
                                tertinggi = pop(x).fitness
                            End If
                        Next
                    End If
                End If
            Next
        End If
    End Sub

    Private Function cariParent(ByVal prob As Double) As Integer
        '--> Memilih sebuah parent dengan seleksi roulette wheel
        Dim c, parent As Integer
        Dim soFar As Double
        Dim ditemukan As Boolean

        soFar = 0
        ditemukan = False
        c = 0
        While Not ditemukan
            If Not popTerpilih(c) Then
                soFar = soFar + populasi(c).sel_distance
            End If
            If prob <= soFar Or c = paramGA.JumlahKromosom - 1 Then
                ditemukan = True
                parent = c
            End If
            c = c + 1
        End While
        Return parent
    End Function

    Private Sub GenerateOffspring(ByVal par1() As Integer, ByVal par2() As Integer, _
                                       ByRef genBaru1() As Integer, _
                                       ByRef genBaru2() As Integer)

        Dim rr As Double
        Dim pos1, pos2 As Integer
        Dim sah As Boolean


        Randomize()

        '--> Memberikan peluang mutasi untuk parent pertama
        rr = Rnd()
        If rr < paramGA.PeluangMutasi Then
            GeneratePosisi(pos1, pos2)
            Mutasi(par1, pos1, pos2)
            sah = True
        End If

        '--> Memberikan peluang mutasi untuk parent kedua
        rr = Rnd()
        If rr < paramGA.PeluangMutasi Then
            GeneratePosisi(pos1, pos2)
            Mutasi(par2, pos1, pos2)
        End If

        '--> Memberikan peluang crossover untuk kedua parent
        rr = Rnd()
        If rr < paramGA.PeluangCrossOver Then
            Crossover(par1, par2, Math.Floor(Rnd() * 9), genBaru1, genBaru2)
        Else
            genBaru1 = par1
            genBaru2 = par2
        End If
    End Sub

    Private Sub Mutasi(ByRef gen() As Integer, ByVal posisi1 As Integer, _
                       ByVal posisi2 As Integer)
        Dim temp As Integer

        '--> Mutasi menggunakan metode swap antar allele
        temp = gen(posisi1)
        gen(posisi1) = gen(posisi2)
        gen(posisi2) = temp
    End Sub

    Private Sub Crossover(ByVal parent1() As Integer, ByVal parent2() As Integer, _
                        ByVal regionKe As Integer, _
                        ByRef child1() As Integer, ByRef child2() As Integer)
        Dim c, indeks, awal, akhir As Integer
        Dim alleleCross As Integer
        Dim temp(9) As Integer
        Dim selesai As Boolean
        Dim regParent1(9), regParent2(9), regChild1(9), regChild2(9) As Integer
        Dim rangkaian(9) As Integer
        Dim putaran As Integer = 0

        awal = regionKe * 9
        akhir = awal + 8

        indeks = 0
        For c = awal To akhir
            regParent1(indeks) = parent1(c)
            regParent2(indeks) = parent2(c)
            indeks = indeks + 1
        Next

        For c = 0 To 8
            regChild1(c) = 0
            regChild2(c) = 0
        Next

        '--> Crossover menggunakan metode cycle crossover (untuk child pertama)
        For c = 0 To 8
            If bukanAngkaSoal(awal + c) And regChild1(c) = 0 Then
                putaran = putaran + 1
                If putaran Mod 2 = 1 Then
                    regChild1(c) = regParent1(c)
                    indeks = c
                    alleleCross = regParent2(indeks)
                    selesai = False
                    While Not selesai
                        indeks = indeksAllele(regParent1, alleleCross)
                        If indeks = c Then
                            selesai = True
                        Else
                            regChild1(indeks) = regParent1(indeks)
                            alleleCross = regParent2(indeks)
                        End If
                    End While
                Else
                    regChild1(c) = regParent2(c)
                    indeks = c
                    alleleCross = regParent2(indeks)
                    selesai = False
                    While Not selesai
                        indeks = indeksAllele(regParent1, alleleCross)
                        If indeks = c Then
                            selesai = True
                        Else
                            regChild1(indeks) = regParent2(indeks)
                            alleleCross = regParent2(indeks)
                        End If
                    End While
                End If
            ElseIf regChild1(c) = 0 Then
                regChild1(c) = regParent1(c)
                regChild2(c) = regParent2(c)
            End If
        Next

        '# Mengisi child kedua dengan allele yang belum digunakan child pertama #
        For c = 0 To 8
            If regChild2(c) = 0 Then
                regChild2(c) = allelePilihan(regParent1, regParent2, c, regChild1(c))
            End If
        Next

        '# Menyusun offspring baru secara keseluruhan #
        For c = 0 To 80
            If c >= awal And c <= akhir Then
                child1(c) = regChild1(c Mod 9)
                child2(c) = regChild2(c Mod 9)
            Else
                child1(c) = parent1(c)
                child2(c) = parent2(c)
            End If
        Next
    End Sub


    '------------------------------- *** FUNGSI TAMBAHAN **** ---------------------------------
    Private Function indeksAllele(ByVal region() As Integer, ByVal allele As Integer) As Integer
        Dim c As Integer

        '# Mendapatkan sebuah indeks pada array yang berisi angka sesuai isi variabel allele
        For c = 0 To 8
            If region(c) = allele Then
                Return c
            End If
        Next

    End Function

    Private Function allelePilihan(ByVal region1() As Integer, ByVal region2() As Integer, _
                                   ByVal indeks As Integer, ByVal used As Integer) As Integer
        '# Mendapatkan allele yang belum digunakan oleh child pertama
        If region1(indeks) = used Then
            Return region2(indeks)
        Else
            Return region1(indeks)
        End If
    End Function

    Private Sub GeneratePosisi(ByRef pos1 As Integer, ByRef pos2 As Integer)
        Dim reg, r1, r2, jumlah As Integer
        Dim bilangan(9) As Integer
        Dim sah As Boolean = False

        reg = Math.Floor(Rnd() * 9)

        While KosongKurangDariDua(reg)
            reg = Math.Floor(Rnd() * 9)
        End While

        KumpulkanPosisiKosong(reg, bilangan, jumlah)
        While Not sah
            r1 = Math.Floor(Rnd() * jumlah)
            r2 = Math.Floor(Rnd() * jumlah)

            pos1 = bilangan(r1)
            pos2 = bilangan(r2)

            If pos1 <> pos2 Then
                sah = True
            End If
        End While

    End Sub

    Private Sub KumpulkanPosisiKosong(ByVal noRegion As Integer, ByRef bilangan() As Integer, _
                                     ByRef jumlah As Integer)
        Dim acc, c, awal, akhir As Integer

        awal = noRegion * 9
        akhir = awal + 8

        acc = 0
        For c = awal To akhir
            If bukanAngkaSoal(c) Then
                bilangan(acc) = c
                acc = acc + 1
            End If
        Next

        jumlah = acc

    End Sub

    Private Function KosongKurangDariDua(ByVal noRegion As Integer) As Boolean
        Dim acc, c, awal, akhir As Integer
        Dim hasil As Boolean

        awal = noRegion * 9
        akhir = awal + 8

        acc = 0
        For c = awal To akhir
            If bukanAngkaSoal(c) Then
                acc = acc + 1
            End If
        Next

        If acc < 2 Then
            hasil = True
        Else
            hasil = False
        End If
        Return hasil
    End Function


    Private Sub GenerateTitikSilang(ByRef pos1 As Integer, ByRef pos2 As Integer)
        pos1 = Math.Floor(Rnd() * 8) * 9 + 8
        pos2 = Math.Floor(Rnd() * 8) * 9 + 8
    End Sub

    Private Sub GenerateArrayBukanAngkaSoal()
        Dim c As Integer

        For c = 0 To 80
            If tempPapan(c) = 0 Then
                bukanAngkaSoal(c) = True
            Else
                bukanAngkaSoal(c) = False
            End If
        Next
    End Sub

    Private Function NilaiPenalti(ByVal gen() As Integer) As Integer
        Dim i, j, penalti As Integer
        Dim indeks As Integer
        Dim area(8) As Integer

        penalti = 0

        '## Menghitung nilai penalti pada semua region ##'
        indeks = 0
        For i = 1 To 9
            For j = 0 To 8
                area(j) = gen(indeks)
                indeks += 1
            Next
            penalti += PenaltiArea(area)
        Next

        '## Menghitung nilai penalti pada semua kolom ##'
        For i = 1 To 9
            j = 0
            indeks = IndeksAwalKolom(i)
            While j <= 8
                area(j) = gen(indeks)
                area(j + 1) = gen(indeks + 3)
                area(j + 2) = gen(indeks + 6)
                j += 3
                indeks += 27
            End While
            penalti += PenaltiArea(area)
        Next

        '## Menghitung nilai penalti pada semua baris ##'
        For i = 0 To 8
            j = 0
            indeks = IndeksAwalBaris(i)
            While j <= 8
                area(j) = gen(indeks)
                area(j + 1) = gen(indeks + 1)
                area(j + 2) = gen(indeks + 2)
                j += 3
                indeks += 9
            End While
            penalti += PenaltiArea(area)
        Next

        Return penalti
    End Function

    Private Function PenaltiArea(ByVal area() As Integer) As Integer
        '## Menghitung nilai penalti utk area region/baris/kolom utk setiap indeks ##
        Dim c, d, acc As Integer
        Dim sudahSama As Boolean
        Dim bilangan(9) As Integer

        acc = 0
        '## Mengecek angka pada suatu indeks apakah sama dengan indeks lain ##
        '## Jika sama, nilai penalti ditambahkan satu ##
        For c = 0 To 8
            d = 0
            sudahSama = False
            While d <= 8 And Not sudahSama
                If c <> d Then
                    If area(c) = area(d) Then
                        sudahSama = True
                        acc = acc + 1
                    End If
                End If
                d = d + 1
            End While
        Next
        Return acc
    End Function

    Private Sub IsiRegion(ByVal area() As Integer, ByVal pop As Integer, _
                      ByVal indeks As Integer)
        Dim bilangan(9) As Boolean
        Dim c, rand As Integer

        For c = 1 To 9
            bilangan(c) = False
        Next

        For c = 1 To 9
            If area(c) <> 0 Then
                bilangan(area(c)) = True
            End If
        Next

        For c = 1 To 9
            If bilangan(c) = False Then
                While bilangan(c) = False
                    rand = Math.Floor(Rnd() * 9) + 1
                    If area(rand) = 0 Then
                        area(rand) = c
                        bilangan(c) = True
                    End If
                End While
            End If
        Next

        For c = indeks To indeks + 8
            populasi(pop).papan(c) = area((c Mod 9) + 1)
        Next
    End Sub

    Private Function Factorial(ByVal angka As Integer) As Integer
        Dim c, sum As Integer
        sum = 1
        For c = 1 To angka
            sum = sum * c
        Next

        Return sum
    End Function

    Private Function IndeksAwalKolom(ByVal noKolom As Integer) As Integer

        Select Case noKolom
            Case 1 : Return 0
            Case 2 : Return 1
            Case 3 : Return 2
            Case 4 : Return 9
            Case 5 : Return 10
            Case 6 : Return 11
            Case 7 : Return 18
            Case 8 : Return 19
            Case 9 : Return 20
        End Select
    End Function

    Private Function IndeksAwalBaris(ByVal noBaris As Integer) As Integer

        Select Case noBaris
            Case 1 : Return 0
            Case 2 : Return 3
            Case 3 : Return 6
            Case 4 : Return 27
            Case 5 : Return 30
            Case 6 : Return 33
            Case 7 : Return 54
            Case 8 : Return 57
            Case 9 : Return 60
        End Select

    End Function

    ' ---------------------------------- *** LAIN-LAIN **** ----------------------------------

    Private Sub ProgressBarInit()
        PBar.Maximum = 273
        PBar.Minimum = 0
        PBar.Value = 0
        startWaktu = Date.Now
    End Sub

    Public Sub CetakInfo(ByVal kalimat As String)
        CetakMemo(kalimat)
        CetakLog(kalimat)
    End Sub

    Public Sub CetakLog(ByVal kalimat As String)
        Dim obj As New System.IO.StreamWriter("Sudoku.log", True)
        Dim tgl As Date = Now

        obj.WriteLine(kalimat)
        obj.Close()
    End Sub

    Public Sub CetakMemo(ByVal kalimat As String)
        Memo.AppendText(kalimat + Environment.NewLine)
    End Sub

    Private Sub CetakHasil()
        Dim str As String = ""
        Dim menit, detik As Integer
        stopWaktu = Date.Now

        menit = Math.Floor((stopWaktu - startWaktu).TotalMinutes)
        detik = ((stopWaktu - startWaktu).TotalMinutes - menit) * 60
        Dim s As String = CStr(menit) + " menit " + CStr(detik) + " detik"

        If sukses Then
            CetakInfo("********************* SUKSES **********************" + Environment.NewLine)
            CetakLog("Ditemukan pada generasi = " + noGenerasi.ToString)
            CetakInfo("Waktu yang dibutuhkan: " + s + Environment.NewLine)
        Else
            CetakInfo("!!!!!!!!!!!!!!!!!!!!!! GAGAL !!!!!!!!!!!!!!!!!!!!!!" + Environment.NewLine)
            CetakLog("Nilai Fitness Terbaik = " + terbaik.ToString)
        End If
    End Sub
End Module
