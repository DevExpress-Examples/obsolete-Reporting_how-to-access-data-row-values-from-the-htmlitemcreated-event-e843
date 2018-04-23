Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace E843
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim FileName As String = "XtraReport1.html"
			Dim report As New XtraReport1()
			report.ExportToHtml(FileName)
			OpenFile(FileName)
		End Sub

		Private Sub OpenFile(ByVal fileName As String)
			Try
				Dim process As New System.Diagnostics.Process()
				process.StartInfo.FileName = fileName
				process.StartInfo.Verb = "Open"
				process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
				process.Start()
			Catch e As Exception
				MessageBox.Show(Me, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try

		End Sub
	End Class
End Namespace
