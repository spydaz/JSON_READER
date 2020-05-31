Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Xml
Imports System.Data
Imports System.Text

Public Class FormJson_Reader


    ''' <summary>
    ''' Conversion from JSON
    ''' 
    ''' ADD: DataTabFromJson
    '''         AddDataTab(TabDocumentBrowser, TabPages, JsonReader.JsonToDatset(LoadJson()).Tables("Json").DefaultView)
    ''' </summary>
    Public Class JsonReader
        Private JSON_TEXT As String = ""
        ''' <summary>
        ''' GET FUNCTION
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <returns>String Response</returns>
        Public Shared Function GetAPIReq(ByRef URL As String) As String
            Dim Request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(URL)
            Request.Proxy = Nothing
            Request.UserAgent = "SpydazWebAI"
            '      request.Credentials = New NetworkCredential(Username, Password)

            Dim Response As System.Net.HttpWebResponse = Request.GetResponse
            Dim ResponseStream As IO.Stream = Response.GetResponseStream

            Dim Streamreader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = Streamreader.ReadToEnd
            Streamreader.Close()

            Return Data
        End Function
        ''' <summary>
        ''' Get function With Credentials
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <param name="UserName"></param>
        ''' <param name="Password"></param>
        ''' <returns>string response</returns>
        Public Shared Function GetAPIReq(ByRef URL As String, ByRef UserName As String, ByRef Password As String) As String
            Dim Request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(URL)
            Request.Proxy = Nothing
            Request.UserAgent = "SpydazWebAI"
            Request.Credentials = New NetworkCredential(UserName, Password)

            Dim Response As System.Net.HttpWebResponse = Request.GetResponse
            Dim ResponseStream As IO.Stream = Response.GetResponseStream

            Dim Streamreader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = Streamreader.ReadToEnd
            Streamreader.Close()

            Return Data
        End Function
        ''' <summary>
        ''' POST FUNCTION With Credentials
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <param name="Data"></param>
        ''' <param name="Username"></param>
        ''' <param name="Password"></param>
        ''' <returns></returns>
        Public Shared Function PostAPIReq(ByRef URL As String, ByRef Data As String, ByRef Username As String, ByRef Password As String) As String
            Dim Request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(URL)
            Dim DataReturned As String
            Request.Proxy = Nothing
            Request.UserAgent = "SpydazWebAI"
            Request.Credentials = New NetworkCredential(Username, Password)
            Request.Method = "POST"
            Request.ContentType = "text/plain;charset=utf-8"
            Dim encoding As New System.Text.UTF8Encoding()
            Dim bytes As Byte() = encoding.GetBytes(Data)
            Request.ContentLength = bytes.Length
            Using requestStream As Stream = Request.GetRequestStream()
                ' Send the data.  
                requestStream.Write(bytes, 0, bytes.Length)
                Dim Response As System.Net.HttpWebResponse = Request.GetResponse()
                Dim ResponseStream As IO.Stream = Response.GetResponseStream
                Dim Streamreader As New System.IO.StreamReader(ResponseStream)
                DataReturned = Streamreader.ReadToEnd
                Streamreader.Close()
            End Using
            'GetResponse
            Return DataReturned
        End Function
        ''' <summary>
        ''' Post Function
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <param name="Data"></param>
        ''' <returns></returns>
        Public Shared Function PostAPIReq(ByRef URL As String, ByRef Data As String) As String
            Dim Request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(URL)
            Dim DataReturned As String
            Request.Proxy = Nothing
            Request.UserAgent = "SpydazWebAI"

            Request.Method = "POST"
            Request.ContentType = "text/plain;charset=utf-8"
            Dim encoding As New System.Text.UTF8Encoding()
            Dim bytes As Byte() = encoding.GetBytes(Data)
            Request.ContentLength = bytes.Length
            Using requestStream As Stream = Request.GetRequestStream()
                ' Send the data.  
                requestStream.Write(bytes, 0, bytes.Length)
                Dim Response As System.Net.HttpWebResponse = Request.GetResponse()
                Dim ResponseStream As IO.Stream = Response.GetResponseStream
                Dim Streamreader As New System.IO.StreamReader(ResponseStream)
                DataReturned = Streamreader.ReadToEnd
                Streamreader.Close()
            End Using
            'GetResponse
            Return DataReturned
        End Function

        ''' <summary>
        ''' Returns as single token from WebServer
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <param name="SpecificToken"></param>
        ''' <returns></returns>
        Public Shared Function GetJsonResponse(ByRef URL As String, ByRef SpecificToken As String) As String
            'Dim res As String = JsonConvert.SerializeXmlNode(Doc)
            'Dim ThisToken As JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JObject)(res)
            'Dim response As String = ThisToken("response").ToString()
            'Dim ThisData As JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JObject)(response)

            Dim request As HttpWebRequest
            Dim Resp As HttpWebResponse = Nothing
            Dim reader As StreamReader
            request = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            Resp = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(Resp.GetResponseStream())
            Dim rawresp As String = reader.ReadToEnd()
            Return Newtonsoft.Json.Linq.JObject.Parse(rawresp)("id")
        End Function


        ''' <summary>
        '''Converts Dataset to Json string
        ''' </summary>
        ''' <param name="ds">DataSet</param>
        ''' <returns>Json Text</returns>
        Public Shared Function DataSetToJSON(ByRef ds As DataSet) As String
            Dim dict As New Dictionary(Of String, Object)

            For Each dt As DataTable In ds.Tables
                Dim arr(dt.Rows.Count) As Object

                For i As Integer = 0 To dt.Rows.Count - 1
                    arr(i) = dt.Rows(i).ItemArray
                Next

                dict.Add(dt.TableName, arr)
            Next
            Dim json As New JavaScriptSerializer
            Return json.Serialize(dict)
        End Function

        ''' <summary>
        ''' Converts Datatable to Json String
        ''' </summary>
        ''' <param name="DT"></param>
        ''' <returns></returns>
        Public Shared Function DataTableToJson(ByRef DT As DataTable) As String
            Dim dict As New Dictionary(Of String, Object)
            'Get Rows
            Dim arr(DT.Rows.Count) As Object
            For i As Integer = 0 To DT.Rows.Count - 1
                arr(i) = DT.Rows(i).ItemArray
            Next
            'Add Row to Dictionary
            dict.Add(DT.TableName, arr)
            'Create JSON
            Dim json As New JavaScriptSerializer
            Return json.Serialize(dict)
        End Function
        ''' <summary>
        ''' Converts JSON that is not nested into a DataTable.  Typically this would be JSON that represents the contents of a table that
        ''' is not nested.
        ''' </summary>
        ''' <param name="json"></param>
        ''' <param name="tableName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function JsonToDataTable(json As String, tableName As String) As DataTable
            Dim columnsCreated As Boolean = False
            Dim dt As New DataTable(tableName)

            Dim root As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(json)
            Dim items As Newtonsoft.Json.Linq.JArray = DirectCast(root(tableName), Newtonsoft.Json.Linq.JArray)

            Dim item As Newtonsoft.Json.Linq.JObject
            Dim jtoken As Newtonsoft.Json.Linq.JToken

            For i As Integer = 0 To items.Count - 1
                ' Create the columns once
                If columnsCreated = False Then
                    item = DirectCast(items(i), Newtonsoft.Json.Linq.JObject)
                    jtoken = item.First

                    While jtoken IsNot Nothing
                        dt.Columns.Add(New DataColumn(DirectCast(jtoken, Newtonsoft.Json.Linq.JProperty).Name.ToString()))
                        jtoken = jtoken.[Next]
                    End While

                    columnsCreated = True
                End If

                ' Add each of the columns into a new row then put that new row into the DataTable
                item = DirectCast(items(i), Newtonsoft.Json.Linq.JObject)
                jtoken = item.First

                ' Create the new row, put the values into the columns then add the row to the DataTable
                Dim dr As DataRow = dt.NewRow

                While jtoken IsNot Nothing
                    dr(DirectCast(jtoken, Newtonsoft.Json.Linq.JProperty).Name.ToString()) = DirectCast(jtoken, Newtonsoft.Json.Linq.JProperty).Value.ToString()
                    jtoken = jtoken.[Next]
                End While

                dt.Rows.Add(dr)
            Next

            Return dt

        End Function
        ''' <summary>
        ''' Converts data held in Datagridview to Datatable 
        ''' </summary>
        ''' <param name="DGV"></param>
        ''' <returns></returns>
        Public Shared Function DataGridToTable(ByRef DGV As DataGridView) As DataTable
            'Creating DataTable.
            Dim dt As New DataTable()
            '     Dim DGV As DataGridView = GetCurrentTabDataGridView(TabDocumentBrowser)
            'Adding the Columns.
            For Each column As DataGridViewColumn In DGV.Columns
                dt.Columns.Add(column.HeaderText, column.ValueType)
            Next

            'Adding the Rows.
            For Each row As DataGridViewRow In DGV.Rows
                dt.Rows.Add()
                For Each cell As DataGridViewCell In row.Cells
                    dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
                Next
            Next
            Return dt
        End Function
        ''' <summary>
        ''' Used To Hold Json Properties
        ''' </summary>
        Public Structure JsonColum
            ''' <summary>
            ''' FeildName
            ''' </summary>
            Public ColumName As String
            ''' <summary>
            ''' Value Held
            ''' </summary>
            Public Data As String
        End Structure
        ''' <summary>
        ''' deserialize object from Json
        ''' </summary>
        ''' <param name="Str">json</param>
        ''' <returns></returns>
        Public Shared Function DeSerializeJson(ByRef Str As String) As Object
            Try
                Dim Converter As New JavaScriptSerializer
                Dim diag As Object = Converter.Deserialize(Of Object)(Str)

                Return diag
            Catch ex As Exception
                Dim Buttons As MessageBoxButtons = MessageBoxButtons.OK
                MessageBox.Show(ex.Message, "ERROR", Buttons)
            End Try
            Return Nothing
        End Function
        ''' <summary>
        ''' Loads text file Using Open FIle DIalog
        ''' </summary>
        ''' <returns>Json string</returns>
        Public Shared Function LoadJson() As String

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
                    txt = My.Computer.FileSystem.ReadAllText(Scriptfile)
                Catch ex As Exception
                    MsgBox(ex.ToString,, "Error")
                End Try
            End If
            Return txt
        End Function

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



        Public Shared Function JsonToDatset(ByRef JSON_TEXT As String) As DataSet

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
        ''' <summary>
        ''' Save Json
        ''' </summary>
        ''' <param name="Script"></param>
        Public Shared Sub SaveScript(ByRef Script As String)
            Try
                Dim ScriptFile As String = ""
                Dim S As New SaveFileDialog
                With S
                    .Filter = "Json Script File (*.Json)|*.Json"
                    If (.ShowDialog() = DialogResult.OK) Then
                        ScriptFile = .FileName
                    End If
                End With
                My.Computer.FileSystem.WriteAllText(ScriptFile, Script, False)
            Catch ex As Exception
                MsgBox(ex.ToString,, "error")
            End Try
        End Sub
    End Class

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
                Filename = Scriptfile
                txt = My.Computer.FileSystem.ReadAllText(Scriptfile)


            Catch ex As Exception

                MsgBox(ex.ToString,, "Error")
            End Try
        End If
        Return txt
    End Function
    Public Function LoadJson(ByRef Scriptfile As String) As String

        Return My.Computer.FileSystem.ReadAllText(Scriptfile)
    End Function
    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        On Error Resume Next
        'Get Text

        AddDataTab(TabDocumentBrowser, TabPages, JsonReader.JsonToDatset(LoadJson()).Tables("Json").DefaultView)
        AddTab(TabDocumentBrowser, TabPages, LoadJson(Filename), Filename)
        TextBoxFileName.Text = Filename
    End Sub
    ''' <summary>
    ''' Save VB
    ''' </summary>
    ''' <param name="Script"></param>
    Public Sub SaveJSON(ByRef Script As String)
        Dim Enc As New System.Text.UnicodeEncoding
        Try
            Dim ScriptFile As String = ""
            Dim S As New SaveFileDialog
            With S
                .Filter = "Json Script File (*.Json)|*.Json"
                If (.ShowDialog() = DialogResult.OK) Then
                    ScriptFile = .FileName
                    Filename = ScriptFile
                End If
            End With
            My.Computer.FileSystem.WriteAllText(ScriptFile, Script, False, Enc)
        Catch ex As Exception
            MsgBox(ex.ToString,, "error")
        End Try
    End Sub
    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        If IsTextTab() = True Then
            SaveJSON(GetCurrentTabRichTextBox(sender).Text)
        Else
        End If
        TextBoxFileName.Text = Filename
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
        If Sender.SelectedTab.Name <> "MAIN_READER" = True Or Sender.SelectedTab.Name <> "API_CLIENT" Then

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



#End Region
#Region "Data Tab Functions"
    ''' <summary>
    ''' Returns text held in current tab
    ''' </summary>
    ''' <param name="Sender">tabcontrol</param>
    ''' <returns>text</returns>
    Public Function GetCurrentTabDataGridView(ByRef Sender As TabControl) As DataGridView
        If IsDataTab(Sender) = True Then
            Return CType(Sender.SelectedTab.Controls.Item("Body"), DataGridView)
        Else
        End If
        Return Nothing
    End Function




    ''' <summary>
    ''' Checks if tab is web or text or data
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDataTab(ByRef Sender As TabControl) As Boolean
        IsDataTab = False
        If Sender.SelectedTab.Text = "Data" Then Return True
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

        Dim DocumentText As String = "Data" & Tabcount
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
        Dim DocumentText As String = "Data" & Tabcount
        NewPage.Name = DocumentText
        NewPage.Text = DocumentText
        NewPage.Controls.Add(Body)

        Sender.TabPages.Add(NewPage)
        NewPage.Text = "Data"
        Sender.SelectedTab = NewPage
    End Sub

    Dim Filename As String = ""
    Private Sub ButtonTAB_Import_Click(sender As Object, e As EventArgs) Handles ButtonTAB_Import.Click

        DataGridView_JsonData.DataSource = JsonReader.JsonToDatset(LoadJson()).Tables("Json")
        RichTextBox_JsonText.Text = LoadJson(Filename)
        TextBoxFileName.Text = Filename
    End Sub

    Private Sub ButtonTab_Export_Click(sender As Object, e As EventArgs) Handles ButtonTab_Export.Click
        SaveJSON(RichTextBox_JsonText.Text)
    End Sub

    Private Sub ButtonTAB_Reload_Click(sender As Object, e As EventArgs) Handles ButtonTAB_Reload.Click
        '   RichTextBox_JsonText.Text = LoadJson(Filename)
        DataGridView_JsonData.DataSource = JsonReader.JsonToDatset(RichTextBox_JsonText.Text).Tables("Json")
        TextBoxFileName.Text = Filename
    End Sub


    Private Sub ButtonAPI_Req_Click(sender As Object, e As EventArgs) Handles ButtonAPI_Req.Click

        RichTextBox_API_RESPONSE.Text = GetAPIReq(TextBox_API_SENDTEXT.Text)

    End Sub

    Public Function GetAPIReq(ByRef URL As String) As String
        Dim Request As HttpWebRequest = HttpWebRequest.Create(URL)
        Request.Proxy = Nothing
        Request.UserAgent = "SpydazWebAI"

        Dim Response As HttpWebResponse = Request.GetResponse
        Dim ResponseStream As IO.Stream = Response.GetResponseStream

        Dim Streamreader As New System.IO.StreamReader(ResponseStream)
        Dim Data As String = Streamreader.ReadToEnd
        Streamreader.Close()

        Return Data
    End Function

    Private Sub ButtonCloseTab_Click(sender As Object, e As EventArgs) Handles ButtonCloseTab.Click
        RemoveTab(TabDocumentBrowser, TabPages)
    End Sub

    Private Sub ButtonExportData_Click(sender As Object, e As EventArgs) Handles ButtonExportData.Click

        ' Dim Str As String = JsonReader.DataSetToJSON(DataGridView_JsonData.DataSource)
        SaveJSON(JsonReader.DataTableToJson(DataGridView_JsonData.DataSource))
        '     SaveJSON(JsonReader.DataTableToJson(Convert_DataGridToTable(DataGridView_JsonData)))

    End Sub
    Public Function Convert_DataGridToTable(ByRef DGV As DataGridView) As DataTable
        'Creating DataTable.
        Dim dt As New DataTable()
        '     Dim DGV As DataGridView = GetCurrentTabDataGridView(TabDocumentBrowser)
        'Adding the Columns.
        For Each column As DataGridViewColumn In DGV.Columns
            dt.Columns.Add(column.HeaderText, column.ValueType)
        Next

        'Adding the Rows.
        For Each row As DataGridViewRow In DGV.Rows
            dt.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
            Next
        Next
        Return dt
    End Function
    '+--------------------------------------------------------------------------+
    '|																			|
    '|	FormatXml      			                							    |
    '|	=========                 	    										|
    '|																			|
    '|	Inputs:		string unformattedXml										|
    '|																			|
    '|	Returns:	string formattedXml											|
    '|																			|
    '|	Notes:		Use this method to perform some basic housekeeping on       |
    '|              XML string before plunking them into a text box.  It will   |
    '|              make the output easier on the eyes.                         |
    '+--------------------------------------------------------------------------+
    Public Function FormatXml(ByVal unformattedXml As String) As String
        Dim xd As New XmlDocument()
        Try
            xd.LoadXml(unformattedXml)
        Catch [error] As Exception
            System.Windows.Forms.MessageBox.Show([error].Message.ToString())
            Return unformattedXml
        End Try
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim xtw As XmlTextWriter = Nothing
        Try
            xtw = New XmlTextWriter(sw)
            xtw.Formatting = Formatting.Indented
            xd.WriteTo(xtw)
        Finally
            If xtw IsNot Nothing Then
                xtw.Close()
            End If
        End Try
        Return sb.ToString()
    End Function
    '       +---------------------------------------------------------------------------+
    '       |																     	    |
    '       |	FormatJson      			                							|
    '       |	=========                 	    										|
    '       |																			|
    '       |	Inputs:		string unformattedJson										|
    '       |																			|
    '       |	Returns:	string formattedJson										|
    '       |																			|
    '       |	Notes:	   Use this method to perform some basic housekeeping on        |
    '       |              JSON string before plunking them into a text box.  It will   |
    '       |              make the output easier on the eyes.                          |
    '       +---------------------------------------------------------------------------+															
    Public Function FormatJSON(ByVal unformattedJSON As String) As String
        Dim sb As New StringBuilder()
        Dim chars As Char() = unformattedJSON.ToCharArray()
        Dim len As Integer = chars.Length
        Dim indent As Integer = 0
        Dim last_char As Char = " "c
        Dim new_line As Boolean = True
        For i As Integer = 0 To len - 1
            If chars(i) = "}"c Then
                new_line = True
                sb.AppendLine()
            ElseIf chars(i) = "{"c Then
                If i > 0 Then
                    sb.AppendLine()
                    For j As Integer = 0 To indent - 1
                        sb.Append(" "c)
                    Next
                End If
            End If
            If last_char = "}"c Then
                indent -= 3
            End If
            If last_char = "{"c Then
                new_line = True
                sb.AppendLine()
                indent += 3
            End If
            If last_char = ","c Then
                sb.AppendLine()
                new_line = True
            End If
            If new_line Then
                For j As Integer = 0 To indent - 1
                    sb.Append(" "c)
                Next
            End If
            sb.Append(chars(i))
            new_line = False
            last_char = chars(i)
        Next
        Return sb.ToString()
    End Function
    Private Sub RichTextBox_JsonText_Leave(sender As Object, e As EventArgs) Handles RichTextBox_JsonText.Leave
        '+--------------------------------------------------------------------------+
        '|																			|
        '|	txtPostvars_Leave		                							    |
        '|	=================          	    										|
        '|																			|
        '|	Inputs:		object sender (ignored)										|
        '|              EventArgs e   (ignored)                                     |
        '|																			|
        '|	Returns:	VOID            											|
        '|																			|
        '|	Notes:		Default event called when text box looses focus.            |
        '|              Whenever the user modifies the XML post vars we will see    |
        '|              if we can't pretty it up.                                   |
        '+--------------------------------------------------------------------------+	

        'Handles sender.leave
        If sender.TextLength > 0 Then
            Dim txt As [String] = ""

            txt = FormatXml(sender.Text)

                sender.Text = txt
        End If

    End Sub
#End Region
End Class
