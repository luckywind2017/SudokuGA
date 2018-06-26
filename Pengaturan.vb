Public Class Pengaturan

    Private paramGA As GenAlg.parameterGA

    Structure paramPengaturan
        Public pop, jumEks, jumElit As Integer
        Public pMutasi, pCrossOver, maksGen As Double
    End Structure

    Public parameter As paramPengaturan

    Private Sub Pengaturan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        paramGA = New parameterGA

        TextBox_JumKromosom.Text = parameter.pop
        TextBox_MaksGenerasi.Text = parameter.maksGen
        TextBox_Mutasi.Text = parameter.pMutasi * 100
        TextBox_Persilangan.Text = parameter.pCrossOver * 100
    End Sub

    Private Sub Button_Simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Simpan.Click
        Me.Hide()
        parameter.pop = TextBox_JumKromosom.Text
        parameter.maksGen = TextBox_MaksGenerasi.Text
        parameter.pMutasi = TextBox_Mutasi.Text / 100
        parameter.pCrossOver = TextBox_Persilangan.Text / 100
    End Sub

    Private Sub Button_Default_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Default.Click
        paramGA = New parameterGA

        TextBox_JumKromosom.Text = paramGA.JumlahKromosom
        TextBox_MaksGenerasi.Text = paramGA.MaksimumGenerasi
        TextBox_Mutasi.Text = paramGA.PeluangMutasi * 100
        TextBox_Persilangan.Text = paramGA.PeluangCrossOver * 100
    End Sub

    Private Sub Button_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Batal.Click
        Me.Hide()
    End Sub

    Private Sub TextBox_JumKromosom_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_JumKromosom.KeyUp
        TextBox_JumKromosom.Text = TextBox_JumKromosom.Text.Replace(" ", "")
        If TextBox_JumKromosom.Text <> "" Then
            If CInt(TextBox_JumKromosom.Text) > 1000 Then
                TextBox_JumKromosom.Text = "1000"
            ElseIf (TextBox_JumKromosom.Text) < 1 Then
                TextBox_JumKromosom.Text = "1"
            End If
        End If
    End Sub

    Private Sub TextBox_MaksGenerasi_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_MaksGenerasi.KeyUp
        TextBox_MaksGenerasi.Text = TextBox_MaksGenerasi.Text.Replace(" ", "")

        If TextBox_MaksGenerasi.Text <> "" Then
            If CInt(TextBox_MaksGenerasi.Text) > 100000 Then
                TextBox_MaksGenerasi.Text = "100000"
            ElseIf CInt(TextBox_MaksGenerasi.Text) < 1 Then
                TextBox_MaksGenerasi.Text = "1"
            End If
        End If
    End Sub

    Private Sub TextBox_Mutasi_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Mutasi.KeyUp
        TextBox_Mutasi.Text = TextBox_Mutasi.Text.Replace(" ", "")
        If TextBox_Mutasi.Text <> "" Then
            If CInt(TextBox_Mutasi.Text) > 100 Then
                TextBox_Mutasi.Text = "100"
            End If
        End If
    End Sub

    Private Sub TextBox_Persilangan_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Persilangan.KeyUp
        TextBox_Persilangan.Text = TextBox_Persilangan.Text.Replace(" ", "")
        If TextBox_Persilangan.Text <> "" Then
            If CInt(TextBox_Persilangan.Text) > 100 Then
                TextBox_Persilangan.Text = "100"
            End If
        End If
    End Sub

    Private Sub TextBox_JumKromosom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_JumKromosom.Leave
        If TextBox_JumKromosom.Text = "" Then
            TextBox_JumKromosom.Text = "1"
        End If
    End Sub

    Private Sub TextBox_MaksGenerasi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_MaksGenerasi.Leave
        If TextBox_MaksGenerasi.Text = "" Then
            TextBox_MaksGenerasi.Text = "1"
        End If
    End Sub

    Private Sub TextBox_Mutasi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Mutasi.Leave
        If TextBox_Mutasi.Text = "" Then
            TextBox_Mutasi.Text = "0"
        End If
    End Sub

    Private Sub TextBox_Persilangan_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Persilangan.Leave
        If TextBox_Persilangan.Text = "" Then
            TextBox_Persilangan.Text = "0"
        End If
    End Sub
End Class