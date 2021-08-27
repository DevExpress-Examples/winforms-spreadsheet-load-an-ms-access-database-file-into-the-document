<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128613778/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T304456)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [MSAccessImportHelper.cs](./CS/WindowsFormsApplication1/MSAccessImportHelper.cs) (VB: [MSAccessImportHelper.vb](./VB/WindowsFormsApplication1/MSAccessImportHelper.vb))
* [Program.cs](./CS/WindowsFormsApplication1/Program.cs) (VB: [Program.vb](./VB/WindowsFormsApplication1/Program.vb))
<!-- default file list end -->
# How to load an MS Access Database file into the SpreadsheetControl's document


<p>This example demonstrates how to extend the list of supported files which is displayed in the "Open File" dialog with the "MDB" file format while loading a document into the SpreadsheetControl.</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-load-an-ms-access-database-file-into-the-spreadsheetcontrols-document-t304456/15.1.3+/media/905af7e1-7bf3-11e5-80bf-00155d62480c.png"><br />
<p>To extend this list, a custom <strong>AccessDBDocumentImporter</strong> class was implemented. To add this functionality into an existing project, simply execute the <strong>SpreadsheetControl.ExtendOpenFileCommand</strong> method:</p>


```cs
spreadsheetControl1.ExtendOpenFileCommand();

```


<p>To load data from an MS Access Database file, a corresponding extension <strong>LoadMSAccessFile</strong> method was implemented. This method can be used for the SpreadsheetControl's document, as well as the Workbook instance.</p>

<br/>


