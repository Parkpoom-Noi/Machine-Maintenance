<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMT))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnRefesh = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_Complete = New System.Windows.Forms.DataGridView()
        Me.tb_id = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgv_Edit = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DGV_MA = New System.Windows.Forms.DataGridView()
        Me.mt_tb_hrs = New System.Windows.Forms.MaskedTextBox()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_name = New System.Windows.Forms.Label()
        Me.mt_tb_sign = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.mt_rd_suvalence = New System.Windows.Forms.RadioButton()
        Me.mt_rd_temporary = New System.Windows.Forms.RadioButton()
        Me.mt_rd_complete = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cb_It = New System.Windows.Forms.CheckBox()
        Me.cb_Pond = New System.Windows.Forms.CheckBox()
        Me.cb_M = New System.Windows.Forms.CheckBox()
        Me.cb_john = New System.Windows.Forms.CheckBox()
        Me.mt_tb_problem = New System.Windows.Forms.TextBox()
        Me.mt_tb_date = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.mt_btn_save = New System.Windows.Forms.Button()
        Me.mt_tb_note = New System.Windows.Forms.TextBox()
        Me.mt_tb_detail = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.mt_tbfound = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.mt_tb_mcno = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.mt_tb_tag = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lb_red = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.cbJay = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Complete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgv_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGV_MA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1361, 677)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnRefesh)
        Me.TabPage2.Controls.Add(Me.btnLogout)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.tb_id)
        Me.TabPage2.Controls.Add(Me.btnChange)
        Me.TabPage2.Controls.Add(Me.btn_clear)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.mt_tb_hrs)
        Me.TabPage2.Controls.Add(Me.btnStatus)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.lb_name)
        Me.TabPage2.Controls.Add(Me.mt_tb_sign)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.mt_tb_problem)
        Me.TabPage2.Controls.Add(Me.mt_tb_date)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.mt_btn_save)
        Me.TabPage2.Controls.Add(Me.mt_tb_note)
        Me.TabPage2.Controls.Add(Me.mt_tb_detail)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.mt_tbfound)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.mt_tb_mcno)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.mt_tb_tag)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.lb_red)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1353, 651)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "For Maintenance"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnRefesh
        '
        Me.btnRefesh.Location = New System.Drawing.Point(396, 318)
        Me.btnRefesh.Name = "btnRefesh"
        Me.btnRefesh.Size = New System.Drawing.Size(95, 23)
        Me.btnRefesh.TabIndex = 96
        Me.btnRefesh.Text = "Refesh DATA"
        Me.btnRefesh.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(846, 50)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(84, 32)
        Me.btnLogout.TabIndex = 95
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv_Complete)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(740, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 203)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Complete Case Today"
        '
        'dgv_Complete
        '
        Me.dgv_Complete.AllowUserToAddRows = False
        Me.dgv_Complete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Complete.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Complete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Complete.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Complete.Location = New System.Drawing.Point(0, 19)
        Me.dgv_Complete.Name = "dgv_Complete"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Complete.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_Complete.Size = New System.Drawing.Size(605, 184)
        Me.dgv_Complete.TabIndex = 2
        '
        'tb_id
        '
        Me.tb_id.Location = New System.Drawing.Point(397, 19)
        Me.tb_id.Name = "tb_id"
        Me.tb_id.ReadOnly = True
        Me.tb_id.Size = New System.Drawing.Size(52, 20)
        Me.tb_id.TabIndex = 91
        Me.tb_id.Visible = False
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(739, 11)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(190, 32)
        Me.btnChange.TabIndex = 91
        Me.btnChange.Text = "Change Password"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(497, 318)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(81, 23)
        Me.btn_clear.TabIndex = 87
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgv_Edit)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(739, 351)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(610, 285)
        Me.GroupBox6.TabIndex = 85
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Older case Maintenance"
        '
        'dgv_Edit
        '
        Me.dgv_Edit.AllowUserToAddRows = False
        Me.dgv_Edit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Edit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Edit.Location = New System.Drawing.Point(0, 23)
        Me.dgv_Edit.Name = "dgv_Edit"
        Me.dgv_Edit.Size = New System.Drawing.Size(610, 262)
        Me.dgv_Edit.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.DGV_MA)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(9, 351)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(724, 285)
        Me.GroupBox5.TabIndex = 84
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "New case Maintenance"
        '
        'DGV_MA
        '
        Me.DGV_MA.AllowUserToAddRows = False
        Me.DGV_MA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_MA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_MA.Location = New System.Drawing.Point(0, 23)
        Me.DGV_MA.Name = "DGV_MA"
        Me.DGV_MA.Size = New System.Drawing.Size(724, 262)
        Me.DGV_MA.TabIndex = 2
        '
        'mt_tb_hrs
        '
        Me.mt_tb_hrs.Location = New System.Drawing.Point(497, 293)
        Me.mt_tb_hrs.Mask = "00:00"
        Me.mt_tb_hrs.Name = "mt_tb_hrs"
        Me.mt_tb_hrs.Size = New System.Drawing.Size(81, 20)
        Me.mt_tb_hrs.TabIndex = 83
        Me.mt_tb_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.mt_tb_hrs.ValidatingType = GetType(Date)
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.Gainsboro
        Me.btnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.Black
        Me.btnStatus.Location = New System.Drawing.Point(455, 14)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(37, 25)
        Me.btnStatus.TabIndex = 79
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(498, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Welcome :"
        '
        'lb_name
        '
        Me.lb_name.AutoSize = True
        Me.lb_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lb_name.Location = New System.Drawing.Point(584, 19)
        Me.lb_name.Name = "lb_name"
        Me.lb_name.Size = New System.Drawing.Size(68, 18)
        Me.lb_name.TabIndex = 77
        Me.lb_name.Text = "------------"
        '
        'mt_tb_sign
        '
        Me.mt_tb_sign.Location = New System.Drawing.Point(142, 151)
        Me.mt_tb_sign.Name = "mt_tb_sign"
        Me.mt_tb_sign.ReadOnly = True
        Me.mt_tb_sign.Size = New System.Drawing.Size(171, 20)
        Me.mt_tb_sign.TabIndex = 70
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(23, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 18)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "Signification"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.mt_rd_suvalence)
        Me.GroupBox4.Controls.Add(Me.mt_rd_temporary)
        Me.GroupBox4.Controls.Add(Me.mt_rd_complete)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(17, 283)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(330, 62)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status Fix"
        '
        'mt_rd_suvalence
        '
        Me.mt_rd_suvalence.AutoSize = True
        Me.mt_rd_suvalence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.mt_rd_suvalence.Location = New System.Drawing.Point(202, 26)
        Me.mt_rd_suvalence.Name = "mt_rd_suvalence"
        Me.mt_rd_suvalence.Size = New System.Drawing.Size(79, 17)
        Me.mt_rd_suvalence.TabIndex = 2
        Me.mt_rd_suvalence.TabStop = True
        Me.mt_rd_suvalence.Text = "Survalence"
        Me.mt_rd_suvalence.UseVisualStyleBackColor = True
        '
        'mt_rd_temporary
        '
        Me.mt_rd_temporary.AutoSize = True
        Me.mt_rd_temporary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.mt_rd_temporary.Location = New System.Drawing.Point(93, 26)
        Me.mt_rd_temporary.Name = "mt_rd_temporary"
        Me.mt_rd_temporary.Size = New System.Drawing.Size(91, 17)
        Me.mt_rd_temporary.TabIndex = 1
        Me.mt_rd_temporary.TabStop = True
        Me.mt_rd_temporary.Text = "Temporary Fix"
        Me.mt_rd_temporary.UseVisualStyleBackColor = True
        '
        'mt_rd_complete
        '
        Me.mt_rd_complete.AutoSize = True
        Me.mt_rd_complete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.mt_rd_complete.Location = New System.Drawing.Point(6, 26)
        Me.mt_rd_complete.Name = "mt_rd_complete"
        Me.mt_rd_complete.Size = New System.Drawing.Size(69, 17)
        Me.mt_rd_complete.TabIndex = 0
        Me.mt_rd_complete.TabStop = True
        Me.mt_rd_complete.Text = "Complete"
        Me.mt_rd_complete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbJay)
        Me.GroupBox3.Controls.Add(Me.cb_It)
        Me.GroupBox3.Controls.Add(Me.cb_Pond)
        Me.GroupBox3.Controls.Add(Me.cb_M)
        Me.GroupBox3.Controls.Add(Me.cb_john)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(353, 142)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 70)
        Me.GroupBox3.TabIndex = 67
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Maintenance notes"
        '
        'cb_It
        '
        Me.cb_It.AutoSize = True
        Me.cb_It.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cb_It.Location = New System.Drawing.Point(272, 44)
        Me.cb_It.Name = "cb_It"
        Me.cb_It.Size = New System.Drawing.Size(39, 20)
        Me.cb_It.TabIndex = 8
        Me.cb_It.Text = "IT"
        Me.cb_It.UseVisualStyleBackColor = True
        '
        'cb_Pond
        '
        Me.cb_Pond.AutoSize = True
        Me.cb_Pond.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cb_Pond.Location = New System.Drawing.Point(10, 44)
        Me.cb_Pond.Name = "cb_Pond"
        Me.cb_Pond.Size = New System.Drawing.Size(132, 20)
        Me.cb_Pond.TabIndex = 7
        Me.cb_Pond.Text = "Pond (Natthapon)"
        Me.cb_Pond.UseVisualStyleBackColor = True
        '
        'cb_M
        '
        Me.cb_M.AutoSize = True
        Me.cb_M.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cb_M.Location = New System.Drawing.Point(148, 23)
        Me.cb_M.Name = "cb_M"
        Me.cb_M.Size = New System.Drawing.Size(108, 20)
        Me.cb_M.TabIndex = 6
        Me.cb_M.Text = "M (Udomsak)"
        Me.cb_M.UseVisualStyleBackColor = True
        '
        'cb_john
        '
        Me.cb_john.AutoSize = True
        Me.cb_john.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cb_john.Location = New System.Drawing.Point(10, 23)
        Me.cb_john.Name = "cb_john"
        Me.cb_john.Size = New System.Drawing.Size(119, 20)
        Me.cb_john.TabIndex = 5
        Me.cb_john.Text = "John (Puwadet)"
        Me.cb_john.UseVisualStyleBackColor = True
        '
        'mt_tb_problem
        '
        Me.mt_tb_problem.Location = New System.Drawing.Point(142, 106)
        Me.mt_tb_problem.Multiline = True
        Me.mt_tb_problem.Name = "mt_tb_problem"
        Me.mt_tb_problem.ReadOnly = True
        Me.mt_tb_problem.Size = New System.Drawing.Size(485, 33)
        Me.mt_tb_problem.TabIndex = 66
        '
        'mt_tb_date
        '
        Me.mt_tb_date.Location = New System.Drawing.Point(142, 53)
        Me.mt_tb_date.Name = "mt_tb_date"
        Me.mt_tb_date.ReadOnly = True
        Me.mt_tb_date.Size = New System.Drawing.Size(171, 20)
        Me.mt_tb_date.TabIndex = 65
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Red
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(625, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(109, 88)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label20.Location = New System.Drawing.Point(356, 295)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(135, 16)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Total Time (Hrs : Min)"
        '
        'mt_btn_save
        '
        Me.mt_btn_save.Location = New System.Drawing.Point(613, 293)
        Me.mt_btn_save.Name = "mt_btn_save"
        Me.mt_btn_save.Size = New System.Drawing.Size(121, 48)
        Me.mt_btn_save.TabIndex = 61
        Me.mt_btn_save.Text = "Save Data"
        Me.mt_btn_save.UseVisualStyleBackColor = True
        '
        'mt_tb_note
        '
        Me.mt_tb_note.Location = New System.Drawing.Point(353, 214)
        Me.mt_tb_note.Multiline = True
        Me.mt_tb_note.Name = "mt_tb_note"
        Me.mt_tb_note.Size = New System.Drawing.Size(380, 60)
        Me.mt_tb_note.TabIndex = 54
        '
        'mt_tb_detail
        '
        Me.mt_tb_detail.Location = New System.Drawing.Point(17, 196)
        Me.mt_tb_detail.Multiline = True
        Me.mt_tb_detail.Name = "mt_tb_detail"
        Me.mt_tb_detail.ReadOnly = True
        Me.mt_tb_detail.Size = New System.Drawing.Size(330, 78)
        Me.mt_tb_detail.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.Location = New System.Drawing.Point(17, 174)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 18)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Problem Discription"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.Location = New System.Drawing.Point(24, 107)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 18)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Type of Problem"
        '
        'mt_tbfound
        '
        Me.mt_tbfound.Location = New System.Drawing.Point(467, 81)
        Me.mt_tbfound.Name = "mt_tbfound"
        Me.mt_tbfound.ReadOnly = True
        Me.mt_tbfound.Size = New System.Drawing.Size(160, 20)
        Me.mt_tbfound.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(329, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 18)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Reporting person"
        '
        'mt_tb_mcno
        '
        Me.mt_tb_mcno.Location = New System.Drawing.Point(142, 82)
        Me.mt_tb_mcno.Name = "mt_tb_mcno"
        Me.mt_tb_mcno.Size = New System.Drawing.Size(171, 20)
        Me.mt_tb_mcno.TabIndex = 46
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(24, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 18)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Red M/C No"
        '
        'mt_tb_tag
        '
        Me.mt_tb_tag.Location = New System.Drawing.Point(467, 50)
        Me.mt_tb_tag.Name = "mt_tb_tag"
        Me.mt_tb_tag.ReadOnly = True
        Me.mt_tb_tag.Size = New System.Drawing.Size(160, 20)
        Me.mt_tb_tag.TabIndex = 44
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(329, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 18)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "FORM SERIAL No"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 18)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Date found"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(277, 25)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Maintenance Request Form"
        '
        'lb_red
        '
        Me.lb_red.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_red.BackColor = System.Drawing.Color.Red
        Me.lb_red.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_red.Location = New System.Drawing.Point(0, 4)
        Me.lb_red.Name = "lb_red"
        Me.lb_red.Size = New System.Drawing.Size(1353, 135)
        Me.lb_red.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Location = New System.Drawing.Point(0, 555)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1353, 100)
        Me.Label4.TabIndex = 82
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton6.Location = New System.Drawing.Point(6, 26)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(99, 17)
        Me.RadioButton6.TabIndex = 0
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "John (Puwadet)"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(108, 26)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(88, 17)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "M (Udomsak)"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(199, 26)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(182, 17)
        Me.RadioButton4.TabIndex = 2
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "John and M (Puwadet/Udomsak)"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(6, 26)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(69, 17)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Complete"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(93, 26)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(91, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Temporary Fix"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(202, 26)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Survalence"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'cbJay
        '
        Me.cbJay.AutoSize = True
        Me.cbJay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbJay.Location = New System.Drawing.Point(148, 44)
        Me.cbJay.Name = "cbJay"
        Me.cbJay.Size = New System.Drawing.Size(91, 20)
        Me.cbJay.TabIndex = 5
        Me.cbJay.Text = "Jay (Wiroj)"
        Me.cbJay.UseVisualStyleBackColor = True
        '
        'frmMT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1360, 690)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMT"
        Me.Text = "Maintenance Request Program"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Complete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgv_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DGV_MA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents mt_tb_sign As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents mt_rd_suvalence As RadioButton
    Friend WithEvents mt_rd_temporary As RadioButton
    Friend WithEvents mt_rd_complete As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents mt_tb_problem As TextBox
    Friend WithEvents mt_tb_date As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label20 As Label
    Friend WithEvents mt_btn_save As Button
    Friend WithEvents mt_tb_note As TextBox
    Friend WithEvents mt_tb_detail As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents mt_tbfound As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents mt_tb_mcno As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents mt_tb_tag As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents DGV_MA As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents lb_name As Label
    Friend WithEvents btnStatus As Button
    Friend WithEvents lb_red As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents mt_tb_hrs As MaskedTextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dgv_Edit As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents btn_clear As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents tb_id As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_Complete As DataGridView
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnRefesh As Button
    Friend WithEvents cb_It As CheckBox
    Friend WithEvents cb_Pond As CheckBox
    Friend WithEvents cb_M As CheckBox
    Friend WithEvents cb_john As CheckBox
    Friend WithEvents cbJay As CheckBox
End Class
