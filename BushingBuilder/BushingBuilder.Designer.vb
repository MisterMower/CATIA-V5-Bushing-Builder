<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBushingBuilder
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
        Me.LabelBushingOD = New System.Windows.Forms.Label()
        Me.LabelBushingID = New System.Windows.Forms.Label()
        Me.TextBoxBushingID = New System.Windows.Forms.TextBox()
        Me.LabelBushingLength = New System.Windows.Forms.Label()
        Me.ButtonBuildBushing = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ComboBoxBushingOD = New System.Windows.Forms.ComboBox()
        Me.ComboBoxBushingLength = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LabelBushingOD
        '
        Me.LabelBushingOD.AutoSize = True
        Me.LabelBushingOD.Location = New System.Drawing.Point(140, 9)
        Me.LabelBushingOD.Name = "LabelBushingOD"
        Me.LabelBushingOD.Size = New System.Drawing.Size(54, 17)
        Me.LabelBushingOD.TabIndex = 1
        Me.LabelBushingOD.Text = "OD (in)"
        '
        'LabelBushingID
        '
        Me.LabelBushingID.AutoSize = True
        Me.LabelBushingID.Location = New System.Drawing.Point(12, 9)
        Me.LabelBushingID.Name = "LabelBushingID"
        Me.LabelBushingID.Size = New System.Drawing.Size(46, 17)
        Me.LabelBushingID.TabIndex = 3
        Me.LabelBushingID.Text = "ID (in)"
        '
        'TextBoxBushingID
        '
        Me.TextBoxBushingID.Location = New System.Drawing.Point(12, 29)
        Me.TextBoxBushingID.Name = "TextBoxBushingID"
        Me.TextBoxBushingID.Size = New System.Drawing.Size(125, 22)
        Me.TextBoxBushingID.TabIndex = 0
        '
        'LabelBushingLength
        '
        Me.LabelBushingLength.AutoSize = True
        Me.LabelBushingLength.Location = New System.Drawing.Point(277, 9)
        Me.LabelBushingLength.Name = "LabelBushingLength"
        Me.LabelBushingLength.Size = New System.Drawing.Size(77, 17)
        Me.LabelBushingLength.TabIndex = 5
        Me.LabelBushingLength.Text = "Length (in)"
        '
        'ButtonBuildBushing
        '
        Me.ButtonBuildBushing.Location = New System.Drawing.Point(12, 62)
        Me.ButtonBuildBushing.Name = "ButtonBuildBushing"
        Me.ButtonBuildBushing.Size = New System.Drawing.Size(125, 30)
        Me.ButtonBuildBushing.TabIndex = 3
        Me.ButtonBuildBushing.Text = "Build Bushing"
        Me.ButtonBuildBushing.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(274, 62)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(125, 30)
        Me.ButtonClose.TabIndex = 4
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ComboBoxBushingOD
        '
        Me.ComboBoxBushingOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBushingOD.FormattingEnabled = True
        Me.ComboBoxBushingOD.Items.AddRange(New Object() {"0.15625", "0.1875", "0.25", "0.203125", "0.3125", "0.40625", "0.4375", "0.5", "0.5625", "0.625", "0.75", "0.875", "1", "1.125", "1.25", "1.375", "1.5", "1.625", "1.75", "2.25", "2.75"})
        Me.ComboBoxBushingOD.Location = New System.Drawing.Point(143, 27)
        Me.ComboBoxBushingOD.Name = "ComboBoxBushingOD"
        Me.ComboBoxBushingOD.Size = New System.Drawing.Size(125, 24)
        Me.ComboBoxBushingOD.TabIndex = 1
        '
        'ComboBoxBushingLength
        '
        Me.ComboBoxBushingLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBushingLength.FormattingEnabled = True
        Me.ComboBoxBushingLength.Items.AddRange(New Object() {"0.125", "0.25", "0.3125", "0.375", "0.5", "0.625", "0.75", "1", "1.25", "1.375", "1.5", "1.75", "2", "2.125", "2.5", "3"})
        Me.ComboBoxBushingLength.Location = New System.Drawing.Point(274, 27)
        Me.ComboBoxBushingLength.Name = "ComboBoxBushingLength"
        Me.ComboBoxBushingLength.Size = New System.Drawing.Size(125, 24)
        Me.ComboBoxBushingLength.TabIndex = 2
        '
        'FormBushingBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 103)
        Me.Controls.Add(Me.ComboBoxBushingLength)
        Me.Controls.Add(Me.ComboBoxBushingOD)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonBuildBushing)
        Me.Controls.Add(Me.LabelBushingLength)
        Me.Controls.Add(Me.LabelBushingID)
        Me.Controls.Add(Me.TextBoxBushingID)
        Me.Controls.Add(Me.LabelBushingOD)
        Me.Name = "FormBushingBuilder"
        Me.Text = "Bushing Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelBushingOD As Label
    Friend WithEvents LabelBushingID As Label
    Friend WithEvents TextBoxBushingID As TextBox
    Friend WithEvents LabelBushingLength As Label
    Friend WithEvents ButtonBuildBushing As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ComboBoxBushingOD As ComboBox
    Friend WithEvents ComboBoxBushingLength As ComboBox
End Class
