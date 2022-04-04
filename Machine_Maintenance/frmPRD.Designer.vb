<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPRD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPRD))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tb_date = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.group_sign = New System.Windows.Forms.GroupBox()
        Me.rb_general = New System.Windows.Forms.RadioButton()
        Me.rb_important = New System.Windows.Forms.RadioButton()
        Me.rb_urgent = New System.Windows.Forms.RadioButton()
        Me.group_type = New System.Windows.Forms.GroupBox()
        Me.clbType = New System.Windows.Forms.CheckedListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_insert = New System.Windows.Forms.Button()
        Me.tb_found = New System.Windows.Forms.TextBox()
        Me.tb_tag = New System.Windows.Forms.TextBox()
        Me.tb_code = New System.Windows.Forms.TextBox()
        Me.tb_detail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_red = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_sign.SuspendLayout()
        Me.group_type.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(-2, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(762, 677)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.tb_date)
        Me.TabPage1.Controls.Add(Me.btn_login)
        Me.TabPage1.Controls.Add(Me.btnStatus)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.group_sign)
        Me.TabPage1.Controls.Add(Me.group_type)
        Me.TabPage1.Controls.Add(Me.btn_insert)
        Me.TabPage1.Controls.Add(Me.tb_found)
        Me.TabPage1.Controls.Add(Me.tb_tag)
        Me.TabPage1.Controls.Add(Me.tb_code)
        Me.TabPage1.Controls.Add(Me.tb_detail)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lb_red)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(754, 651)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "For Production"
        '
        'tb_date
        '
        Me.tb_date.AutoCompleteCustomSource.AddRange(New String() {"6001", "6002", "6010", "6012", "6013", "6020", "6021", "6022", "6030", "6040", "6050", "6060", "6070", "2000", "2060", "2070", "2071", "2072", "2080", "2081", "2082", "2083", "2084", "2010", "2020", "2030", "2040", "2041", "2050", "1090", "1080", "1070", "1000", "1010", "1020", "1030", "1040", "1050", "1060", "3010", "3015", "3020", "3025", "3030", "3000", "3090", "3050", "3055", "4010", "4015", "4020", "4050", "4000", "5000", "5005", "5010", "5011", "5012", "5050", "5060", "5070", "0050", "0001", "0002", "0020"})
        Me.tb_date.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tb_date.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tb_date.Location = New System.Drawing.Point(203, 134)
        Me.tb_date.MaxLength = 4
        Me.tb_date.Name = "tb_date"
        Me.tb_date.ReadOnly = True
        Me.tb_date.Size = New System.Drawing.Size(163, 20)
        Me.tb_date.TabIndex = 54
        '
        'btn_login
        '
        Me.btn_login.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_login.Location = New System.Drawing.Point(558, 588)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(149, 32)
        Me.btn_login.TabIndex = 51
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.White
        Me.btnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.Black
        Me.btnStatus.Location = New System.Drawing.Point(620, 18)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(87, 41)
        Me.btnStatus.TabIndex = 50
        Me.btnStatus.Text = "Server Status"
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Red
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 536)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(141, 89)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'group_sign
        '
        Me.group_sign.BackColor = System.Drawing.Color.White
        Me.group_sign.Controls.Add(Me.rb_general)
        Me.group_sign.Controls.Add(Me.rb_important)
        Me.group_sign.Controls.Add(Me.rb_urgent)
        Me.group_sign.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.group_sign.Location = New System.Drawing.Point(27, 176)
        Me.group_sign.Name = "group_sign"
        Me.group_sign.Size = New System.Drawing.Size(358, 172)
        Me.group_sign.TabIndex = 44
        Me.group_sign.TabStop = False
        Me.group_sign.Text = "Signification: ความสำคัญ"
        '
        'rb_general
        '
        Me.rb_general.AutoSize = True
        Me.rb_general.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rb_general.Location = New System.Drawing.Point(6, 77)
        Me.rb_general.Name = "rb_general"
        Me.rb_general.Size = New System.Drawing.Size(139, 22)
        Me.rb_general.TabIndex = 10
        Me.rb_general.Text = "General เรื่องทั่วไป"
        Me.rb_general.UseVisualStyleBackColor = True
        '
        'rb_important
        '
        Me.rb_important.AutoSize = True
        Me.rb_important.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rb_important.Location = New System.Drawing.Point(6, 49)
        Me.rb_important.Name = "rb_important"
        Me.rb_important.Size = New System.Drawing.Size(150, 22)
        Me.rb_important.TabIndex = 9
        Me.rb_important.Text = "Important เรื่องสำคัญ"
        Me.rb_important.UseVisualStyleBackColor = True
        '
        'rb_urgent
        '
        Me.rb_urgent.AutoSize = True
        Me.rb_urgent.Checked = True
        Me.rb_urgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rb_urgent.Location = New System.Drawing.Point(6, 21)
        Me.rb_urgent.Name = "rb_urgent"
        Me.rb_urgent.Size = New System.Drawing.Size(181, 22)
        Me.rb_urgent.TabIndex = 8
        Me.rb_urgent.TabStop = True
        Me.rb_urgent.Text = "Line stop : ปัญหาหยุดไลน์"
        Me.rb_urgent.UseVisualStyleBackColor = True
        '
        'group_type
        '
        Me.group_type.BackColor = System.Drawing.Color.White
        Me.group_type.Controls.Add(Me.clbType)
        Me.group_type.Controls.Add(Me.Label10)
        Me.group_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.group_type.Location = New System.Drawing.Point(391, 176)
        Me.group_type.Name = "group_type"
        Me.group_type.Size = New System.Drawing.Size(316, 172)
        Me.group_type.TabIndex = 43
        Me.group_type.TabStop = False
        Me.group_type.Text = "Type of Work : ชนิดงาน"
        '
        'clbType
        '
        Me.clbType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clbType.FormattingEnabled = True
        Me.clbType.Items.AddRange(New Object() {"Safety : ปัญหาความปลอดภัย", "Mechanical : ปัญหาจากเครื่องจักร", "Electrical : ปัญหาระบบไฟฟ้า", "Others : ปัญหาอื่น ๆ "})
        Me.clbType.Location = New System.Drawing.Point(6, 23)
        Me.clbType.Name = "clbType"
        Me.clbType.Size = New System.Drawing.Size(304, 102)
        Me.clbType.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 18)
        Me.Label10.TabIndex = 20
        '
        'btn_insert
        '
        Me.btn_insert.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_insert.Location = New System.Drawing.Point(558, 535)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(149, 32)
        Me.btn_insert.TabIndex = 42
        Me.btn_insert.Text = "Send Request"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'tb_found
        '
        Me.tb_found.AutoCompleteCustomSource.AddRange(New String() {"Tunwa  Wannakomol"})
        Me.tb_found.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tb_found.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tb_found.Location = New System.Drawing.Point(529, 130)
        Me.tb_found.Name = "tb_found"
        Me.tb_found.Size = New System.Drawing.Size(178, 20)
        Me.tb_found.TabIndex = 39
        '
        'tb_tag
        '
        Me.tb_tag.Location = New System.Drawing.Point(529, 95)
        Me.tb_tag.Name = "tb_tag"
        Me.tb_tag.ReadOnly = True
        Me.tb_tag.Size = New System.Drawing.Size(178, 20)
        Me.tb_tag.TabIndex = 38
        Me.tb_tag.Visible = False
        '
        'tb_code
        '
        Me.tb_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tb_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.tb_code.Location = New System.Drawing.Point(203, 97)
        Me.tb_code.MaxLength = 4
        Me.tb_code.Name = "tb_code"
        Me.tb_code.Size = New System.Drawing.Size(163, 20)
        Me.tb_code.TabIndex = 36
        '
        'tb_detail
        '
        Me.tb_detail.Location = New System.Drawing.Point(18, 376)
        Me.tb_detail.Multiline = True
        Me.tb_detail.Name = "tb_detail"
        Me.tb_detail.Size = New System.Drawing.Size(689, 149)
        Me.tb_detail.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(227, 20)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Description: รายละเอียดความผิดปกดิ"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(388, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 20)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Request by: ผู้ร้องขอ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 18)
        Me.Label7.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Date request : วันที่ร้องขอ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(388, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Form Serial No."
        Me.Label5.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Machine No : รหัสเครื่องจักร"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(18, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 33)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Maintenance Request Form"
        '
        'lb_red
        '
        Me.lb_red.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_red.BackColor = System.Drawing.Color.Red
        Me.lb_red.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_red.Location = New System.Drawing.Point(0, 3)
        Me.lb_red.Name = "lb_red"
        Me.lb_red.Size = New System.Drawing.Size(754, 83)
        Me.lb_red.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Location = New System.Drawing.Point(0, 528)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(754, 147)
        Me.Label2.TabIndex = 53
        '
        'frmPRD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 690)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPRD"
        Me.Text = "Maintenance Request Program"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_sign.ResumeLayout(False)
        Me.group_sign.PerformLayout()
        Me.group_type.ResumeLayout(False)
        Me.group_type.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents group_sign As GroupBox
    Friend WithEvents rb_general As RadioButton
    Friend WithEvents rb_important As RadioButton
    Friend WithEvents rb_urgent As RadioButton
    Friend WithEvents group_type As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btn_insert As Button
    Friend WithEvents tb_found As TextBox
    Friend WithEvents tb_tag As TextBox
    Friend WithEvents tb_code As TextBox
    Friend WithEvents tb_detail As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnStatus As Button
    Friend WithEvents btn_login As Button
    Friend WithEvents lb_red As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_date As TextBox
    Friend WithEvents clbType As CheckedListBox
End Class
