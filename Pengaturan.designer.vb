<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pengaturan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pengaturan))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox_Persilangan = New System.Windows.Forms.MaskedTextBox
        Me.TextBox_Mutasi = New System.Windows.Forms.MaskedTextBox
        Me.TextBox_MaksGenerasi = New System.Windows.Forms.MaskedTextBox
        Me.TextBox_JumKromosom = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button_Simpan = New System.Windows.Forms.Button
        Me.Button_Batal = New System.Windows.Forms.Button
        Me.Button_Default = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_Persilangan)
        Me.GroupBox1.Controls.Add(Me.TextBox_Mutasi)
        Me.GroupBox1.Controls.Add(Me.TextBox_MaksGenerasi)
        Me.GroupBox1.Controls.Add(Me.TextBox_JumKromosom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Algoritma Genetika"
        '
        'TextBox_Persilangan
        '
        Me.TextBox_Persilangan.Location = New System.Drawing.Point(170, 150)
        Me.TextBox_Persilangan.Mask = "000"
        Me.TextBox_Persilangan.Name = "TextBox_Persilangan"
        Me.TextBox_Persilangan.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TextBox_Persilangan.Size = New System.Drawing.Size(59, 22)
        Me.TextBox_Persilangan.TabIndex = 4
        Me.TextBox_Persilangan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox_Mutasi
        '
        Me.TextBox_Mutasi.Location = New System.Drawing.Point(170, 122)
        Me.TextBox_Mutasi.Mask = "000"
        Me.TextBox_Mutasi.Name = "TextBox_Mutasi"
        Me.TextBox_Mutasi.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TextBox_Mutasi.Size = New System.Drawing.Size(59, 22)
        Me.TextBox_Mutasi.TabIndex = 3
        Me.TextBox_Mutasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox_MaksGenerasi
        '
        Me.TextBox_MaksGenerasi.Location = New System.Drawing.Point(184, 59)
        Me.TextBox_MaksGenerasi.Mask = "000000"
        Me.TextBox_MaksGenerasi.Name = "TextBox_MaksGenerasi"
        Me.TextBox_MaksGenerasi.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TextBox_MaksGenerasi.Size = New System.Drawing.Size(59, 22)
        Me.TextBox_MaksGenerasi.TabIndex = 2
        Me.TextBox_MaksGenerasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox_JumKromosom
        '
        Me.TextBox_JumKromosom.Location = New System.Drawing.Point(184, 31)
        Me.TextBox_JumKromosom.Mask = "0000"
        Me.TextBox_JumKromosom.Name = "TextBox_JumKromosom"
        Me.TextBox_JumKromosom.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TextBox_JumKromosom.Size = New System.Drawing.Size(59, 22)
        Me.TextBox_JumKromosom.TabIndex = 1
        Me.TextBox_JumKromosom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(235, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(235, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Peluang Persilangan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Peluang Mutasi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(6, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Operator Genetika"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Maksimum Generasi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jumlah Kromosom"
        '
        'Button_Simpan
        '
        Me.Button_Simpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button_Simpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button_Simpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Simpan.ImageKey = "Check-icon.png"
        Me.Button_Simpan.ImageList = Me.ImageList1
        Me.Button_Simpan.Location = New System.Drawing.Point(111, 213)
        Me.Button_Simpan.Name = "Button_Simpan"
        Me.Button_Simpan.Size = New System.Drawing.Size(94, 34)
        Me.Button_Simpan.TabIndex = 6
        Me.Button_Simpan.Text = "Simpan"
        Me.Button_Simpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button_Simpan.UseVisualStyleBackColor = False
        '
        'Button_Batal
        '
        Me.Button_Batal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button_Batal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Batal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button_Batal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Batal.ImageKey = "Actions-dialog-cancel.ico"
        Me.Button_Batal.ImageList = Me.ImageList1
        Me.Button_Batal.Location = New System.Drawing.Point(211, 212)
        Me.Button_Batal.Name = "Button_Batal"
        Me.Button_Batal.Size = New System.Drawing.Size(82, 34)
        Me.Button_Batal.TabIndex = 7
        Me.Button_Batal.Text = "Batal"
        Me.Button_Batal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button_Batal.UseVisualStyleBackColor = False
        '
        'Button_Default
        '
        Me.Button_Default.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button_Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Default.ImageKey = "default-document.ico"
        Me.Button_Default.ImageList = Me.ImageList1
        Me.Button_Default.Location = New System.Drawing.Point(12, 212)
        Me.Button_Default.Name = "Button_Default"
        Me.Button_Default.Size = New System.Drawing.Size(93, 34)
        Me.Button_Default.TabIndex = 5
        Me.Button_Default.Text = "Default"
        Me.Button_Default.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button_Default.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Actions-dialog-cancel.ico")
        Me.ImageList1.Images.SetKeyName(1, "Check-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "default-document.ico")
        '
        'Pengaturan
        '
        Me.AcceptButton = Me.Button_Simpan
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CancelButton = Me.Button_Batal
        Me.ClientSize = New System.Drawing.Size(303, 259)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Default)
        Me.Controls.Add(Me.Button_Simpan)
        Me.Controls.Add(Me.Button_Batal)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pengaturan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pengaturan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_Simpan As System.Windows.Forms.Button
    Friend WithEvents Button_Batal As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button_Default As System.Windows.Forms.Button
    Friend WithEvents TextBox_JumKromosom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox_Persilangan As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox_Mutasi As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox_MaksGenerasi As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
