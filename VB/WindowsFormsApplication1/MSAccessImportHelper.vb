Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Office.Import
Imports DevExpress.Office.Internal
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.XtraSpreadsheet.Commands
Imports DevExpress.XtraSpreadsheet.Import
Imports DevExpress.XtraSpreadsheet.Internal
Imports DevExpress.XtraSpreadsheet.Services

Namespace AccessImport
	' custom DocumentImportManagerService - this class was created to register a custom document importer (AccessDBDocumentImporter)
	Public Class CustomDocumentImportManagerService
		Inherits DocumentImportManagerService
		Private _currentWorkbook As IWorkbook
		Public ReadOnly Property CurrentWorkbook() As IWorkbook
			Get
				Return _currentWorkbook
			End Get
		End Property
		Public Sub New(ByVal wb As IWorkbook)
			MyBase.New()
		_currentWorkbook = wb
		End Sub

		Protected Overrides Sub RegisterNativeFormats()
			MyBase.RegisterNativeFormats()
			RegisterImporter(New AccessDBDocumentImporter(Me))
		End Sub
	End Class

	' custom Access Database importer - this class contains implementation of a custom LoadDocument method and manages the "Open File Dialog" filters
	Public Class AccessDBDocumentImporter
		Implements IImporter(Of DocumentFormat, Boolean)
		#Region "IImporter<DocumentFormat,bool> Members"
		Private currentService As CustomDocumentImportManagerService

		Public Sub New(ByVal service As CustomDocumentImportManagerService)
			currentService = service
		End Sub

        Public ReadOnly Property Filter() As FileDialogFilter Implements IImporter(Of DevExpress.Spreadsheet.DocumentFormat, Boolean).Filter
            Get
                Return New FileDialogFilter("MS Access Database files", "mdb")
            End Get
        End Property

        Public ReadOnly Property Format() As DocumentFormat Implements IImporter(Of DevExpress.Spreadsheet.DocumentFormat, Boolean).Format
            Get
                Return DocumentFormat.Undefined
            End Get
        End Property

        Public Function LoadDocument(ByVal documentModel As DevExpress.Office.IDocumentModel, ByVal stream As System.IO.Stream, ByVal options As DevExpress.Office.Import.IImporterOptions) As Boolean Implements IImporter(Of DevExpress.Spreadsheet.DocumentFormat, Boolean).LoadDocument
            Return LoadDocument(documentModel, stream, options, True)
        End Function

        Public Function LoadDocument(ByVal documentModel As DevExpress.Office.IDocumentModel, ByVal stream As IO.Stream, ByVal options As IImporterOptions, ByVal leaveOpen As Boolean) As Boolean Implements IImporter(Of DevExpress.Spreadsheet.DocumentFormat, Boolean).LoadDocument
            If currentService IsNot Nothing AndAlso currentService.CurrentWorkbook IsNot Nothing Then
                currentService.CurrentWorkbook.LoadMSAccessFile((TryCast(stream, System.IO.FileStream)).Name)
            End If
            Return True
        End Function

        Public Function SetupLoading() As DevExpress.Office.Import.IImporterOptions Implements IImporter(Of DevExpress.Spreadsheet.DocumentFormat, Boolean).SetupLoading
            Return New AccessDBDocumentImporterOptions()
        End Function

		#End Region
	End Class

	' custom DocumentImporterOptions - this class was created to be used in the AccessDBDocumentImporter.SetupLoading method only
	Public Class AccessDBDocumentImporterOptions
		Inherits DocumentImporterOptions
		Protected Overrides ReadOnly Property Format() As DocumentFormat
			Get
				Return DocumentFormat.Undefined
			End Get
		End Property
	End Class

	' static class which provides the LoadMSAccessFile extension method in which a loading MDB files is implemented
	Public Module MSAccessImportHelper
		' add a "MS Access File" option into a standard Open File dialog
        <System.Runtime.CompilerServices.Extension> _
        Public Sub ExtendOpenFileCommand(ByVal spreadSheet As SpreadsheetControl)
            Dim service As IDocumentImportManagerService = CType(spreadSheet.GetService(GetType(IDocumentImportManagerService)), IDocumentImportManagerService)
            Dim customService As New CustomDocumentImportManagerService(spreadSheet.Document)
            spreadSheet.ReplaceService(Of IDocumentImportManagerService)(customService)
        End Sub

		' establish a connection to MS Access Data Base and getting all user tables from the Data Base
        <System.Runtime.CompilerServices.Extension> _
        Public Sub LoadMSAccessFile(ByVal workbook As IWorkbook, ByVal fileName As String)
            Try
                Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileName

                ' Create the dataset and add the Categories table to it:
                Dim myAccessConn As OleDbConnection = Nothing
                Try
                    myAccessConn = New OleDbConnection(connectionString)
                Catch ex As Exception
                    MessageBox.Show("Error: Failed to create a database connection. " & Constants.vbCrLf & ex.Message, "Error")
                    Return
                End Try
                Try
                    myAccessConn.Open()
                    workbook.BeginUpdate()
                    workbook.CreateNewDocument()
                    ' We only want user tables, not system tables
                    Dim restrictions(3) As String
                    restrictions(3) = "Table"
                    ' Get list of user tables
                    Dim userTables As DataTable = myAccessConn.GetSchema("Tables", restrictions)
                    ' Getting the data for every user tables
                    For Each userTablesRow As DataRow In userTables.Rows
                        Dim currentTableName As String = userTablesRow("TABLE_NAME").ToString()
                        Using cmd As New OleDbCommand(String.Format("SELECT * FROM [{0}]", currentTableName), myAccessConn)
                            Using adapter As New OleDbDataAdapter(cmd)
                                Dim currentDataTable As New DataTable(currentTableName)
                                adapter.Fill(currentDataTable)
                                LoadDataTableContentIntoSpreadsheetControl(workbook, currentDataTable, userTables.Rows.IndexOf(userTablesRow))
                            End Using
                        End Using
                    Next userTablesRow
                    workbook.EndUpdate()
                Catch ex As Exception
                    MessageBox.Show("Error: Failed to retrieve the required data from the DataBase." & Constants.vbCrLf & ex.Message, "Error")
                    Return
                Finally
                    myAccessConn.Close()
                End Try
            Catch ex As Exception
                MessageBox.Show("Error: Could not read file from disk. Original error: " & ex.Message)
            End Try
        End Sub

		' load a corresponding Data Table into a separate Worksheet
        Private Sub LoadDataTableContentIntoSpreadsheetControl(ByVal wb As IWorkbook, ByVal currentTable As DataTable, ByVal tableIndex As Integer)
            Dim workSheet As Worksheet = wb.Worksheets(0)
            If tableIndex > 0 Then
                workSheet = wb.Worksheets.Add()
            End If
            wb.Worksheets(tableIndex).Name = currentTable.TableName

            For i As Integer = 0 To currentTable.Columns.Count - 1
                Dim currentColumn As DataColumn = currentTable.Columns(i)
                workSheet.Cells(0, i).Value = currentColumn.ColumnName
            Next i

            For i As Integer = 0 To currentTable.Columns.Count - 1
                Dim currentColumn As DataColumn = currentTable.Columns(i)
                For j As Integer = 0 To currentTable.Rows.Count - 1
                    If currentTable.Rows(j)(i) Is DBNull.Value Then
                        Continue For
                    End If
                    Dim currentValue As Object = currentTable.Rows(j)(i)
                    Dim currentValueType As Type = currentColumn.DataType
                    If currentColumn.DataType Is GetType(DateTime) Then
                        workSheet.Cells(j + 1, i).Value = Convert.ToDateTime(currentTable.Rows(j)(i))
                    ElseIf currentColumn.DataType Is GetType(Int32) Then
                        workSheet.Cells(j + 1, i).Value = Convert.ToInt32(currentTable.Rows(j)(i))
                    ElseIf currentColumn.DataType Is GetType(Int16) Then
                        workSheet.Cells(j + 1, i).Value = Convert.ToInt16(currentTable.Rows(j)(i))
                    ElseIf currentColumn.DataType Is GetType(Single) Then
                        workSheet.Cells(j + 1, i).Value = Convert.ToSingle(currentTable.Rows(j)(i))
                    ElseIf currentColumn.DataType Is GetType(Decimal) Then
                        workSheet.Cells(j + 1, i).Value = Convert.ToDouble(currentTable.Rows(j)(i))
                    Else
                        workSheet.Cells(j + 1, i).Value = currentTable.Rows(j)(i).ToString()
                    End If
                Next j
            Next i
            Dim table As Table = workSheet.Tables.Add(workSheet.GetDataRange(), True)
            table.Style = wb.TableStyles(BuiltInTableStyleId.TableStyleLight1)
            workSheet.Columns.AutoFit(0, workSheet.Columns.LastUsedIndex)
        End Sub
	End Module
End Namespace
