<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockTimeForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LockTimeForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.textright = New System.Windows.Forms.ToolStripButton()
        Me.textleft = New System.Windows.Forms.ToolStripButton()
        Me.texttop = New System.Windows.Forms.ToolStripButton()
        Me.textbottom = New System.Windows.Forms.ToolStripButton()
        Me.textfull = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.aboutb = New System.Windows.Forms.ToolStripButton()
        Me.exitb = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.Label1.Size = New System.Drawing.Size(800, 286)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(0, 286)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)
        Me.Label2.Size = New System.Drawing.Size(800, 289)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = " " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 575)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Black
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.textright, Me.textleft, Me.texttop, Me.textbottom, Me.textfull, Me.ToolStripSeparator2, Me.aboutb, Me.exitb})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 575)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'textright
        '
        Me.textright.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.textright.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.textright.Image = CType(resources.GetObject("textright.Image"), System.Drawing.Image)
        Me.textright.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.textright.Name = "textright"
        Me.textright.Size = New System.Drawing.Size(23, 22)
        Me.textright.Text = "ToolStripButton3"
        '
        'textleft
        '
        Me.textleft.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.textleft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.textleft.Image = CType(resources.GetObject("textleft.Image"), System.Drawing.Image)
        Me.textleft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.textleft.Name = "textleft"
        Me.textleft.Size = New System.Drawing.Size(23, 22)
        Me.textleft.Text = "ToolStripButton4"
        '
        'texttop
        '
        Me.texttop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.texttop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.texttop.Image = CType(resources.GetObject("texttop.Image"), System.Drawing.Image)
        Me.texttop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.texttop.Name = "texttop"
        Me.texttop.Size = New System.Drawing.Size(23, 22)
        '
        'textbottom
        '
        Me.textbottom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.textbottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.textbottom.Image = CType(resources.GetObject("textbottom.Image"), System.Drawing.Image)
        Me.textbottom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.textbottom.Name = "textbottom"
        Me.textbottom.Size = New System.Drawing.Size(23, 22)
        '
        'textfull
        '
        Me.textfull.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.textfull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.textfull.Image = CType(resources.GetObject("textfull.Image"), System.Drawing.Image)
        Me.textfull.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.textfull.Name = "textfull"
        Me.textfull.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'aboutb
        '
        Me.aboutb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.aboutb.BackColor = System.Drawing.Color.Black
        Me.aboutb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.aboutb.ForeColor = System.Drawing.Color.White
        Me.aboutb.Image = CType(resources.GetObject("aboutb.Image"), System.Drawing.Image)
        Me.aboutb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.aboutb.Name = "aboutb"
        Me.aboutb.Size = New System.Drawing.Size(23, 22)
        '
        'exitb
        '
        Me.exitb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.exitb.BackColor = System.Drawing.Color.Black
        Me.exitb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.exitb.ForeColor = System.Drawing.Color.White
        Me.exitb.Image = CType(resources.GetObject("exitb.Image"), System.Drawing.Image)
        Me.exitb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exitb.Name = "exitb"
        Me.exitb.Size = New System.Drawing.Size(23, 22)
        '
        'LockTimeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LockTimeForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents exitb As System.Windows.Forms.ToolStripButton
    Friend WithEvents textright As System.Windows.Forms.ToolStripButton
    Friend WithEvents textleft As System.Windows.Forms.ToolStripButton
    Friend WithEvents textbottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents texttop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents textfull As System.Windows.Forms.ToolStripButton
    Friend WithEvents aboutb As System.Windows.Forms.ToolStripButton

End Class
