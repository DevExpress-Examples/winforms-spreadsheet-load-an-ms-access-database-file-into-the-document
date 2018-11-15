<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [MSAccessImportHelper.cs](./CS/WindowsFormsApplication1/MSAccessImportHelper.cs) (VB: [MSAccessImportHelper.vb](./VB/WindowsFormsApplication1/MSAccessImportHelper.vb))
<!-- default file list end -->
# How to load an MS Access Database file into the SpreadsheetControl's document


<p>This example demonstrates how to extend the list of supported files which is displayed in the "Open File" dialog with the "MDB" file format while loading a document into the SpreadsheetControl.</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-load-an-ms-access-database-file-into-the-spreadsheetcontrols-document-t304456/15.2.9+/media/905af7e1-7bf3-11e5-80bf-00155d62480c.png"><br />
<p>To extend this list, a custom <strong>AccessDBDocumentImporter</strong> class was implemented. To add this functionality into an existing project, simply execute the <strong>SpreadsheetControl.ExtendOpenFileCommand</strong> method:</p>


```cs
spreadsheetControl1.ExtendOpenFileCommand();

```


<p>To load data from an MS Access Database file, a corresponding extension <strong>LoadMSAccessFile</strong> method was implemented. This method can be used for the SpreadsheetControl's document, as well as the Workbook instance.</p>

<br/>


