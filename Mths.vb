Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Web.Script.Serialization


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
