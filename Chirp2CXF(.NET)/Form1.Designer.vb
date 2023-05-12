<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        btnOpenCSV = New Button()
        lblHelloWorld = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        OpenFileDialog1 = New OpenFileDialog()
        OpenFileDialog2 = New OpenFileDialog()
        btnOpenCXF = New Button()
        lblCXFfileselected = New Label()
        btnCreate = New Button()
        lblResult = New Label()
        ListBox1 = New ListBox()
        RichTextBox1 = New RichTextBox()
        SuspendLayout()
        ' 
        ' btnOpenCSV
        ' 
        btnOpenCSV.Location = New Point(62, 272)
        btnOpenCSV.Name = "btnOpenCSV"
        btnOpenCSV.Size = New Size(161, 29)
        btnOpenCSV.TabIndex = 0
        btnOpenCSV.Text = "Select CHIRP csv file"
        btnOpenCSV.UseVisualStyleBackColor = True
        ' 
        ' lblHelloWorld
        ' 
        lblHelloWorld.AutoSize = True
        lblHelloWorld.Location = New Point(66, 316)
        lblHelloWorld.Name = "lblHelloWorld"
        lblHelloWorld.Size = New Size(134, 20)
        lblHelloWorld.TabIndex = 1
        lblHelloWorld.Text = "no csv file selected"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        OpenFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
        ' 
        ' OpenFileDialog2
        ' 
        OpenFileDialog2.FileName = "OpenFileDialog2"
        OpenFileDialog2.Filter = "CXF File (*.cxf)|*.cxf"
        ' 
        ' btnOpenCXF
        ' 
        btnOpenCXF.Location = New Point(66, 363)
        btnOpenCXF.Name = "btnOpenCXF"
        btnOpenCXF.Size = New Size(158, 29)
        btnOpenCXF.TabIndex = 2
        btnOpenCXF.Text = "Select CPS cxf file"
        btnOpenCXF.UseVisualStyleBackColor = True
        ' 
        ' lblCXFfileselected
        ' 
        lblCXFfileselected.AutoSize = True
        lblCXFfileselected.Location = New Point(62, 412)
        lblCXFfileselected.Name = "lblCXFfileselected"
        lblCXFfileselected.Size = New Size(133, 20)
        lblCXFfileselected.TabIndex = 3
        lblCXFfileselected.Text = "no cxf file selected"
        ' 
        ' btnCreate
        ' 
        btnCreate.Location = New Point(62, 462)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(158, 29)
        btnCreate.TabIndex = 4
        btnCreate.Text = "Create new CPS file"
        btnCreate.UseVisualStyleBackColor = True
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(62, 508)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(15, 20)
        lblResult.TabIndex = 5
        lblResult.Text = "-"
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 20
        ListBox1.Location = New Point(508, 19)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(266, 404)
        ListBox1.TabIndex = 7
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(66, 19)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(397, 229)
        RichTextBox1.TabIndex = 8
        RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(795, 550)
        Controls.Add(RichTextBox1)
        Controls.Add(ListBox1)
        Controls.Add(lblResult)
        Controls.Add(btnCreate)
        Controls.Add(lblCXFfileselected)
        Controls.Add(btnOpenCXF)
        Controls.Add(lblHelloWorld)
        Controls.Add(btnOpenCSV)
        Name = "Form1"
        Text = "CHIRP2cxf(.NET)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnOpenCSV As Button
    Friend WithEvents lblHelloWorld As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents btnOpenCXF As Button
    Friend WithEvents lblCXFfileselected As Label
    Friend WithEvents btnCreate As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
