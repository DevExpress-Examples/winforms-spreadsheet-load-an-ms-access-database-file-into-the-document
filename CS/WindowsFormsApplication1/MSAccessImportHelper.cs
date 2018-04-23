using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Office.Import;
using DevExpress.Office.Internal;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using DevExpress.XtraSpreadsheet.Commands;
using DevExpress.XtraSpreadsheet.Import;
using DevExpress.XtraSpreadsheet.Internal;
using DevExpress.XtraSpreadsheet.Services;

namespace AccessImport {
    // custom DocumentImportManagerService - this class was created to register a custom document importer (AccessDBDocumentImporter)
    public class CustomDocumentImportManagerService : DocumentImportManagerService {
        IWorkbook _currentWorkbook;
        public IWorkbook CurrentWorkbook { get { return _currentWorkbook; } }
        public CustomDocumentImportManagerService(IWorkbook wb) : base() { _currentWorkbook = wb; }

        protected override void RegisterNativeFormats() {
            base.RegisterNativeFormats();
            RegisterImporter(new AccessDBDocumentImporter(this));
        }    
    }

    // custom Access Database importer - this class contains implementation of a custom LoadDocument method and manages the "Open File Dialog" filters
    public class AccessDBDocumentImporter : IImporter<DocumentFormat, bool> {
        #region IImporter<DocumentFormat,bool> Members
        CustomDocumentImportManagerService currentService;

        public AccessDBDocumentImporter(CustomDocumentImportManagerService service) { currentService = service; }

        public FileDialogFilter Filter {
            get { return new FileDialogFilter("MS Access Database files", "mdb" ); }
        }

        public DocumentFormat Format {
            get { return DocumentFormat.Undefined; }
        }

        public bool LoadDocument(DevExpress.Office.IDocumentModel documentModel, System.IO.Stream stream, DevExpress.Office.Import.IImporterOptions options) {
            return LoadDocument(documentModel, stream, options, true);
        }

        public bool LoadDocument(DevExpress.Office.IDocumentModel documentModel, System.IO.Stream stream, IImporterOptions options, bool leaveOpen) {
            if(currentService != null && currentService.CurrentWorkbook != null) {
                currentService.CurrentWorkbook.LoadMSAccessFile((stream as System.IO.FileStream).Name);
            }
            return true;
        }

        public DevExpress.Office.Import.IImporterOptions SetupLoading() {
            return new AccessDBDocumentImporterOptions();
        }

        #endregion
    }

    // custom DocumentImporterOptions - this class was created to be used in the AccessDBDocumentImporter.SetupLoading method only
    public class AccessDBDocumentImporterOptions : DocumentImporterOptions {
        protected override DocumentFormat Format {
            get { return DocumentFormat.Undefined; }
        }
    }

    // static class which provides the LoadMSAccessFile extension method in which a loading MDB files is implemented
    public static class MSAccessImportHelper {
        // add a "MS Access File" option into a standard Open File dialog
        public static void ExtendOpenFileCommand(this SpreadsheetControl spreadSheet) {
            IDocumentImportManagerService service = (IDocumentImportManagerService)spreadSheet.GetService(typeof(IDocumentImportManagerService));
            CustomDocumentImportManagerService customService = new CustomDocumentImportManagerService(spreadSheet.Document);
            spreadSheet.ReplaceService<IDocumentImportManagerService>(customService);
        }

        // establish a connection to MS Access Data Base and getting all user tables from the Data Base
        public static void LoadMSAccessFile(this IWorkbook workbook, string fileName) {
            try {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName;

                // Create the dataset and add the Categories table to it:
                OleDbConnection myAccessConn = null;
                try {
                    myAccessConn = new OleDbConnection(connectionString);
                }
                catch(Exception ex) {
                    MessageBox.Show("Error: Failed to create a database connection. \r\n" + ex.Message, "Error");
                    return;
                }
                try {
                    myAccessConn.Open();
                    workbook.BeginUpdate();
                    workbook.CreateNewDocument();
                    // We only want user tables, not system tables
                    string[] restrictions = new string[4];
                    restrictions[3] = "Table";
                    // Get list of user tables
                    DataTable userTables = myAccessConn.GetSchema("Tables", restrictions);
                    // Getting the data for every user tables
                    foreach(DataRow userTablesRow in userTables.Rows) {
                        string currentTableName = userTablesRow["TABLE_NAME"].ToString();
                        using(OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]", currentTableName), myAccessConn)) {
                            using(OleDbDataAdapter adapter = new OleDbDataAdapter(cmd)) {
                                DataTable currentDataTable = new DataTable(currentTableName);
                                adapter.Fill(currentDataTable);
                                LoadDataTableContentIntoSpreadsheetControl(workbook, currentDataTable, userTables.Rows.IndexOf(userTablesRow));
                            }
                        }
                    }
                    workbook.EndUpdate();
                }
                catch(Exception ex) {
                    MessageBox.Show("Error: Failed to retrieve the required data from the DataBase.\r\n" + ex.Message, "Error");
                    return;
                }
                finally {
                    myAccessConn.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        // load a corresponding Data Table into a separate Worksheet
        static void LoadDataTableContentIntoSpreadsheetControl(IWorkbook wb, DataTable currentTable, int tableIndex) {
            Worksheet workSheet = wb.Worksheets[0];
            if(tableIndex > 0) {
                workSheet = wb.Worksheets.Add();
            }
            wb.Worksheets[tableIndex].Name = currentTable.TableName;

            for(int i = 0; i < currentTable.Columns.Count; i++) {
                DataColumn currentColumn = currentTable.Columns[i];
                workSheet.Cells[0, i].Value = currentColumn.ColumnName;
            }

            for(int i = 0; i < currentTable.Columns.Count; i++) {
                DataColumn currentColumn = currentTable.Columns[i];
                for(int j = 0; j < currentTable.Rows.Count; j++) {
                    if(currentTable.Rows[j][i] == DBNull.Value) continue;
                    object currentValue = currentTable.Rows[j][i];
                    Type currentValueType = currentColumn.DataType;
                    if(currentColumn.DataType == typeof(DateTime))
                        workSheet.Cells[j + 1, i].Value = Convert.ToDateTime(currentTable.Rows[j][i]);
                    else if(currentColumn.DataType == typeof(Int32))
                        workSheet.Cells[j + 1, i].Value = Convert.ToInt32(currentTable.Rows[j][i]);
                    else if(currentColumn.DataType == typeof(Int16))
                        workSheet.Cells[j + 1, i].Value = Convert.ToInt16(currentTable.Rows[j][i]);
                    else if(currentColumn.DataType == typeof(Single))
                        workSheet.Cells[j + 1, i].Value = Convert.ToSingle(currentTable.Rows[j][i]);
                    else if(currentColumn.DataType == typeof(decimal))
                        workSheet.Cells[j + 1, i].Value = Convert.ToDouble(currentTable.Rows[j][i]);
                    else
                        workSheet.Cells[j + 1, i].Value = currentTable.Rows[j][i].ToString();
                }
            }
            Table table = workSheet.Tables.Add(workSheet.GetDataRange(), true);
            table.Style = wb.TableStyles[BuiltInTableStyleId.TableStyleLight1];
            workSheet.Columns.AutoFit(0, workSheet.Columns.LastUsedIndex);
        }
    }
}
