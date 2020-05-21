Imports System.Reflection
Imports System.Web.Script.Serialization


Public Class FormJson_Reader




    ''' <summary>
    ''' Loads text file to new tab
    ''' </summary>
    ''' <returns></returns>
    Public Function LoadJson() As String

        Dim Scriptfile As String = ""
        Dim Ofile As New OpenFileDialog
        With Ofile
            .Filter = "Json files (*.Json)|*.Json"

            If (.ShowDialog() = DialogResult.OK) Then
                Scriptfile = .FileName
            End If
        End With
        Dim txt As String = ""
        If Scriptfile IsNot "" Then


            Try
                TextBoxFileName.Text = Scriptfile
                txt = My.Computer.FileSystem.ReadAllText(Scriptfile)
                AddTab(TabDocumentBrowser, TabPages, txt, Scriptfile)

            Catch ex As Exception

                MsgBox(ex.ToString,, "Error")
            End Try
        End If
        Return txt
    End Function
    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        On Error Resume Next
        'Get Text

        AddDataTab(TabDocumentBrowser, TabPages, JsonToDatset(LoadJson()).Tables("Json").DefaultView)

    End Sub
    ''' <summary>
    ''' Save VB
    ''' </summary>
    ''' <param name="Script"></param>
    Public Sub SaveScript(ByRef Script As String)
        Try
            Dim ScriptFile As String = ""
            Dim S As New SaveFileDialog
            With S
                .Filter = "Json Script File (*.Json)|*.Json"
                If (.ShowDialog() = DialogResult.OK) Then
                    ScriptFile = .FileName
                End If
            End With
            My.Computer.FileSystem.WriteAllText(ScriptFile, Script, True)
        Catch ex As Exception
            MsgBox(ex.ToString,, "error")
        End Try
    End Sub

#Region "TabFunctions"
    ''' <summary>
    ''' Current number of tabpages
    ''' </summary>
    Public TabPages As Integer = 0
    ''' <summary>
    ''' Checks if tab is web or text
    ''' </summary>
    ''' <returns></returns>
    Public Function IsWebTab() As Boolean
        IsWebTab = False
        If TabDocumentBrowser.SelectedTab.Text = "Browser" Then Return True
    End Function
    ''' <summary>
    ''' Checks if tab is web or text
    ''' </summary>
    ''' <returns></returns>
    Public Function IsTextTab() As Boolean
        IsTextTab = False
        If TabDocumentBrowser.SelectedTab.Text = "TextBox" Then Return True
    End Function

    ''' <summary>
    ''' Adds new tab with data
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Tabcount">number of pages</param>
    ''' <param name="Text">data</param>
    ''' <param name="Title">title</param>
    Public Sub AddTab(ByRef Sender As TabControl, ByRef Tabcount As Integer, ByRef Text As String, ByRef Title As String)
        Dim Body As New RichTextBox
        Body.Font = New Font(Sender.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill

        Body.Text = Text
        Dim NewPage As New TabPage()
        Tabcount += 1
        Body.ForeColor = Color.MidnightBlue

        Dim DocumentText As String = Title & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)

        Sender.TabPages.Add(NewPage)
        NewPage.Text = "TextBox"
        Sender.SelectedTab = NewPage
    End Sub
    ''' <summary>
    ''' Adds a current new tab(document)
    ''' </summary>
    ''' <param name="Sender">tab control</param>
    ''' <param name="Tabcount">tab count</param>
    Public Sub AddTab(ByRef Sender As TabControl, ByRef Tabcount As Integer)
        Dim Body As New RichTextBox
        Body.Font = New Font(Sender.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill
        Dim NewPage As New TabPage()
        Tabcount += 1
        Body.ForeColor = Color.MidnightBlue

        Dim DocumentText As String = "Document " & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)

        Sender.TabPages.Add(NewPage)
        NewPage.Text = "TextBox"
        Sender.SelectedTab = NewPage
    End Sub
    ''' <summary>
    ''' Closes current tab Unsaved
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Tabcount">number of current pages</param>
    Public Sub RemoveTab(ByRef Sender As TabControl, ByRef Tabcount As Integer)
        If Sender.SelectedTab.Name <> "VBWORKSPACE" = True Then

            If Not Sender.TabPages.Count = 1 Then
                Sender.TabPages.Remove(Sender.SelectedTab)
                Tabcount -= 1
            Else
                Sender.TabPages.Remove(Sender.SelectedTab)
                AddTab(Sender, Tabcount)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Closes all tabs
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Tabcount">number of tabs</param>
    Public Sub RemoveAllTabs(ByRef Sender As TabControl, ByRef Tabcount As Integer)

        For Each Page As TabPage In Sender.TabPages
            Sender.TabPages.Remove(Page)
        Next
        Tabcount = 0
        AddTab(Sender, Tabcount)
    End Sub
    ''' <summary>
    ''' removes all tabs except current
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="TabCount">number of tabs</param>
    Public Sub RemoveAllTabsButThis(ByRef Sender As TabControl, ByRef TabCount As Integer)
        For Each Page As TabPage In Sender.TabPages
            If Not Page.Name = Sender.SelectedTab.Name Then
                Sender.TabPages.Remove(Page)
                TabCount = 0 + 1
            Else
            End If
        Next
    End Sub
    ''' <summary>
    ''' Returns text held in current tab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <returns>text</returns>
    Public Function GetCurrentTabText(ByRef Sender As TabControl) As String
        If IsTextTab() = True Then
            Return CType(Sender.SelectedTab.Controls.Item("Body"), RichTextBox).Text
        Else
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Returns text held in current tab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <returns>text</returns>
    Public Function GetCurrentTabRichTextBox(ByRef Sender As TabControl) As RichTextBox
        If IsTextTab() = True Then
            Return CType(Sender.SelectedTab.Controls.Item("Body"), RichTextBox)
        Else
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' saves data in current tab to file
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Filename">filename</param>
    Public Sub SaveCurrentTab(ByRef Sender As TabControl, ByRef Filename As String)
        If IsTextTab() = True Then
            GetCurrentTabRichTextBox(Sender).SaveFile(Filename, RichTextBoxStreamType.RichText)
        Else
        End If
    End Sub
    ''' <summary>
    ''' loads file data into current tab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Filename">data file</param>
    Public Sub Open(ByRef Sender As TabControl, ByRef Filename As String)

        GetCurrentTabRichTextBox(Sender).LoadFile(Filename, RichTextBoxStreamType.PlainText)

    End Sub
    ''' <summary>
    ''' opens file in new tab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Tabcount">number of tabs</param>
    ''' <param name="Filename">file location</param>
    Public Sub OpenNewTab(ByRef Sender As TabControl, ByRef Tabcount As Integer, Filename As String)

        Dim Body As New RichTextBox
        Body.Font = New Font(TabDocumentBrowser.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill
        Body.ForeColor = Color.MidnightBlue


        Dim NewPage As New TabPage()
        Tabcount += 1

        Dim DocumentText As String = "Document " & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)
        Body.LoadFile(Filename, RichTextBoxStreamType.PlainText)
        Sender.TabPages.Add(NewPage)
        NewPage.Text = "TextBox"
    End Sub
    ''' <summary>
    ''' adds Webtab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <param name="Tabcount">number of pages</param>
    ''' <param name="Source">html source text</param>
    Public Sub AddWebSourceTab(ByRef Sender As TabControl, ByRef Tabcount As Integer, ByRef Source As String)

        Dim Body As New System.Windows.Forms.WebBrowser
        Body.Font = New Font(TabDocumentBrowser.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill
        Body.ScriptErrorsSuppressed = True
        Dim NewPage As New TabPage()
        Tabcount += 1

        Body.DocumentText = Source
        Body.Refresh()
        Dim DocumentText As String = "Document " & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)
        Body.Tag = TAB()
        NewPage.Text = "Browser"
        Sender.TabPages.Add(NewPage)
        Sender.SelectedTab = NewPage

    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        On Error Resume Next
        SaveScript(GetCurrentTabText(TabDocumentBrowser))
        '   JsonReader.DataSetToJSON()
    End Sub


#End Region
#Region "Data Tab Functions"
    ''' <summary>
    ''' Checks if tab is web or text or data
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDataTab() As Boolean
        IsDataTab = False
        If TabDocumentBrowser.SelectedTab.Text = "Data" Then Return True
    End Function

    ''' <summary>
    ''' Adds a current new tab(document)
    ''' </summary>
    ''' <param name="Sender">tab control</param>
    ''' <param name="Tabcount">tab count</param>
    Public Sub AddDataTab(ByRef Sender As TabControl, ByRef Tabcount As Integer)
        Dim Body As New DataGridView
        Body.Font = New Font(Sender.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill
        Dim NewPage As New TabPage()
        Tabcount += 1
        Body.ForeColor = Color.MidnightBlue

        Dim DocumentText As String = "JsonDataTable" & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)

        Sender.TabPages.Add(NewPage)
        NewPage.Text = "Data"
        Sender.SelectedTab = NewPage
    End Sub

    ''' <summary>
    ''' Adds a current new tab(document)
    ''' </summary>
    ''' <param name="Sender">tab control</param>
    ''' <param name="Tabcount">tab count</param>
    Public Sub AddDataTab(ByRef Sender As TabControl, ByRef Tabcount As Integer, ByRef Data As Object)
        Dim Body As New DataGridView
        Body.Font = New Font(Sender.Font.Name, 12, FontStyle.Regular)
        Body.Name = NameOf(Body)
        Body.Dock = DockStyle.Fill
        Dim NewPage As New TabPage()
        Tabcount += 1
        Body.ForeColor = Color.MidnightBlue
        Body.DataSource = Data
        Dim DocumentText As String = "JsonDataTable" & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)

        Sender.TabPages.Add(NewPage)
        NewPage.Text = "Data"
        Sender.SelectedTab = NewPage
    End Sub
#End Region


    Public Shared Function CreateDataSet(ByRef JSON_TEXT As String) As List(Of JsonReader.JsonColum)
        On Error Resume Next
        'Deserialize
        Dim JsonType As Object = JsonReader.DeSerializeJson(JSON_TEXT)
        Dim JsonDataset As New List(Of JsonReader.JsonColum)
        For Each item In JsonType

            'New Colum (Feild)
            Dim Col As New JsonReader.JsonColum

            If item.value.GetType().ToString = "System.String" = True Then
                'Save colum and data held
                Col.ColumName = item.key.ToString
                Col.Data = item.value.ToString
                'Update Json DataSet
                JsonDataset.Add(Col)
            Else
                'Dim temp As String = item.value.GetType().ToString
                If item.value.GetType().ToString = "System.Object[]" Then
                    'Get Sub Table
                    'Dim Count As Integer = 1
                    'For Each SubItem In item.value
                    '    Col.ColumName = item.key & " " & Count
                    '    Col.Data = SubItem.ToString

                    '    '        'Update Json DataSet
                    '    JsonDataset.Add(Col)
                    '    Count += 1
                    'Next
                    Dim Count As Integer = 1
                    For Each SubItem In item.value
                        For Each pair In SubItem
                            Col.ColumName = pair.Key & " " & Count
                            Col.Data = pair.Value

                            '        'Update Json DataSet
                            JsonDataset.Add(Col)



                        Next
                        Count += 1
                    Next

                Else
                End If
            End If

        Next
        Return JsonDataset
    End Function




    Public Function JsonToDatset(ByRef JSON_TEXT As String) As DataSet

        'Deserialize
        Dim JsonType As Object = JsonReader.DeSerializeJson(JSON_TEXT)
        'Prepare Datasets
        Dim DS As New DataSet
        'GET COLUMN NAMES
        Dim JsonDataset As List(Of JsonReader.JsonColum) = CreateDataSet(JSON_TEXT)

        ''Create Table
        DS.Tables.Add("Json")
        'Create Feilds
        For Each item In JsonDataset
            'Add ColumName
            DS.Tables("Json").Columns.Add(item.ColumName)
        Next

        'Create Datarow
        Dim dsNewRow As DataRow
        'Set Row For Json Table
        dsNewRow = DS.Tables("Json").NewRow()
        'Insert Data from JsonDataSet
        For Each item In JsonDataset
            'AddColumn
            dsNewRow.Item(item.ColumName) = item.Data
        Next
        'Add Row
        DS.Tables("Json").Rows.Add(dsNewRow)
        Return DS
    End Function
End Class
