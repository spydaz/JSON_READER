<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormJson_Reader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormJson_Reader))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonCloseTab = New System.Windows.Forms.Button()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.ButtonImport = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabDocumentBrowser = New System.Windows.Forms.TabControl()
        Me.MAIN_READER = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DataGridView_JsonData = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ButtonExportData = New System.Windows.Forms.Button()
        Me.ButtonTAB_Reload = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox_JsonText = New System.Windows.Forms.RichTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ButtonTab_Export = New System.Windows.Forms.Button()
        Me.ButtonTAB_Import = New System.Windows.Forms.Button()
        Me.API_CLIENT = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox_API_RESPONSE = New System.Windows.Forms.RichTextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TextBox_API_SENDTEXT = New System.Windows.Forms.TextBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.ButtonAPI_Req = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabDocumentBrowser.SuspendLayout()
        Me.MAIN_READER.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.DataGridView_JsonData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.API_CLIENT.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.JSON_READER.My.Resources.Resources.BluPrint
        Me.GroupBox1.Controls.Add(Me.ButtonCloseTab)
        Me.GroupBox1.Controls.Add(Me.TextBoxFileName)
        Me.GroupBox1.Controls.Add(Me.ButtonExport)
        Me.GroupBox1.Controls.Add(Me.ButtonImport)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(806, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Control"
        '
        'ButtonCloseTab
        '
        Me.ButtonCloseTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCloseTab.ForeColor = System.Drawing.Color.Black
        Me.ButtonCloseTab.Image = Global.JSON_READER.My.Resources.Resources.end_right
        Me.ButtonCloseTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCloseTab.Location = New System.Drawing.Point(746, 22)
        Me.ButtonCloseTab.Name = "ButtonCloseTab"
        Me.ButtonCloseTab.Size = New System.Drawing.Size(44, 38)
        Me.ButtonCloseTab.TabIndex = 2
        Me.ButtonCloseTab.Tag = "Close Current Tab"
        Me.ButtonCloseTab.Text = "X"
        Me.ButtonCloseTab.UseVisualStyleBackColor = True
        '
        'TextBoxFileName
        '
        Me.TextBoxFileName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFileName.Location = New System.Drawing.Point(10, 28)
        Me.TextBoxFileName.Name = "TextBoxFileName"
        Me.TextBoxFileName.Size = New System.Drawing.Size(469, 26)
        Me.TextBoxFileName.TabIndex = 1
        '
        'ButtonExport
        '
        Me.ButtonExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExport.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExport.ForeColor = System.Drawing.Color.White
        Me.ButtonExport.Image = CType(resources.GetObject("ButtonExport.Image"), System.Drawing.Image)
        Me.ButtonExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonExport.Location = New System.Drawing.Point(604, 22)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(111, 38)
        Me.ButtonExport.TabIndex = 0
        Me.ButtonExport.Text = "Exports JSon Text"
        Me.ButtonExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonExport.UseVisualStyleBackColor = False
        '
        'ButtonImport
        '
        Me.ButtonImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonImport.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImport.ForeColor = System.Drawing.Color.White
        Me.ButtonImport.Image = CType(resources.GetObject("ButtonImport.Image"), System.Drawing.Image)
        Me.ButtonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonImport.Location = New System.Drawing.Point(485, 22)
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.Size = New System.Drawing.Size(113, 38)
        Me.ButtonImport.TabIndex = 0
        Me.ButtonImport.Text = "Import"
        Me.ButtonImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonImport.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImage = Global.JSON_READER.My.Resources.Resources.BluPrint
        Me.GroupBox2.Controls.Add(Me.TabDocumentBrowser)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(0, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(806, 619)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Viewer"
        '
        'TabDocumentBrowser
        '
        Me.TabDocumentBrowser.Controls.Add(Me.MAIN_READER)
        Me.TabDocumentBrowser.Controls.Add(Me.API_CLIENT)
        Me.TabDocumentBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabDocumentBrowser.Location = New System.Drawing.Point(3, 16)
        Me.TabDocumentBrowser.Name = "TabDocumentBrowser"
        Me.TabDocumentBrowser.SelectedIndex = 0
        Me.TabDocumentBrowser.Size = New System.Drawing.Size(800, 600)
        Me.TabDocumentBrowser.TabIndex = 0
        '
        'MAIN_READER
        '
        Me.MAIN_READER.BackgroundImage = Global.JSON_READER.My.Resources.Resources.Console_B
        Me.MAIN_READER.Controls.Add(Me.GroupBox4)
        Me.MAIN_READER.Controls.Add(Me.GroupBox3)
        Me.MAIN_READER.Location = New System.Drawing.Point(4, 22)
        Me.MAIN_READER.Margin = New System.Windows.Forms.Padding(2)
        Me.MAIN_READER.Name = "MAIN_READER"
        Me.MAIN_READER.Size = New System.Drawing.Size(792, 574)
        Me.MAIN_READER.TabIndex = 0
        Me.MAIN_READER.Text = "Json Reader"
        Me.MAIN_READER.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox8)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 200)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(792, 374)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.DataGridView_JsonData)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox8.Location = New System.Drawing.Point(134, 16)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(655, 355)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "JSON DATA"
        '
        'DataGridView_JsonData
        '
        Me.DataGridView_JsonData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_JsonData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_JsonData.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView_JsonData.Name = "DataGridView_JsonData"
        Me.DataGridView_JsonData.RowHeadersWidth = 51
        Me.DataGridView_JsonData.Size = New System.Drawing.Size(649, 336)
        Me.DataGridView_JsonData.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ButtonExportData)
        Me.GroupBox6.Controls.Add(Me.ButtonTAB_Reload)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox6.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(131, 355)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'ButtonExportData
        '
        Me.ButtonExportData.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonExportData.BackColor = System.Drawing.Color.Tomato
        Me.ButtonExportData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonExportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportData.ForeColor = System.Drawing.Color.Black
        Me.ButtonExportData.Image = CType(resources.GetObject("ButtonExportData.Image"), System.Drawing.Image)
        Me.ButtonExportData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonExportData.Location = New System.Drawing.Point(8, 162)
        Me.ButtonExportData.Name = "ButtonExportData"
        Me.ButtonExportData.Size = New System.Drawing.Size(111, 38)
        Me.ButtonExportData.TabIndex = 4
        Me.ButtonExportData.Tag = "Exports Data and Title to Json"
        Me.ButtonExportData.Text = "Export"
        Me.ButtonExportData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonExportData.UseVisualStyleBackColor = False
        '
        'ButtonTAB_Reload
        '
        Me.ButtonTAB_Reload.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonTAB_Reload.BackColor = System.Drawing.Color.Tomato
        Me.ButtonTAB_Reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonTAB_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTAB_Reload.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTAB_Reload.ForeColor = System.Drawing.Color.Black
        Me.ButtonTAB_Reload.Image = CType(resources.GetObject("ButtonTAB_Reload.Image"), System.Drawing.Image)
        Me.ButtonTAB_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTAB_Reload.Location = New System.Drawing.Point(8, 105)
        Me.ButtonTAB_Reload.Name = "ButtonTAB_Reload"
        Me.ButtonTAB_Reload.Size = New System.Drawing.Size(111, 38)
        Me.ButtonTAB_Reload.TabIndex = 4
        Me.ButtonTAB_Reload.Text = "Reload"
        Me.ButtonTAB_Reload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonTAB_Reload.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(792, 200)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RichTextBox_JsonText)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.White
        Me.GroupBox7.Location = New System.Drawing.Point(134, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(655, 181)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "JSON TEXT"
        '
        'RichTextBox_JsonText
        '
        Me.RichTextBox_JsonText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox_JsonText.Location = New System.Drawing.Point(3, 16)
        Me.RichTextBox_JsonText.Name = "RichTextBox_JsonText"
        Me.RichTextBox_JsonText.Size = New System.Drawing.Size(649, 162)
        Me.RichTextBox_JsonText.TabIndex = 0
        Me.RichTextBox_JsonText.Text = ""
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ButtonTab_Export)
        Me.GroupBox5.Controls.Add(Me.ButtonTAB_Import)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox5.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(131, 181)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'ButtonTab_Export
        '
        Me.ButtonTab_Export.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonTab_Export.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonTab_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonTab_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTab_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTab_Export.ForeColor = System.Drawing.Color.Black
        Me.ButtonTab_Export.Image = CType(resources.GetObject("ButtonTab_Export.Image"), System.Drawing.Image)
        Me.ButtonTab_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTab_Export.Location = New System.Drawing.Point(6, 110)
        Me.ButtonTab_Export.Name = "ButtonTab_Export"
        Me.ButtonTab_Export.Size = New System.Drawing.Size(111, 38)
        Me.ButtonTab_Export.TabIndex = 2
        Me.ButtonTab_Export.Tag = "Exports Json Text"
        Me.ButtonTab_Export.Text = "Export"
        Me.ButtonTab_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonTab_Export.UseVisualStyleBackColor = False
        '
        'ButtonTAB_Import
        '
        Me.ButtonTAB_Import.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonTAB_Import.BackColor = System.Drawing.Color.Orchid
        Me.ButtonTAB_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonTAB_Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTAB_Import.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTAB_Import.ForeColor = System.Drawing.Color.Black
        Me.ButtonTAB_Import.Image = CType(resources.GetObject("ButtonTAB_Import.Image"), System.Drawing.Image)
        Me.ButtonTAB_Import.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTAB_Import.Location = New System.Drawing.Point(6, 24)
        Me.ButtonTAB_Import.Name = "ButtonTAB_Import"
        Me.ButtonTAB_Import.Size = New System.Drawing.Size(113, 38)
        Me.ButtonTAB_Import.TabIndex = 1
        Me.ButtonTAB_Import.Text = "Import"
        Me.ButtonTAB_Import.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonTAB_Import.UseVisualStyleBackColor = False
        '
        'API_CLIENT
        '
        Me.API_CLIENT.BackgroundImage = Global.JSON_READER.My.Resources.Resources.Console_A
        Me.API_CLIENT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.API_CLIENT.Controls.Add(Me.GroupBox10)
        Me.API_CLIENT.Controls.Add(Me.GroupBox9)
        Me.API_CLIENT.Location = New System.Drawing.Point(4, 22)
        Me.API_CLIENT.Name = "API_CLIENT"
        Me.API_CLIENT.Padding = New System.Windows.Forms.Padding(3)
        Me.API_CLIENT.Size = New System.Drawing.Size(792, 454)
        Me.API_CLIENT.TabIndex = 1
        Me.API_CLIENT.Text = "API CLIENT"
        Me.API_CLIENT.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.RichTextBox_API_RESPONSE)
        Me.GroupBox10.Controls.Add(Me.GroupBox13)
        Me.GroupBox10.Controls.Add(Me.GroupBox12)
        Me.GroupBox10.Controls.Add(Me.GroupBox11)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(786, 424)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        '
        'RichTextBox_API_RESPONSE
        '
        Me.RichTextBox_API_RESPONSE.BackColor = System.Drawing.SystemColors.Info
        Me.RichTextBox_API_RESPONSE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox_API_RESPONSE.Location = New System.Drawing.Point(75, 16)
        Me.RichTextBox_API_RESPONSE.Name = "RichTextBox_API_RESPONSE"
        Me.RichTextBox_API_RESPONSE.Size = New System.Drawing.Size(634, 336)
        Me.RichTextBox_API_RESPONSE.TabIndex = 6
        Me.RichTextBox_API_RESPONSE.Text = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox13.Location = New System.Drawing.Point(709, 16)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(74, 336)
        Me.GroupBox13.TabIndex = 5
        Me.GroupBox13.TabStop = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox12.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(72, 336)
        Me.GroupBox12.TabIndex = 4
        Me.GroupBox12.TabStop = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.TextBox_API_SENDTEXT)
        Me.GroupBox11.Controls.Add(Me.GroupBox15)
        Me.GroupBox11.Controls.Add(Me.GroupBox14)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox11.Location = New System.Drawing.Point(3, 352)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(780, 69)
        Me.GroupBox11.TabIndex = 3
        Me.GroupBox11.TabStop = False
        '
        'TextBox_API_SENDTEXT
        '
        Me.TextBox_API_SENDTEXT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox_API_SENDTEXT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_API_SENDTEXT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox_API_SENDTEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_API_SENDTEXT.Location = New System.Drawing.Point(89, 40)
        Me.TextBox_API_SENDTEXT.Name = "TextBox_API_SENDTEXT"
        Me.TextBox_API_SENDTEXT.Size = New System.Drawing.Size(602, 26)
        Me.TextBox_API_SENDTEXT.TabIndex = 2
        Me.TextBox_API_SENDTEXT.Tag = "https://api.websitename.com/Login?username=%3Cusername%3E&password=%3Cpassword%3E" &
    "&key=%3Capi_key%3E"
        Me.TextBox_API_SENDTEXT.Text = "https://api.websitename.com/Login?username=<username>&password=<password>&key=<ap" &
    "i_key>"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.ButtonAPI_Req)
        Me.GroupBox15.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox15.Location = New System.Drawing.Point(691, 16)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(86, 50)
        Me.GroupBox15.TabIndex = 1
        Me.GroupBox15.TabStop = False
        '
        'ButtonAPI_Req
        '
        Me.ButtonAPI_Req.BackColor = System.Drawing.Color.Black
        Me.ButtonAPI_Req.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAPI_Req.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAPI_Req.Image = Global.JSON_READER.My.Resources.Resources.Green_end_left
        Me.ButtonAPI_Req.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAPI_Req.Location = New System.Drawing.Point(3, 16)
        Me.ButtonAPI_Req.Name = "ButtonAPI_Req"
        Me.ButtonAPI_Req.Size = New System.Drawing.Size(80, 31)
        Me.ButtonAPI_Req.TabIndex = 0
        Me.ButtonAPI_Req.Text = "GO"
        Me.ButtonAPI_Req.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAPI_Req.UseVisualStyleBackColor = False
        '
        'GroupBox14
        '
        Me.GroupBox14.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox14.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(86, 50)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox9.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(786, 24)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        '
        'FormJson_Reader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 689)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormJson_Reader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JSON DATA VIEWER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabDocumentBrowser.ResumeLayout(False)
        Me.MAIN_READER.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.DataGridView_JsonData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.API_CLIENT.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBoxFileName As TextBox
    Friend WithEvents ButtonExport As Button
    Friend WithEvents ButtonImport As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TabDocumentBrowser As TabControl
    Friend WithEvents MAIN_READER As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents DataGridView_JsonData As DataGridView
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ButtonTAB_Reload As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents RichTextBox_JsonText As RichTextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ButtonTab_Export As Button
    Friend WithEvents ButtonTAB_Import As Button
    Friend WithEvents API_CLIENT As TabPage
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents RichTextBox_API_RESPONSE As RichTextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents TextBox_API_SENDTEXT As TextBox
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents ButtonAPI_Req As Button
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents ButtonCloseTab As Button
    Friend WithEvents ButtonExportData As Button
End Class
