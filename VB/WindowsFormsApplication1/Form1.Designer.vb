Imports Microsoft.VisualBasic
Imports System
Namespace WindowsFormsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.spreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.spreadsheetCommandBarButtonItem1 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem2 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem3 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem4 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem5 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem6 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem7 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem8 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem9 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.spreadsheetCommandBarButtonItem10 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem()
			Me.fileRibbonPage1 = New DevExpress.XtraSpreadsheet.UI.FileRibbonPage()
			Me.commonRibbonPageGroup1 = New DevExpress.XtraSpreadsheet.UI.CommonRibbonPageGroup()
			Me.infoRibbonPageGroup1 = New DevExpress.XtraSpreadsheet.UI.InfoRibbonPageGroup()
			Me.spreadsheetBarController1 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.spreadsheetBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' spreadsheetControl1
			' 
			Me.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.spreadsheetControl1.Location = New System.Drawing.Point(0, 143)
			Me.spreadsheetControl1.MenuManager = Me.ribbonControl1
			Me.spreadsheetControl1.Name = "spreadsheetControl1"
			Me.spreadsheetControl1.Size = New System.Drawing.Size(990, 579)
			Me.spreadsheetControl1.TabIndex = 0
			Me.spreadsheetControl1.Text = "spreadsheetControl1"
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.spreadsheetCommandBarButtonItem1, Me.spreadsheetCommandBarButtonItem2, Me.spreadsheetCommandBarButtonItem3, Me.spreadsheetCommandBarButtonItem4, Me.spreadsheetCommandBarButtonItem5, Me.spreadsheetCommandBarButtonItem6, Me.spreadsheetCommandBarButtonItem7, Me.spreadsheetCommandBarButtonItem8, Me.spreadsheetCommandBarButtonItem9, Me.spreadsheetCommandBarButtonItem10})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 12
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.fileRibbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(990, 143)
			' 
			' spreadsheetCommandBarButtonItem1
			' 
			Me.spreadsheetCommandBarButtonItem1.CommandName = "FileNew"
			Me.spreadsheetCommandBarButtonItem1.Id = 1
			Me.spreadsheetCommandBarButtonItem1.Name = "spreadsheetCommandBarButtonItem1"
			' 
			' spreadsheetCommandBarButtonItem2
			' 
			Me.spreadsheetCommandBarButtonItem2.CommandName = "FileOpen"
			Me.spreadsheetCommandBarButtonItem2.Id = 2
			Me.spreadsheetCommandBarButtonItem2.Name = "spreadsheetCommandBarButtonItem2"
			' 
			' spreadsheetCommandBarButtonItem3
			' 
			Me.spreadsheetCommandBarButtonItem3.CommandName = "FileSave"
			Me.spreadsheetCommandBarButtonItem3.Id = 3
			Me.spreadsheetCommandBarButtonItem3.Name = "spreadsheetCommandBarButtonItem3"
			' 
			' spreadsheetCommandBarButtonItem4
			' 
			Me.spreadsheetCommandBarButtonItem4.CommandName = "FileSaveAs"
			Me.spreadsheetCommandBarButtonItem4.Id = 4
			Me.spreadsheetCommandBarButtonItem4.Name = "spreadsheetCommandBarButtonItem4"
			' 
			' spreadsheetCommandBarButtonItem5
			' 
			Me.spreadsheetCommandBarButtonItem5.CommandName = "FileQuickPrint"
			Me.spreadsheetCommandBarButtonItem5.Id = 5
			Me.spreadsheetCommandBarButtonItem5.Name = "spreadsheetCommandBarButtonItem5"
			' 
			' spreadsheetCommandBarButtonItem6
			' 
			Me.spreadsheetCommandBarButtonItem6.CommandName = "FilePrint"
			Me.spreadsheetCommandBarButtonItem6.Id = 6
			Me.spreadsheetCommandBarButtonItem6.Name = "spreadsheetCommandBarButtonItem6"
			' 
			' spreadsheetCommandBarButtonItem7
			' 
			Me.spreadsheetCommandBarButtonItem7.CommandName = "FilePrintPreview"
			Me.spreadsheetCommandBarButtonItem7.Id = 7
			Me.spreadsheetCommandBarButtonItem7.Name = "spreadsheetCommandBarButtonItem7"
			' 
			' spreadsheetCommandBarButtonItem8
			' 
			Me.spreadsheetCommandBarButtonItem8.CommandName = "FileUndo"
			Me.spreadsheetCommandBarButtonItem8.Id = 8
			Me.spreadsheetCommandBarButtonItem8.Name = "spreadsheetCommandBarButtonItem8"
			' 
			' spreadsheetCommandBarButtonItem9
			' 
			Me.spreadsheetCommandBarButtonItem9.CommandName = "FileRedo"
			Me.spreadsheetCommandBarButtonItem9.Id = 9
			Me.spreadsheetCommandBarButtonItem9.Name = "spreadsheetCommandBarButtonItem9"
			' 
			' spreadsheetCommandBarButtonItem10
			' 
			Me.spreadsheetCommandBarButtonItem10.CommandName = "FileShowDocumentProperties"
			Me.spreadsheetCommandBarButtonItem10.Id = 10
			Me.spreadsheetCommandBarButtonItem10.Name = "spreadsheetCommandBarButtonItem10"
			' 
			' fileRibbonPage1
			' 
			Me.fileRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.commonRibbonPageGroup1, Me.infoRibbonPageGroup1})
			Me.fileRibbonPage1.Name = "fileRibbonPage1"
			' 
			' commonRibbonPageGroup1
			' 
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem1)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem2)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem3)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem4)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem5)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem6)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem7)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem8)
			Me.commonRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem9)
			Me.commonRibbonPageGroup1.Name = "commonRibbonPageGroup1"
			' 
			' infoRibbonPageGroup1
			' 
			Me.infoRibbonPageGroup1.ItemLinks.Add(Me.spreadsheetCommandBarButtonItem10)
			Me.infoRibbonPageGroup1.Name = "infoRibbonPageGroup1"
			' 
			' spreadsheetBarController1
			' 
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem1)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem2)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem3)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem4)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem5)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem6)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem7)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem8)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem9)
			Me.spreadsheetBarController1.BarItems.Add(Me.spreadsheetCommandBarButtonItem10)
			Me.spreadsheetBarController1.Control = Me.spreadsheetControl1
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(990, 722)
			Me.Controls.Add(Me.spreadsheetControl1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "Form1"
			Me.Ribbon = Me.ribbonControl1
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.spreadsheetBarController1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private spreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private spreadsheetCommandBarButtonItem1 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem2 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem3 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem4 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem5 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem6 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem7 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem8 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem9 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private spreadsheetCommandBarButtonItem10 As DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem
		Private fileRibbonPage1 As DevExpress.XtraSpreadsheet.UI.FileRibbonPage
		Private commonRibbonPageGroup1 As DevExpress.XtraSpreadsheet.UI.CommonRibbonPageGroup
		Private infoRibbonPageGroup1 As DevExpress.XtraSpreadsheet.UI.InfoRibbonPageGroup
		Private spreadsheetBarController1 As DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController
	End Class
End Namespace

