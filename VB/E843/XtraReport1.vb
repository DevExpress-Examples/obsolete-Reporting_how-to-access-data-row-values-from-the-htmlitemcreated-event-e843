Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace E843

    Public Partial Class XtraReport1
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            InitializeComponent()
            dataSet1.Tables(0).Rows.Add(New [Object]() {1, "Williams"})
            dataSet1.Tables(0).Rows.Add(New [Object]() {2, "Smith"})
        End Sub

        Private Sub xrLabel1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            CType(sender, XRLabel).Tag = GetCurrentColumnValue("ID")
        End Sub

        Private Sub xrLabel1_HtmlItemCreated(ByVal sender As Object, ByVal e As HtmlEventArgs)
            e.ContentCell.InnerHtml = [String].Format("<a href=http://www.testarea.com/property.aspx?id={1}>{0}</a>", e.ContentCell.InnerText, e.Brick.Value)
        End Sub
    End Class
End Namespace
